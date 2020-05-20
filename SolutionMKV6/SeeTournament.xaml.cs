using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
                Score[] ScoresJoueur = new Score[4];

                foreach (var score in joueur.Scores)
                {
                    ScoresJoueur[score.NumCourse - 1] = score;
                }

                for (int i = 0; i < ScoresJoueur.Length; i++)
                {
                    if (ScoresJoueur[i] == null)
                    {
                        ScoresJoueur[i] = new Score();
                    }
                }

                JoueurDisplayList.Add(new JoueurDisplay($"{joueur.Nom}\n({joueur.Personnage}/{joueur.Kart})", ScoresJoueur[0], ScoresJoueur[1], ScoresJoueur[2], ScoresJoueur[3]));
            }

            this.Grid1.ItemsSource = JoueurDisplayList;
            //this.Grid1.ItemsSource = tournamentRecent.Joueurs;

            this.Title = $"Gestionnaire des tournois : consultation de \"{tournamentRecent.Nom}\"";
            this.LblNom.Content = "Nom du tournoi : " + tournamentRecent.Nom;
            this.LblDate.Content = "Date : " + tournamentRecent.Date.ToString();
            this.LblModeJeu.Content = "Mode de jeu : " + tournamentRecent.ModeJeu;
            this.LblVitesse.Content = "Vitesse : " + tournamentRecent.Vitesse;

            if (tournamentRecent.EnEquipe)
            {
                this.LblEnEquipe.Content = "Tournoi par équipe";
            }
            else
            {
                this.LblEnEquipe.Content = "Tournoi chacun pour soi";
            }

            if (tournamentRecent.AvecIA)
            {
                this.LblAvecIA.Content = "Tournoi avec IA";
            }
            else
            {
                this.LblAvecIA.Content = "Tournoi sans IA";
            }



        }

        private void DataGridSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            //this.lastSelectedTournament = (Tournament)e.AddedCells[0].Item;

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

            JoueurDisplayList = new List<JoueurDisplay>();

            foreach (Joueur joueur in tournamentRecent.Joueurs)
            {
                Score[] ScoresJoueur = new Score[4];

                foreach (var score in joueur.Scores)
                {
                    ScoresJoueur[score.NumCourse - 1] = score;
                }

                for (int i = 0; i < ScoresJoueur.Length; i++)
                {
                    if (ScoresJoueur[i] == null)
                    {
                        ScoresJoueur[i] = new Score();
                    }
                }

                JoueurDisplayList.Add(new JoueurDisplay($"{joueur.Nom}\n({joueur.Personnage}/{joueur.Kart})", ScoresJoueur[0], ScoresJoueur[1], ScoresJoueur[2], ScoresJoueur[3]));
            }

            this.Grid1.ItemsSource = JoueurDisplayList;

            try
            {
                this.tournamentRecent = passerelle.updateTournamentScores(this.tournamentRecent);
                MessageBox.Show($"La sauvegarde s'est affectuée avec succès.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est apparue lors de la sauvegarde : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void Button_Export(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Fichier CSV (*.csv)|*.csv|Fichier JSON (*.json)|*.json;*.JSON",
                Title = "Exportation des résultats"
            };
            if ((bool)sfd.ShowDialog())
            {
                try
                {

                    if (File.Exists(sfd.FileName))
                    {
                        File.Delete(sfd.FileName);
                    }

                    if (sfd.FileName.EndsWith(".json", StringComparison.CurrentCultureIgnoreCase))
                    {
                        File.WriteAllText(sfd.FileName, passerelle.generateJSON(tournamentRecent));
                    }
                    else if (sfd.FileName.EndsWith(".csv", StringComparison.CurrentCultureIgnoreCase))
                    {
                        File.WriteAllText(sfd.FileName, passerelle.generateCSV(tournamentRecent));
                    }
                    else
                    {
                        throw new Exception($"Erreur dans le chemin d'accès : \"{sfd.FileName}\"");
                    }

                    MessageBox.Show("La sauvegarde s'est effectuée avec succès.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Une erreur est apparue lors de la sauvegarde : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

    }

    public class JoueurDisplay
    {
        private string nom;
        private string score1;
        private string score2;
        private string score3;
        private string score4;
        private int total;

        //public JoueurDisplay(string nomParam)
        //{
        //    this.Nom = nomParam;
        //}

        public JoueurDisplay(string nomParam, Score score1, Score score2, Score score3, Score score4)
        {
            this.Nom = nomParam;

            if (score1 != (new Score()))
            {
                this.Score1 = score1.Valeur.ToString();
            }
            else
            {
                this.score1 = string.Empty;
            }

            if (score2 != (new Score()))
            {
                this.Score2 = score2.Valeur.ToString();
            }
            else
            {
                this.score1 = string.Empty;
            }

            if (score3 != (new Score()))
            {
                this.Score3 = score3.Valeur.ToString();
            }
            else
            {
                this.score1 = string.Empty;
            }

            if (score4 != (new Score()))
            {
                this.Score4 = score4.Valeur.ToString();
            }
            else
            {
                this.score1 = string.Empty;
            }

            this.Total = score1.Valeur + score2.Valeur + score3.Valeur + score4.Valeur;
        }

        public string Nom { get => nom; set => nom = value; }
        public string Score1 { get => score1; set => score1 = value; }
        public string Score2 { get => score2; set => score2 = value; }
        public string Score3 { get => score3; set => score3 = value; }
        public string Score4 { get => score4; set => score4 = value; }
        public int Total { get => total; set => total = value; }
    }
}
