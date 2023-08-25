using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace form_409_check.VTB_XML
{
    public class VipiskaVTB
    {
        public string Account { get; set; }
        public string BankName { get; } = "Банк ВТБ (ПАО)";
        public string KodValutiDig { get; set; }
        public string KodValutiShort { get; set; }
        public string KodValutiFullText { get; set; }
        public double VhodOstatok { get; set; }
        public double IshodOstatok { get; set; }
        public double Zachisleno { get; set; }
        public double Spisano { get; set; }
    }
}