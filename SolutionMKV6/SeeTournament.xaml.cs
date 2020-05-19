using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


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
            //MessageBox.Show(tournament.Nom);

            //string[] tabx = new string[] { "tournament.id", "tournament.nom", "tournament.joueur" };
            //this.Grid1.ItemsSource = tabx;
            //this.JoueursList = passerelle.HeyJoeuur();
            //this.tournList = passerelle.GetAllTournaments();

            List<JoueurDisplay> JoueurDisplayList = new List<JoueurDisplay>();

            foreach (Joueur joueur in tournamentRecent.Joueurs)
            {
                JoueurDisplayList.Add(new JoueurDisplay($"{joueur.Nom} ({joueur.Personnage}/{joueur.Kart})"));
            }

            this.Grid1.ItemsSource = JoueurDisplayList;
            //this.Grid1.ItemsSource = tournamentRecent.Joueurs;



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

            // TODO : Check des valeures

            List<JoueurDisplay> JoueurDisplayList = new List<JoueurDisplay>();
            JoueurDisplayList = (List<JoueurDisplay>)this.Grid1.ItemsSource;

            for (int i = 0; i < tournamentRecent.Joueurs.Length; i++)
            {
                List<Score> listeDesScores = new List<Score>();
                if (JoueurDisplayList[i].Score1 != string.Empty && JoueurDisplayList[i].Score1 != null)
                {
                    listeDesScores.Add(new Score(1, Int32.Parse(JoueurDisplayList[i].Score1)));
                }
                if (JoueurDisplayList[i].Score2 != string.Empty && JoueurDisplayList[i].Score2 != null)
                {
                    listeDesScores.Add(new Score(2, Int32.Parse(JoueurDisplayList[i].Score2)));
                }
                if (JoueurDisplayList[i].Score3 != string.Empty && JoueurDisplayList[i].Score3 != null)
                {
                    listeDesScores.Add(new Score(3, Int32.Parse(JoueurDisplayList[i].Score3)));
                }
                if (JoueurDisplayList[i].Score4 != string.Empty && JoueurDisplayList[i].Score4 != null)
                {
                    listeDesScores.Add(new Score(4, Int32.Parse(JoueurDisplayList[i].Score4)));
                }
                tournamentRecent.Joueurs[i].Scores = listeDesScores;
            }

            try
            {
                this.tournamentRecent = passerelle.updateTournament(this.tournamentRecent);
                MessageBox.Show($"La sauvegarde s'est affectuée avec succès.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est apparue lors de la sauvegarde : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            

        }

        private void Button_Refresh(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Export(object sender, RoutedEventArgs e)
        {

        }

    }

    public class JoueurDisplay
    {
        private string nom;
        private string score1;
        private string score2;
        private string score3;
        private string score4;

        public JoueurDisplay(string nomParam)
        {
            this.Nom = nomParam;
            score1 = string.Empty;
            score2 = string.Empty;
            score3 = string.Empty;
            score4 = string.Empty;
        }

        public string Nom { get => nom; set => nom = value; }
        public string Score1 { get => score1; set => score1 = value; }
        public string Score2 { get => score2; set => score2 = value; }
        public string Score3 { get => score3; set => score3 = value; }
        public string Score4 { get => score4; set => score4 = value; }
    }
}
