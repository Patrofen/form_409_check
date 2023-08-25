using form_409_check.KURS_FX_XLSX;
using form_409_check.VTB_XML;
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
    /// Interaction logic for VipiskiWindow.xaml
    /// </summary>
    public partial class VipiskiWindow : Window
    {
        private List<VipiskaVTB> vipiskiViewField;
        public List<VipiskaVTB> VipiskiView
        {
            get { return vipiskiViewField; }
            set
            {
                vipiskiViewField = value;
                DataGridVipiski.ItemsSource = value;
            }
        }
        public VipiskiWindow()
        {
            InitializeComponent();
        }
    }
}
