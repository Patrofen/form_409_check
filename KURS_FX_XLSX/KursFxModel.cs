using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace form_409_check.KURS_FX_XLSX
{
    public class KursFX
    {
        public System.Data.DataTable tbl_currRates = new System.Data.DataTable("currRatesSystem"); //Курсы валют
        public System.Data.DataTable tbl_currCatalog; //Справочник кодов валют и их нименований
        public KursFX() 
        {
            this.ResetSystemTable(tbl_currRates);
        }

        public void ResetSystemTable(System.Data.DataTable table)
        {
            table.Reset();
            table.Columns.Add("Дата", typeof(DateTime));
            table.Columns.Add("Номинал", typeof(int));
            table.Columns.Add("Курс", typeof(double));
            table.Columns.Add("Валюта", typeof(string));
        }
    }
}