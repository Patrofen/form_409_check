using ExcelDataReader;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form_409_check
{
    internal class ExcelInteraction
    {
        #region Взаимодействие с Excel

        //Получить из коллекции листов файла Excel таблицу System.Data.DataTable, используя ExcelDataReader
        private System.Data.DataTableCollection xlsSheetsCollection;
        public System.Data.DataTable OpenUsingExcelDataReader(FileInfo filePath)
        {
            bool isExist = this.IsExist(filePath.FullName);
            if (!isExist)
            {
                MessageService.ShowExclmation("Файл " + filePath.Name + "не существует");
            }
            xlsSheetsCollection = ExcelToDataTableCollection(filePath);
            //Получить DataTable, эквивалентную первому листу файла Excel
            try
            {
                System.Data.DataTable result = xlsSheetsCollection[0];
                return result;
            }
            catch (NullReferenceException)
            {
                MessageService.ShowError("Закройте файл " + filePath.Name + "\n\nи повторите загрузку");
                return null;
            }
            catch (Exception ex)
            {
                MessageService.ShowError(ex.Message);
                return null;
            }
        }

        //Получить из файла Excel коллекцию листов типа DataTableCollection (используется ExcelDataReader)
        public DataTableCollection ExcelToDataTableCollection(FileInfo filePath)
        {
            try
            {
                using (var stream = File.Open(filePath.FullName, FileMode.Open, FileAccess.Read))
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                        });
                        DataTableCollection tableCollection = result.Tables;
                        return tableCollection;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ExcelToDataTableCollection \n" + ex.Message);
                return null;
            }
        }

        //Проверка на существование файла
        public bool IsExist(string filePath)
        {
            bool isExist = File.Exists(filePath);
            return isExist;
        }

        //Получить путь к файлу
        public static FileInfo GetFileInfo(string xlDir, string file)
        {
            char dirSept = Path.DirectorySeparatorChar;
            var fi = new FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}409_Tables" + dirSept + xlDir + dirSept + file);
            return fi;
        }

        ////Используется EPPlus
        //public void DataTableToExcel(System.Data.DataTable content, FileInfo destination_xlFile)
        //{
        //    try
        //    {
        //        using (ExcelPackage toExcel = new ExcelPackage(destination_xlFile))
        //        {
        //            ExcelWorksheet wksht_destination = toExcel.Workbook.Worksheets[1];
        //            wksht_destination.Cells["A2"].LoadFromDataTable(content, false);
        //            wksht_destination.Cells[2, 7, content.Rows.Count + 1, 7].Style.Numberformat.Format = DateTimePickerFormat.Short.ToString();
        //            toExcel.SaveAs(destination_xlFile);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}
        ////Вывод DataTable из DataGridView в эксель
        //public void DataGridViewToExcel(System.Data.DataTable content, FileInfo destination_xlFile)
        //{
        //    try
        //    {
        //        using (ExcelPackage toExcel = new ExcelPackage(destination_xlFile))
        //        {
        //            ExcelWorksheet wksht_destination = toExcel.Workbook.Worksheets[1];
        //            wksht_destination.Cells["A2"].LoadFromDataTable(content, false);
        //            wksht_destination.Cells[2, 7, content.Rows.Count + 1, 7].Style.Numberformat.Format = DateTimePickerFormat.Short.ToString();
        //            toExcel.SaveAs(destination_xlFile);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}
        #endregion
    }
}
