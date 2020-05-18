using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionMKV6
{
    public class Joueur
    {
        private string nom;
        private string personnage;
        private string kart;
        private List<Score> scores ;

        public string Nom { get => nom; set => nom = value; }
        public string Personnage { get => personnage; set => personnage = value; }
        public string Kart { get => kart; set => kart = value; }
        internal List<Score> Scores { get => scores; set => scores = value; }
        
        public Joueur()
        {
            this.Nom = string.Empty;
            this.Personnage = string.Empty;
            this.Kart = string.Empty;
            this.Scores = new List<Score>();
        }

        public Joueur(string nom, string personnage, string kart)
        {
            this.Nom = nom;
            this.Personnage = personnage;
            this.Kart = kart;
            this.Scores = new List<Score>();
        }

        public Joueur(string nom, string personnage, string kart, List<Score> scores)
        {
            this.Nom = nom;
            this.Personnage = personnage;
            this.Kart = kart;
            this.Scores = scores;
        }
    }
}
