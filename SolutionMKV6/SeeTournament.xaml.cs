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


namespace SolutionMKV6
{
    /// <summary>
    /// Logique d'interaction pour SeeTournament.xaml
    /// </summary>
    public partial class SeeTournament : Window
    {
        private ClassePasserelle passerelle;
        private List<Tournament> tournList;
        private Tournament lastSelectedTournament;

        public SeeTournament(ClassePasserelle passerelleParam)
        {
            InitializeComponent();
            this.passerelle = passerelleParam;

            //string[] tabx = new string[] { "tournament.id", "tournament.nom", "tournament.joueur" };
            //this.Grid1.ItemsSource = tabx;
            //this.JoueursList = passerelle.HeyJoeuur();
            this.tournList = passerelle.GetAllTournaments();

            this.Grid1.ItemsSource = tournList;

        }

        private void DataGridSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            this.lastSelectedTournament = (Tournament)e.AddedCells[0].Item;
           
        }


        private void Button_Add(object sender, RoutedEventArgs e)
        {
            //passerelle.addScoreToJoueur();
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            //passerelle.editScore();
        }

        private void Button_Refresh(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Export(object sender, RoutedEventArgs e)
        {

        }
    }
}
