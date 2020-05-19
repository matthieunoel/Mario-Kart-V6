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

            //for (int i = 0; i < 8; i++)
            //{
            //    JoueurTable[i] = new Joueur(string.Empty, "-", "-");
            //}

            this.MonDataGrid.ItemsSource = JoueurTable;

            for (int i = 0; i < 8; i++)
            {
                //JoueurTable[i].SelectedItem = a;
            }


        }

        private void Button_Ajouter1(object sender, RoutedEventArgs e)
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
            }

            if (ListeModeJeu.SelectedItem == null)
            {
                MessageBox.Show("Attention vous n'avez pas rentree toutes les donnees necessaires.", "Mode de jeu non renseigné", MessageBoxButton .OK, MessageBoxImage .Warning);
            }

            Joueur[] TableJoueurs = this.MonDataGrid.ItemsSource.Cast<Joueur>().ToArray();

            passerelle.AddTournament(new Tournament(Nom_du_tournoi.Text, ListeModeJeu.SelectedItem.ToString(), ListeVitesse.SelectedItem.ToString(), avecIA, parEquipe, TableJoueurs));

        }



        private void Button_Retour(object sender, RoutedEventArgs e)
        {
            this.Content = Content;
        }



        //Pas 2 meme perso sinon message box "attention"
        //Verifier les caractères interdit dans le nommage du jeu pour pas d'erreur avec requete sql





    }

}
