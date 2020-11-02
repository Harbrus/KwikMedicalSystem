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

namespace KwikMedical.OperatorView
{
    /// <summary>
    /// Interaction logic for OperatorWindow.xaml
    /// </summary>
    public partial class OperatorWindow : Window
    {
        public OperatorViewModel OperatorViewModel = new OperatorViewModel();
        public OperatorWindow()
        {
            InitializeComponent();
            this.DataContext = OperatorViewModel;
        }
    }
}
