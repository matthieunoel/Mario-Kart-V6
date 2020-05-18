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
            //this.ListeModeJeu.ItemsSource = passerelle.
            //this.ListeVitesse.ItemsSource = passerelle.

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
        }

        private void Button_Ajouter(object sender, TextChangedEventArgs e)
        {
            //passerelle.AddTournament(new Tournament("TournoiTest", "ModeJeu", "Vitesse", false, true,
            //        new Joueur[8] {
            //            new Joueur("Pseudo", "Perso", "Kart"),
            //            new Joueur("Pseudo", "Perso", "Kart"),
            //            new Joueur("Pseudo", "Perso", "Kart"),
            //            new Joueur("Pseudo", "Perso", "Kart"),
            //            new Joueur("Pseudo", "Perso", "Kart"),
            //            new Joueur("Pseudo", "Perso", "Kart"),
            //            new Joueur("Pseudo", "Perso", "Kart"),
            //           new Joueur("Pseudo", "Perso", "Kart")
            //        }
            //    ));

        }


    }

}
