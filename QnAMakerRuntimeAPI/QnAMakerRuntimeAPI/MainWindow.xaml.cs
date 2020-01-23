using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QnAMakerRuntimeAPI.ViewModel;
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

namespace QnAMakerRuntimeAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IQnAViewModel mViewModel;
        public MainWindow()
        {
            InitializeComponent();


            var di = (Application.Current as QnAMakerRuntimeAPI.App).Services;
            mViewModel = new QnAViewModel(di.GetRequiredService<IConfiguration>());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = mViewModel;
        }
    }
}
