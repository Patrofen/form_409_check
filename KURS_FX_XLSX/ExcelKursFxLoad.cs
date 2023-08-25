using form_409_check.KURS_FX_XLSX;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;



namespace form_409_check
{
    public partial class MainWindow : Window
    {
        public KursFX kursiFX = new KursFX();
        ExcelInteraction excelInteraction = new ExcelInteraction();

        //Парсинг из файлов Excel, скачанных с www.cbr.ru (Динамика официального курса заданной валюты)
        private void ExcelKursFxLoad(string xlsxFilePath)
        {
            DirectoryInfo d = new DirectoryInfo(xlsxFilePath);
            FileInfo[] Files = d.GetFiles("*.xlsx"); //Getting *.xlsx files

            for (int i = 0; i < Files.Length; i++)
            {
                try
                {
                    //Загрузка курсов
                    DataTable ExcelTbleFormCBR = excelInteraction.OpenUsingExcelDataReader(Files[i]); 
                    CheckAndWriteCurrRates(ExcelTbleFormCBR);
                }
                catch (Exception ex)
                {
                    MessageService.ShowError(ex.Message.ToString());
                }
                
            }
            try
            {
                //Загрузка справочника валют
                FileInfo xlFile_curr_codes = ExcelInteraction.GetFileInfo("Справочники", "Код_валюты.xlsx");
                kursiFX.tbl_currCatalog = excelInteraction.OpenUsingExcelDataReader(xlFile_curr_codes);

                lblKursFXlstatus.Content = "Курсы загружены";
                lblKursFXlstatus.Foreground = Brushes.Black;
                lblKursFXlstatus.FontWeight = FontWeights.Bold;
                MessageService.ShowMessage("Загрузка курсов завершена");
            }
            catch (Exception ex)
            {
                MessageService.ShowError(ex.Message.ToString());
            }
            
        }

        //Парсинг из файла Excel (спользуется ExcelDataReader) в DataTable
        public void CheckAndWriteCurrRates(System.Data.DataTable currRatesFormCBR)
        {
            //Сохранить состояние предыдущей строки
            DateTime datePrev = new DateTime();
            int nominal=0;
            int nominalPrev = 0;
            string cdxPrev = "";
            double FXrate = 0;
            double fxRatePrev = 0;

            for (int i = 0; i < currRatesFormCBR.Rows.Count; i++ )
            {
                DataRow CBRrow = currRatesFormCBR.Rows[i];
                DataRow sys_row = kursiFX.tbl_currRates.NewRow();
                
                //Дата
                bool is_Date = DateTime.TryParse(CBRrow["data"].ToString(), out DateTime date);
                if (is_Date)
                {
                    sys_row["Дата"] = date;
                    if (i == 0)
                        datePrev = date;
                }
                else
                {
                    sys_row["Дата"] = 0;
                }

                //Если отутствует курс между датами из выгрузки
                if (i > 0 && date > datePrev.AddDays(1))
                {
                    DateTime missedDate = new DateTime();
                    int DaysMissed = (int)(date - datePrev).TotalDays-1;
                    for (int j = 0; j < DaysMissed; j++)
                    {
                        DataRow missedSys_row = kursiFX.tbl_currRates.NewRow();
                        missedDate = datePrev.AddDays(j+1);
                        //Формирование строки для пропущенной даты и добавление его в таблицу
                        missedSys_row["Дата"] = missedDate;
                        missedSys_row["Номинал"] = nominalPrev;
                        missedSys_row["Валюта"] = cdxPrev;
                        missedSys_row["Курс"] = fxRatePrev;
                        kursiFX.tbl_currRates.Rows.Add(missedSys_row);
                    }
                }

                //Номинал
                bool is_Units = int.TryParse(CBRrow["nominal"].ToString(), out nominal);
                if (is_Units)
                {
                    sys_row["Номинал"] = nominal;
                }
                else
                {
                    sys_row["Номинал"] = 0;
                }

                //Валюта
                sys_row["Валюта"] = CBRrow["cdx"].ToString();

                //Курс
                bool is_FXrate = double.TryParse(CBRrow["curs"].ToString(), out FXrate);
                if (is_Units)
                {
                    sys_row["Курс"] = FXrate;
                }
                else
                {
                    sys_row["Курс"] = 0;
                }

                datePrev = date;
                nominalPrev = nominal;
                cdxPrev = CBRrow["cdx"].ToString();
                fxRatePrev = FXrate;
                kursiFX.tbl_currRates.Rows.Add(sys_row);

                //Если отутствует курс на последий день отчетного периода
                if ((i == currRatesFormCBR.Rows.Count - 1) && date < dateEnd)
                {
                    DateTime missedDate = new DateTime();
                    int DaysMissed = (int)(dateEnd - date).TotalDays;
                    for (int j = 0; j < DaysMissed; j++)
                    {
                        DataRow missedSys_row = kursiFX.tbl_currRates.NewRow();
                        missedDate = date.AddDays(j + 1);
                        //Формирование строки для пропущенной даты и добавление его в таблицу
                        missedSys_row["Дата"] = missedDate;
                        missedSys_row["Номинал"] = nominal;
                        missedSys_row["Валюта"] = cdxPrev;
                        missedSys_row["Курс"] = FXrate;
                        kursiFX.tbl_currRates.Rows.Add(missedSys_row);
                    }
                }
            }
        }
    }
}