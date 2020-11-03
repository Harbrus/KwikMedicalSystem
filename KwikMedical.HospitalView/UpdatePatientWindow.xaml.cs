using KwikMedicalSystem.Business.ViewModels;
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

namespace KwikMedical.HospitalView
{
    /// <summary>
    /// Interaction logic for UpdatePatientWindow.xaml
    /// </summary>
    public partial class UpdatePatientWindow : Window
    {
        public UpdatePatientWindow(HospitalViewModel hospitalViewModel)
        {
            InitializeComponent();
            this.DataContext = hospitalViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NHSNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NHSNumber.Text == string.Empty)
            {
                this.Close();
            }
        }
    }
}
