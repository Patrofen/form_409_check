using form_409_check.VTB_XML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;



namespace form_409_check
{
    public partial class MainWindow : Window
    {
        public List<VipiskaVTB> VipiskiVTB = new List<VipiskaVTB>();
        //загрузка выписок ВТБ из xml файлов
        private void XmlVtbLoad(string xmlFilePath)
        {
            VipiskiVTB.Clear();
            DirectoryInfo d = new DirectoryInfo(xmlFilePath);
            FileInfo[] Files = d.GetFiles("*.xml"); //Getting XML files
            
            string currFullName;
            double FxRateDouble; 
            int FxUnitsInt;  
            Utils utils = new Utils();

            //foreach (FileInfo file in Files)
            for (int i = 0; i < Files.Length; i++)
            {
                try
                {
                    //парсинг XML выписки Банка ВТБ
                    string xml = File.ReadAllText(Files[i].FullName);
                    XmlSerializer serializer = new XmlSerializer(typeof(Workbook));
                    Workbook? XMLvipiskaVTB;
                    
                        using (var sr = new StringReader(xml))
                            XMLvipiskaVTB = serializer.Deserialize(sr) as Workbook;
                   
                    //Перенос данных из распарсенной XML в класс VipiskaVTB, для 409 формы
                    VipiskaVTB vipiskaVTB = new VipiskaVTB();

                    WorkbookWorksheetTableRow[] row = XMLvipiskaVTB.Worksheet.Table.Row;
                    for (int rowNum = 5; rowNum < row.Length; rowNum++)
                    {
                        //Номер счета и код валюты
                        if (row[rowNum].Cell[0].Data != null)
                        {
                            string cell0 = row[rowNum].Cell[0].Data.Value;
                            Regex regex = new Regex(@"\d{20}");
                            Regex regex1 = new Regex(@"Валюта \d{3}");
                            if (regex.IsMatch(cell0))
                            {
                                vipiskaVTB.Account = regex.Match(cell0).Value;
                                vipiskaVTB.KodValutiDig = regex1.Match(cell0).Value.Substring(7);
                                vipiskaVTB.KodValutiShort = utils.FindCorrespondence(vipiskaVTB.KodValutiDig, kursiFX.tbl_currCatalog, "Цифр. код", "Код", out int _);
                                vipiskaVTB.KodValutiFullText = utils.FindCorrespondence(vipiskaVTB.KodValutiDig, kursiFX.tbl_currCatalog, "Цифр. код", "ПолноеНаименование", out int _);
                            }
                        }

                        //Входящий остаток
                        if (row[rowNum].Cell[0].Data != null)
                        {
                            string cell0 = row[rowNum].Cell[0].Data.Value;
                            if (cell0.StartsWith("ВХОДЯЩИЙ ОСТАТОК"))
                            {
                                double.TryParse(RemoveSpaces(row[rowNum].Cell[7].Data.Value), out double resultVhodOstatok);

                                //Если в иностранной валюте
                                if (vipiskaVTB.KodValutiDig != "643")
                                {
                                    FxRateDouble = utils.FindDouble(vipiskaVTB.KodValutiFullText, dateStart, kursiFX.tbl_currRates, "Валюта", "Дата", "Курс", out int _);
                                    FxUnitsInt = utils.FindInt(vipiskaVTB.KodValutiFullText, kursiFX.tbl_currRates, "Валюта", "Номинал", out int _);
                                    vipiskaVTB.VhodOstatok = Math.Round(resultVhodOstatok * (FxRateDouble / FxUnitsInt),2);
                                }
                                else 
                                {
                                    vipiskaVTB.VhodOstatok = resultVhodOstatok;
                                }
                            }
                        }

                        //Исходящий остаток
                        //TODO: Добавить расчет валютного исходящего остатка
                        if (row[rowNum].Cell[0].Data != null)
                        {
                            string cell0 = row[rowNum].Cell[0].Data.Value;
                            if (cell0.StartsWith("ИСХОДЯЩИЙ ОСТАТОК"))
                            {
                                double.TryParse(RemoveSpaces(row[rowNum].Cell[7].Data.Value), out double resultIshOstatok);

                                //Если в иностранной валюте
                                if (vipiskaVTB.KodValutiDig != "643")
                                {
                                    FxRateDouble = utils.FindDouble(vipiskaVTB.KodValutiFullText, dateEnd, kursiFX.tbl_currRates, "Валюта", "Дата", "Курс", out int _);
                                    FxUnitsInt = utils.FindInt(vipiskaVTB.KodValutiFullText, kursiFX.tbl_currRates, "Валюта", "Номинал", out int _);
                                    vipiskaVTB.IshodOstatok = Math.Round(resultIshOstatok * (FxRateDouble / FxUnitsInt),2);
                                }
                                else
                                {
                                    vipiskaVTB.IshodOstatok = resultIshOstatok;
                                }
                            }
                        }
                        
                        //Обороты
                        if (rowNum >= 12)
                        {
                            //Зачисления
                            if(row[rowNum].Cell[7].Data != null && row[rowNum].Cell[0].Data != null)
                            {
                                string cell0 = row[rowNum].Cell[0].Data.Value;
                                Regex regex = new Regex(@"\d{2}\.\d{2}\.\d{4}");
                                if (regex.IsMatch(cell0))
                                {
                                    DateTime.TryParse(cell0, out DateTime date);
                                    double.TryParse(RemoveSpaces(row[rowNum].Cell[7].Data.Value), out double resultCredit);

                                    //Если в иностранной валюте
                                    if (vipiskaVTB.KodValutiDig != "643")
                                    {
                                        FxRateDouble = utils.FindDouble(vipiskaVTB.KodValutiFullText, date, kursiFX.tbl_currRates, "Валюта", "Дата", "Курс", out int _);
                                        FxUnitsInt = utils.FindInt(vipiskaVTB.KodValutiFullText, kursiFX.tbl_currRates, "Валюта", "Номинал", out int _);
                                        double resultCreditFX = (resultCredit * (FxRateDouble / FxUnitsInt));
                                        vipiskaVTB.Zachisleno = Math.Round((vipiskaVTB.Zachisleno + resultCreditFX), 2);
                                    }
                                    //Если в рублях
                                    else
                                    {
                                        vipiskaVTB.Zachisleno = Math.Round((vipiskaVTB.Zachisleno + resultCredit), 2);
                                    }
                                }
                            }

                            //Списания
                            if (row[rowNum].Cell[6].Data != null && row[rowNum].Cell[0].Data != null) 
                            {
                                string cell0 = row[rowNum].Cell[0].Data.Value;
                                Regex regex = new Regex(@"\d{2}\.\d{2}\.\d{4}");
                                if (regex.IsMatch(cell0))
                                {
                                    DateTime.TryParse(cell0, out DateTime date);
                                    double.TryParse(RemoveSpaces(row[rowNum].Cell[6].Data.Value), out double resultDebit);

                                    //Если в иностранной валюте
                                    if (vipiskaVTB.KodValutiDig != "643")
                                    {
                                        FxRateDouble = utils.FindDouble(vipiskaVTB.KodValutiFullText, date, kursiFX.tbl_currRates, "Валюта", "Дата", "Курс", out int _);
                                        FxUnitsInt = utils.FindInt(vipiskaVTB.KodValutiFullText, kursiFX.tbl_currRates, "Валюта", "Номинал", out int _);
                                        double resultCreditFX = (resultDebit * (FxRateDouble / FxUnitsInt));
                                        vipiskaVTB.Spisano = Math.Round((vipiskaVTB.Spisano + resultCreditFX), 2);
                                    }
                                    //Если в рублях
                                    else
                                    {
                                        vipiskaVTB.Spisano = Math.Round((vipiskaVTB.Spisano + resultDebit), 2);
                                    }
                                }
                            }
                        }
                    }
                    VipiskiVTB.Add(vipiskaVTB);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message + "\nОшибка в файле: " + file.FullName);
                    MessageBox.Show(ex.Message + "\nОшибка в файле: " + Files[i].FullName +
                        "\nИндекс файла: " + i.ToString());
                }
            }
        }

        private string RemoveSpaces (string strng)
        {
            return String.Concat(strng.Where(c => !Char.IsWhiteSpace(c)));
        }
    }
}