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

namespace SolutionMKV6
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnClickAddTournament(object sender, RoutedEventArgs e)
        {
            AddTournament add = new AddTournament();
            this.Content = add.Content; 
        }

        private void BtnClickSeeTournament(object sender, RoutedEventArgs e)
        {
            Main.Content = new SeeTournament();
        }

    }
}
