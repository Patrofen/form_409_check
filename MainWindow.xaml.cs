using form_409_check.VTB_XML;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.Xml;
using System.Reflection.Metadata;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.Net.Security;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Data;
using System.Windows.Forms;

namespace form_409_check
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DateTime dateStart;
        public DateTime dateEnd;

        public MainWindow()
        {
            InitializeComponent();
        }

        //Обработчики нажатия кнопок
        #region Кнопки
        private void btnPathVTB_Click(object sender, RoutedEventArgs e)
        {
            string? xmlFilePath;

            CommonOpenFileDialog ofd = new() { IsFolderPicker = true };
            if (ofd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                xmlFilePath = ofd.FileName;
                lblFolderVTB.Content = xmlFilePath;
            }
            else
            {
                xmlFilePath = string.Empty;
                lblFolderVTB.Content = "Папка не выбрана";
            }
        }

        private void btnPathNRD_Click(object sender, RoutedEventArgs e)
        {
            string? TxtNrdPath;

            CommonOpenFileDialog ofd = new() { IsFolderPicker = true };
            if (ofd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                TxtNrdPath = ofd.FileName;
                lblFolderNRD.Content = TxtNrdPath;
            }
            else
            {
                TxtNrdPath = string.Empty;
                lblFolderNRD.Content = "Папка не выбрана";
            }
        }

        private void btnPathNRB_Click(object sender, RoutedEventArgs e)
        {
            string? TxtNrbPath;

            CommonOpenFileDialog ofd = new() { IsFolderPicker = true };
            if (ofd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                TxtNrbPath = ofd.FileName;
                lblFolderNRB.Content = TxtNrbPath;
            }
            else
            {
                TxtNrbPath = string.Empty;
                lblFolderNRB.Content = "Папка не выбрана";
            }
        }
        
        private void btnPathKursFX_Click(object sender, RoutedEventArgs e)
        {
            string? KursFXPath;

            CommonOpenFileDialog ofd = new() { IsFolderPicker = true };
            if (ofd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                KursFXPath = ofd.FileName;
                lblFolderKursFX.Content = KursFXPath;
            }
            else
            {
                KursFXPath = string.Empty;
                lblFolderKursFX.Content = "Папка не выбрана";
            }
            
        }

        private void btnLoadVipiski_Click(object sender, RoutedEventArgs e)
        {
            if (lblKursFXlstatus.Content.ToString() == "Курсы не загружены")
            {
                MessageService.ShowError("Для продолжения загрузите курсы валют");
                return;
            }
            //Загрузить выписки ВТБ
            string? pathVTB = lblFolderVTB.Content.ToString();
            if (pathVTB != "Папка не выбрана" && pathVTB != null)
            {
                XmlVtbLoad(pathVTB);
            }
            //Загрузить выписки НРД
            string? pathNRD = lblFolderVTB.Content.ToString();
            if (pathNRD != "Папка не выбрана" && pathNRD != null)
            {
                TxtNRDLoad(pathNRD);
            }
            MessageService.ShowMessage("Загрузка выписок завершена");
        }

        private void btnLoadKursFX_Click(object sender, RoutedEventArgs e)
        {
            //Загрузить файлы excel с курсами валют
            string? pathKursFX = lblFolderKursFX.Content.ToString();
            if(pathKursFX == "Папка не выбрана")
            {
                MessageService.ShowError("Для загрузки курсов валют выберите папку");
                return;
            }
            ExcelKursFxLoad(pathKursFX);
        }

        private void btnKursView_Click(object sender, RoutedEventArgs e)
        {
            if (kursiFX == null)
            {
                MessageService.ShowError("Курсы не загружены");
                return;
            }
            RatesFXwindow ratesFXwindow = new RatesFXwindow();
            ratesFXwindow.Owner = this;
            ratesFXwindow.kursiFXview = kursiFX;
            ratesFXwindow.Show();
        }

        //Установка даты начала отчетного периода
        private void btnPeriodStart_Click(object sender, RoutedEventArgs e)
        {
            CalendarStart.Visibility = Visibility.Visible;
        }

        //Установка даты конца отчетного периода
        private void btnPeriodEnd_Click(object sender, RoutedEventArgs e)
        {
            CalendarEnd.Visibility = Visibility.Visible;
        }
        #endregion

        private void CalendarStart_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CalendarStart.SelectedDate.HasValue)
            {
                dateStart = CalendarStart.SelectedDate.Value;
                lblReportDateStart.Content = CalendarStart.SelectedDate.Value.ToString("dd.MM.yyyy");
                CalendarStart.Visibility = Visibility.Hidden;
                lblReportDateStart.Foreground = Brushes.Black;
                lblReportDateStart.FontWeight = FontWeights.Bold;
            }
        }

        private void CalendarEnd_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CalendarEnd.SelectedDate.HasValue)
            {
                dateEnd = CalendarEnd.SelectedDate.Value;
                lblReportDateEnd.Content = CalendarEnd.SelectedDate.Value.ToString("dd.MM.yyyy");
                CalendarEnd.Visibility = Visibility.Hidden;
                lblReportDateEnd.Foreground = Brushes.Black;
                lblReportDateEnd.FontWeight = FontWeights.Bold;
            }
        }

        private void btnVipiskiView_Click(object sender, RoutedEventArgs e)
        {
            if (VipiskiVTB == null)
            {
                MessageService.ShowError("Выписки не загружены");
                return;
            }
            VipiskiWindow vipiskiWindow = new VipiskiWindow();
            vipiskiWindow.Owner = this;
            vipiskiWindow.VipiskiView = VipiskiVTB;
            vipiskiWindow.Show();
        }
    }
}