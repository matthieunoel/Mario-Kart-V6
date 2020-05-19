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
        private Tournament tournamentRecent;

        public SeeTournament(ClassePasserelle passerelleParam, Tournament tournament)
        {
            InitializeComponent();
            this.passerelle = passerelleParam;
            this.tournamentRecent = tournament;
            MessageBox.Show(tournament.Nom);

            //string[] tabx = new string[] { "tournament.id", "tournament.nom", "tournament.joueur" };
            //this.Grid1.ItemsSource = tabx;
            //this.JoueursList = passerelle.HeyJoeuur();
            //this.tournList = passerelle.GetAllTournaments();
            this.Grid1.ItemsSource = tournamentRecent.Joueurs;
            
        }

        private void DataGridSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            //this.lastSelectedTournament = (Tournament)e.AddedCells[0].Item;
           
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            //Score scar = new Score(, 100);
            //passerelle.addScoreToJoueur(scar);
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            Score score1 = new Score(2, 500);

            passerelle.editScore(score1);
        }

        private void Button_Refresh(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Export(object sender, RoutedEventArgs e)
        {

        }

    }
}
