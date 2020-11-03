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
using KwikMedicalSystem.Business.ViewModels;

namespace KwikMedical.HospitalView
{
    /// <summary>
    /// Interaction logic for HospitalWindow.xaml
    /// </summary>
    public partial class HospitalWindow : Window
    {
        public HospitalViewModel HospitalViewModel = new HospitalViewModel();
        public HospitalWindow()
        {
            InitializeComponent();
            this.DataContext = HospitalViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdatePatientWindow window = new UpdatePatientWindow(HospitalViewModel);
            window.Show();
        }
    }
}
