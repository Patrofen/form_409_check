using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace form_409_check
{
    public class Utils
    {
        //Поиск соответствий в таблицах
        #region Utils
        public string FindCorrespondence(string obj, DataTable fromTable, string SearchedField, string ReturnedField, out int errors)
        {
            errors = 0;
            try
            {
                var result = from row in fromTable.AsEnumerable()
                             where row.Field<string>(SearchedField) == obj
                             select row.Field<string>(ReturnedField);
                return result.First<string>();
            }
            catch (Exception ex)
            {
                MessageService.ShowError(ex.ToString());
                //errors += 1;
                return "error";
            }
        }

        public double FindDouble(string obj, DataTable fromTable, string SearchedField, string ReturnedField, out int errors)
        {
            errors = 0;
            try
            {
                var result = from row in fromTable.AsEnumerable()
                             where row.Field<string>(SearchedField) == obj
                             select row.Field<double>(ReturnedField);
                return result.First<double>();
            }
            catch (Exception ex)
            {
                MessageService.ShowError(ex.ToString());
                errors += 1;
                return 0;
            }
        }

        //Поиск курса по наименованию валюты и дате
        public double FindDouble(string obj, DateTime date, DataTable fromTable, string SearchedField1, string SearchedDateField, string ReturnedField, out int errors)
        {
            errors = 0;
            try
            {
                var result = from row in fromTable.AsEnumerable()
                             where row.Field<string>(SearchedField1) == obj && row.Field<DateTime>(SearchedDateField) == date
                             select row.Field<double>(ReturnedField);
                return result.First<double>();
            }
            catch (Exception ex)
            {
                MessageService.ShowError(ex.ToString() + "\n\n Не загружен курс!" + "\n Валюта: " + obj + "\n Дата: " + date);
                errors += 1;
                return 0;
            }
        }

        public int FindInt(string obj, DataTable fromTable, string SearchedField, string ReturnedField, out int errors)
        {
            errors = 0;
            try
            {
                var result = from row in fromTable.AsEnumerable()
                             where row.Field<string>(SearchedField) == obj
                             select row.Field<int>(ReturnedField);
                return result.First<int>();
            }
            catch (Exception ex)
            {
                MessageService.ShowError(ex.ToString());
                errors += 1;
                return 0;
            }
        }
        #endregion
    }
}
