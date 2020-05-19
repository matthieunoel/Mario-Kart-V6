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
        private ClassePasserelle passerelle;
        private List<Tournament> tournamentList;
        private Tournament lastSelectedTournament;

        private void BtnClickAddTournament(object sender, RoutedEventArgs e)
        {
            AddTournament add = new AddTournament(this.passerelle);
            add.Show();
        }

        private void BtnClickSeeTournament(object sender, RoutedEventArgs e)
        {
            SeeTournament see = new SeeTournament(this.passerelle);
            //this.Content = see.Content;
            see.Show();

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Initialized(object sender, EventArgs e)
        {
            this.passerelle = new ClassePasserelle();
            this.tournamentList = passerelle.GetAllTournaments();
            this.mainDataGrid.ItemsSource = tournamentList;

        }

        private void DataGridSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            this.lastSelectedTournament = (Tournament)e.AddedCells[0].Item;
            //MessageBox.Show(selectedTournament.Nom, "DEBUG", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            this.tournamentList = passerelle.GetAllTournaments();
            this.mainDataGrid.ItemsSource = tournamentList;
        }
    }
}  
