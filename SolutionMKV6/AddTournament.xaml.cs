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

            //On fournit les listes aux combo box
            this.ListeKart.ItemsSource = passerelle.ListeKarts;
            this.ListePerso.ItemsSource = passerelle.ListePersonnages;
            this.ListeModeJeu.ItemsSource = passerelle.ModesJeu;
            this.ListeVitesse.ItemsSource = passerelle.Vitesses;

            //on crée les nouveaux joueurs
            Joueur Moi = new Joueur();
            Joueur Moi2 = new Joueur();
            Joueur Moi3 = new Joueur();
            Joueur Moi4 = new Joueur();
            Joueur Moi5 = new Joueur();
            Joueur Moi6 = new Joueur();
            Joueur Moi7 = new Joueur();
            Joueur Moi8 = new Joueur();

            //on met tous les joueurs dans un tableau
            Joueur[] JoueurTable = new Joueur[8] { Moi, Moi2, Moi3, Moi4, Moi5, Moi6, Moi7, Moi8 };

            //on dit que le datagrid est constitué du tableau de joueur, donc chaque joueur du tableau ajoutera une ligne du datagrid
            this.MonDataGrid.ItemsSource = JoueurTable;

        }

        private void Button_Ajouter1(object sender, RoutedEventArgs e)
        {
            try
            { 
                bool parEquipe; //Instanciation de la variable de l'état de la checkbox du choix "Par Equipe"
                bool avecIA; //Instanciation de la variable de l'état de la checkbox du choix "Avec IA"

                //Determination de l'état de la checkbox Par Equipe
                if (ParEquipeCheck.IsChecked.Value == true)
                {
                    parEquipe = true;
                }
                else
                {
                    parEquipe = false;
                }

                //Determination de l'état de la checkbox Avec IA
                if (AvecIACheck.IsChecked.Value == true)
                {
                    avecIA = true;
                }
                else
                {
                    avecIA = false;
                }

                //Message d'erreur si la vitesse n'a pas été séléctionnée
                if (ListeVitesse.SelectedItem == null)
                {
                    MessageBox.Show("Attention vous n'avez pas rentree toutes les donnees necessaires.", "Vitesse non Renseignée", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                //Message d'erreur si le mode de jeu n'a pas été séléctionné
                if (ListeModeJeu.SelectedItem == null)
                {
                    MessageBox.Show("Attention vous n'avez pas rentree toutes les donnees necessaires.", "Mode de jeu non renseigné", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                //Les pseudo, Personnage et Kart des 8 joueurs sont enregistré dans un tableau TableJoueurs
                Joueur[] TableJoueurs = this.MonDataGrid.ItemsSource.Cast<Joueur>().ToArray();

                //Determination et annulation de la confirmation de l'ajout en cas de doublons dans le tableau 
                int i, j;
                int doublon = 0;
                for (i = 0, j = 1; j < TableJoueurs.Length; j++)
                {
                    if (TableJoueurs[i] != TableJoueurs[j])
                    {
                        i++;
                        if (i != j)
                        {
                            doublon++;
                        }
                    }
                }

                if (doublon > 0)
                {
                    MessageBox.Show("Attention, vous avez rentré la même valeur dans le tableau", "Doublons dans le tableau", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                    
                

                //Determination et annulation de la confirmation de l'ajout en cas de caractères spéciaux dans le nom du tournoi
                if ((Nom_du_tournoi.Text).Contains("&") == true || (Nom_du_tournoi.Text).Contains("é") == true || (Nom_du_tournoi.Text).Contains("~") == true || (Nom_du_tournoi.Text).Contains("\"") == true || (Nom_du_tournoi.Text).Contains("#") == true || (Nom_du_tournoi.Text).Contains("'") == true || (Nom_du_tournoi.Text).Contains("{") == true || (Nom_du_tournoi.Text).Contains("(") == true || (Nom_du_tournoi.Text).Contains("[") == true || (Nom_du_tournoi.Text).Contains("-") == true || (Nom_du_tournoi.Text).Contains("|") == true || (Nom_du_tournoi.Text).Contains("è") == true || (Nom_du_tournoi.Text).Contains("`") == true || (Nom_du_tournoi.Text).Contains("_") == true || (Nom_du_tournoi.Text).Contains("\\") == true || (Nom_du_tournoi.Text).Contains("ç") == true || (Nom_du_tournoi.Text).Contains("^") == true || (Nom_du_tournoi.Text).Contains("à") == true || (Nom_du_tournoi.Text).Contains("@") == true || (Nom_du_tournoi.Text).Contains(")") == true || (Nom_du_tournoi.Text).Contains("]") == true || (Nom_du_tournoi.Text).Contains("=") == true || (Nom_du_tournoi.Text).Contains("}") == true || (Nom_du_tournoi.Text).Contains("^") == true || (Nom_du_tournoi.Text).Contains("¨") == true || (Nom_du_tournoi.Text).Contains("°") == true || (Nom_du_tournoi.Text).Contains("+") == true || (Nom_du_tournoi.Text).Contains("$") == true || (Nom_du_tournoi.Text).Contains("£") == true || (Nom_du_tournoi.Text).Contains("¤") == true || (Nom_du_tournoi.Text).Contains("ù") == true || (Nom_du_tournoi.Text).Contains("%") == true || (Nom_du_tournoi.Text).Contains("*") == true || (Nom_du_tournoi.Text).Contains("µ") == true || (Nom_du_tournoi.Text).Contains(",") == true || (Nom_du_tournoi.Text).Contains("?") == true || (Nom_du_tournoi.Text).Contains(";") == true || (Nom_du_tournoi.Text).Contains(".") == true || (Nom_du_tournoi.Text).Contains(":") == true || (Nom_du_tournoi.Text).Contains("/") == true || (Nom_du_tournoi.Text).Contains("!") == true || (Nom_du_tournoi.Text).Contains("§") == true)
                {
                    MessageBox.Show("Attention, vous avez rentré un mauvais caractère pour le nom du Tournoi", "Nom du tournoi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                //Envoi des données en cas d'appuie sur le bouton Confirmer
                passerelle.AddTournament(new Tournament(Nom_du_tournoi.Text, ListeModeJeu.SelectedItem.ToString(), ListeVitesse.SelectedItem.ToString(), avecIA, parEquipe, TableJoueurs));
                MessageBox.Show("Votre ajout a bien été confirmé.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();



            }
            //Exception
            catch (Exception ex)
            {
                MessageBox.Show($"Il y a eu une erreur : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        //Bouton retour qui ferme la fenêtre
        private void Button_Retour(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }

}
