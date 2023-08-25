using form_409_check.KURS_FX_XLSX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace form_409_check
{
    /// <summary>
    /// Interaction logic for RatesFXwindow.xaml
    /// </summary>
    public partial class RatesFXwindow : Window
    {
        private KursFX kursFxViewField;
        public KursFX kursiFXview
        {
            get { return kursFxViewField; }
            set 
            { 
                kursFxViewField = value;
                DataGridKursFX.DataContext = value.tbl_currRates.DefaultView;
            }
        }
        public RatesFXwindow()
        {
            InitializeComponent();
        }
    }
}