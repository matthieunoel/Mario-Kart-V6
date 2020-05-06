using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionMKV6
{
    class Tournament
    {

        private string nom;
        private DateTime date;
        private string modeJeu;
        private string vitesse;
        private bool avecIA;
        private bool enEquipe;
        private Joueur[] joueurs;

        public string Nom { get => nom; set => nom = value; }
        public DateTime Date { get => date; set => date = value; }
        public string ModeJeu { get => modeJeu; set => modeJeu = value; }
        public string Vitesse { get => vitesse; set => vitesse = value; }
        public bool AvecIA { get => avecIA; set => avecIA = value; }
        public bool EnEquipe { get => enEquipe; set => enEquipe = value; }
        internal Joueur[] Joueurs { get => joueurs; set => joueurs = value; }

        public Tournament()
        {
            this.Nom = string.Empty;
            this.Date = date;
            this.ModeJeu = string.Empty;
            this.Vitesse = string.Empty;
            this.AvecIA = false;
            this.EnEquipe = false;
            this.Joueurs = new Joueur[12] { null, null, null, null, null, null, null, null, null, null, null, null };
        }

        public Tournament(string nom, DateTime date, string modeJeu, string vitesse, bool avecIA, bool enEquipe, Joueur[] joueurs)
        {
            this.Nom = nom;
            this.Date = date;
            this.ModeJeu = modeJeu;
            this.Vitesse = vitesse;
            this.AvecIA = avecIA;
            this.EnEquipe = enEquipe;
            this.Joueurs = joueurs;
        }
    }
}
