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
using System.Windows.Navigation;
using System.Windows.Shapes;
using KwikMedicalSystem.Business.ViewModels;

namespace KwikMedical.AmbulanceView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AmbulanceViewModel AmbulanceViewModel = new AmbulanceViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = AmbulanceViewModel;
        }
    }
}
