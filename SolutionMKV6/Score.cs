using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionMKV6
{
    public class Score
    {
        private int id;
        private int numCourse;
        private int valeur;

        public int Id { get => id; set => id = value; }
        public int NumCourse { get => numCourse; set => numCourse = value; }
        public int Valeur { get => valeur; set => valeur = value; }

        public Score()
        {
            this.NumCourse = 0;
            this.Valeur = 0;
        }

        public Score(int numCourse, int score)
        {
            this.NumCourse = numCourse;
            this.Valeur = score;
        }

        public Score(int id, int numCourse, int score)
        {
            this.Id = id;
            this.NumCourse = numCourse;
            this.Valeur = score;
        }

    }
}
