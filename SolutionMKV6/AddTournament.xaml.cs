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
    /// Logique d'interaction pour AddTournament.xaml
    /// </summary>
    public partial class AddTournament : Window
    {
        private ClassePasserelle passerelle;

        public AddTournament(ClassePasserelle passerelle)
        {
            InitializeComponent();
            this.passerelle = passerelle;

            
            this.ListeKart.ItemsSource = passerelle.ListeKarts;
            this.ListePerso.ItemsSource = passerelle.ListePersonnages;
            this.ListeModeJeu.ItemsSource = passerelle.ModesJeu;
            this.ListeVitesse.ItemsSource = passerelle.Vitesses;

            Joueur Moi = new Joueur();
            Joueur Moi2 = new Joueur();
            Joueur Moi3 = new Joueur();
            Joueur Moi4 = new Joueur();
            Joueur Moi5 = new Joueur();
            Joueur Moi6 = new Joueur();
            Joueur Moi7 = new Joueur();
            Joueur Moi8 = new Joueur();

            Joueur[] JoueurTable = new Joueur[8] { Moi, Moi2, Moi3, Moi4, Moi5, Moi6, Moi7, Moi8 };

            this.MonDataGrid.ItemsSource = JoueurTable;

            for (int i = 0; i < 8; i++)
            {
                //JoueurTable[i].SelectedItem = a;
            }


        }

        private void Button_Ajouter1(object sender, RoutedEventArgs e)
        {
            try
            { 
                bool parEquipe;
                bool avecIA;
                if (ParEquipeCheck.IsChecked.Value == true)
                {
                    parEquipe = true;
                }
                else
                {
                    parEquipe = false;
                }

                if (AvecIACheck.IsChecked.Value == true)
                {
                    avecIA = true;
                }
                else
                {
                    avecIA = false;
                }

                if (ListeVitesse.SelectedItem == null)
                {
                    MessageBox.Show("Attention vous n'avez pas rentree toutes les donnees necessaires.", "Vitesse non Renseignée", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (ListeModeJeu.SelectedItem == null)
                {
                    MessageBox.Show("Attention vous n'avez pas rentree toutes les donnees necessaires.", "Mode de jeu non renseigné", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                Joueur[] TableJoueurs = this.MonDataGrid.ItemsSource.Cast<Joueur>().ToArray();

                for (int i = 0; i < TableJoueurs.Length; i++)
                {
                    if (TableJoueurs.Contains(TableJoueurs[i]) == true)
                    {
                        MessageBox.Show("Attention, vous avez rentré la même valeur dans le tableau", "Doublons dans le tableau", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;
                    }
                }

                if ((Nom_du_tournoi.Text).Contains("&") == true || (Nom_du_tournoi.Text).Contains("é") == true || (Nom_du_tournoi.Text).Contains("~") == true || (Nom_du_tournoi.Text).Contains("\"") == true || (Nom_du_tournoi.Text).Contains("#") == true || (Nom_du_tournoi.Text).Contains("'") == true || (Nom_du_tournoi.Text).Contains("{") == true || (Nom_du_tournoi.Text).Contains("(") == true || (Nom_du_tournoi.Text).Contains("[") == true || (Nom_du_tournoi.Text).Contains("-") == true || (Nom_du_tournoi.Text).Contains("|") == true || (Nom_du_tournoi.Text).Contains("è") == true || (Nom_du_tournoi.Text).Contains("`") == true || (Nom_du_tournoi.Text).Contains("_") == true || (Nom_du_tournoi.Text).Contains("\\") == true || (Nom_du_tournoi.Text).Contains("ç") == true || (Nom_du_tournoi.Text).Contains("^") == true || (Nom_du_tournoi.Text).Contains("à") == true || (Nom_du_tournoi.Text).Contains("@") == true || (Nom_du_tournoi.Text).Contains(")") == true || (Nom_du_tournoi.Text).Contains("]") == true || (Nom_du_tournoi.Text).Contains("=") == true || (Nom_du_tournoi.Text).Contains("}") == true || (Nom_du_tournoi.Text).Contains("^") == true || (Nom_du_tournoi.Text).Contains("¨") == true || (Nom_du_tournoi.Text).Contains("°") == true || (Nom_du_tournoi.Text).Contains("+") == true || (Nom_du_tournoi.Text).Contains("$") == true || (Nom_du_tournoi.Text).Contains("£") == true || (Nom_du_tournoi.Text).Contains("¤") == true || (Nom_du_tournoi.Text).Contains("ù") == true || (Nom_du_tournoi.Text).Contains("%") == true || (Nom_du_tournoi.Text).Contains("*") == true || (Nom_du_tournoi.Text).Contains("µ") == true || (Nom_du_tournoi.Text).Contains(",") == true || (Nom_du_tournoi.Text).Contains("?") == true || (Nom_du_tournoi.Text).Contains(";") == true || (Nom_du_tournoi.Text).Contains(".") == true || (Nom_du_tournoi.Text).Contains(":") == true || (Nom_du_tournoi.Text).Contains("/") == true || (Nom_du_tournoi.Text).Contains("!") == true || (Nom_du_tournoi.Text).Contains("§") == true)
                {
                    MessageBox.Show("Attention, vous avez rentré un mauvais caractère pour le nom du Tournoi", "Nom du tournoi", MessageBoxButton.OK, MessageBoxImage.Warning);
                }


                passerelle.AddTournament(new Tournament(Nom_du_tournoi.Text, ListeModeJeu.SelectedItem.ToString(), ListeVitesse.SelectedItem.ToString(), avecIA, parEquipe, TableJoueurs));



            }
            catch (Exception ex)
            {
                MessageBox.Show($"Il y a eu une erreur : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void Button_Retour(object sender, RoutedEventArgs e)
        {
            //this.Content = this.previousPage.Content;

            //this.Content = this.previousPage.savedContent.Content;

            //MessageBox.Show("Bite", "Message de bite poilue tro drol");
            
            this.Content = (new MainWindow()).Content;
            Application.Current.Run();
            Application.Current.Shutdown();
        }

    }

}
