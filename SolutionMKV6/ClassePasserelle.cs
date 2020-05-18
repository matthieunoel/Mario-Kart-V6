using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Windows;

namespace SolutionMKV6
{
    public class ClassePasserelle
    {
        //private const string DbString = "va-11 hall-a";
        private string filePath = "data.db";

        private string[] listePersonnages;
        public string[] ListePersonnages { get => listePersonnages; set => listePersonnages = value; }

        private string[] listeKarts;
        public string[] ListeKarts { get => listeKarts; set => listeKarts = value; }

        private string[] vitesses;
        public string[] Vitesses { get => vitesses; set => vitesses = value; }

        private string[] modesJeu;
        public string[] ModesJeu { get => modesJeu; set => modesJeu = value; }

        public ClassePasserelle()
        {
            using (var connection = new SqliteConnection($"Data Source={this.filePath}"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                "CREATE TABLE IF NOT EXISTS tournament('id' INTEGER PRIMARY KEY AUTOINCREMENT , 'nom' TEXT, 'date' DATETIME, 'modeJeu' TEXT, 'vitesse' TEXT, 'avecIA' BOOLEAN, 'avecEquipe' BOOLEAN)";
                command.ExecuteNonQuery();

                command = connection.CreateCommand();
                command.CommandText =
                "CREATE TABLE IF NOT EXISTS joueur('id' INTEGER PRIMARY KEY AUTOINCREMENT , 'tournamentId' int, 'nom' TEXT, 'personnage' TEXT, 'kart' TEXT)";
                command.ExecuteNonQuery();

                command = connection.CreateCommand();
                command.CommandText =
                "CREATE TABLE IF NOT EXISTS score('id' INTEGER PRIMARY KEY AUTOINCREMENT , 'joueurId' int, 'numCourse' int, 'valeur' int)";
                command.ExecuteNonQuery();

                //command = connection.CreateCommand();
                //command.CommandText =
                //"INSERT INTO tournament (nom, date, modeJeu, vitesse, avecIA, avecEquipe) VALUES ('TournoiTest', datetime('now', 'localtime'), 'ModeJeuTest', '12.798Cc', false, false)";
                //command.ExecuteNonQuery();

                connection.Close();

            }

            this.listePersonnages = new string[25] {
                   "Baby Mario",
                    "Baby Peach",
                    "Bowser",
                    "Donkey Kong",
                    "Koopa Troopa",
                    "Luigi",
                    "Mario",
                    "Peach",
                    "Toad",
                    "Waluigi",
                    "Wario",
                    "Yoshi",
                    "Baby Daisy",
                    "Baby Luigi",
                    "Birdo",
                    "Bowser Jr.",
                    "Daisy",
                    "Diddy Kong",
                    "Dry Bones",
                    "Dry Bowser",
                    "Funky Kong",
                    "King Boo",
                    "Mii",
                    "Rosalina",
                    "Toadette"
                };

            this.listeKarts = new string[31] {
                    "Standard Kart S",
                    "Booster Seat",
                    "Mini Beast",
                    "Standard Kart M",
                    "Classic Dragster",
                    "Wild Wing",
                    "Standard Kart L",
                    "Offroader",
                    "Flame Flyer",
                    "Standard Bike S",
                    "Bullet Bike",
                    "Bit Bike",
                    "Standard Bike M",
                    "Mach Bike",
                    "Standard Bike L",
                    "Wario Bike",
                    "Flame Runner",
                    "Tiny Titan",
                    "Cheep Charger",
                    "Blue Falcon",
                    "Daytripper",
                    "Super Blooper",
                    "Piranha Prowler",
                    "Honeycoupe",
                    "Quacker",
                    "Jet Bubble",
                    "Dolphin Dasher",
                    "Sneakster",
                    "Zip Zip",
                    "Shooting Star",
                    "Phantom"
                };

            this.vitesses = new string[4]
            {
                "50Cc",
                "100Cc",
                "150Cc",
                "Miroir"
            };

            this.modesJeu = new string[4]
            {
                "Grand Prix",
                "Contre-la-montre",
                "Course VS",
                "Bataille"
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Tournament> GetAllTournaments()
        {

            List<Tournament> ListeTournament = new List<Tournament>();

            using (var connection = new SqliteConnection($"Data Source={this.filePath}"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                "SELECT id, nom, date, modeJeu, vitesse, avecIA, avecEquipe FROM tournament";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Joueur[] TabJoueurs = new Joueur[8];
                        int i = 0;
                        command = connection.CreateCommand();
                        command.CommandText =
                            $"SELECT id, nom, personnage, kart FROM joueur WHERE tournamentId={reader.GetInt64(0)}";
                        using (var readerJoueur = command.ExecuteReader())
                        {
                            while (readerJoueur.Read())
                            {

                                List<Score> scores = new List<Score>();

                                command = connection.CreateCommand();
                                command.CommandText =
                                    $"SELECT numCourse, valeur FROM score WHERE joueurId={readerJoueur.GetInt64(0)}";
                                using (var readerScore = command.ExecuteReader())
                                {
                                    while (readerScore.Read())
                                    {
                                        scores.Add( new Score((int)readerScore.GetInt64(0), (int)readerScore.GetInt64(1)) );
                                    }
                                }

                                TabJoueurs[i] = new Joueur(readerJoueur.GetString(1), readerJoueur.GetString(2), readerJoueur.GetString(3));
                                i++;
                            }
                        }

                        ListeTournament.Add(new Tournament(reader.GetString(1), reader.GetDateTime(2), reader.GetString(3), reader.GetString(4), reader.GetBoolean(5), reader.GetBoolean(6), TabJoueurs));
                    }
                }

                connection.Close();

            }

            return ListeTournament;

            //List<Tournament> ListeTest = new List<Tournament>();
            //Joueur[] TabJoueurs = new Joueur[4];
            //TabJoueurs[0] = new Joueur("Nom test1", "Personnage test1", "Kart test1");
            //TabJoueurs[1] = new Joueur("Nom test2", "Personnage test2", "Kart test2");
            //TabJoueurs[2] = new Joueur("Nom test3", "Personnage test3", "Kart test3");
            //TabJoueurs[3] = new Joueur("Nom test4", "Personnage test4", "Kart test4");
            //ListeTest.Add(new Tournament("TournoiTest1", new DateTime(), "Mode de Jeu Test", "Vitesse test", false,  false, TabJoueurs));

            //return ListeTest;
        }

        public void AddTournament(Tournament tournament)
        {
            using (var connection = new SqliteConnection($"Data Source={this.filePath}"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                $"INSERT INTO tournament (nom, date, modeJeu, vitesse, avecIA, avecEquipe) VALUES ('{tournament.Nom}', datetime('now', 'localtime'), '{tournament.ModeJeu}', '{tournament.Vitesse}', {tournament.AvecIA}, {tournament.EnEquipe})";
                command.ExecuteNonQuery();


                command.CommandText = "select last_insert_rowid()";

                Int64 LastRowID64 = (Int64)command.ExecuteScalar();


                foreach (Joueur joueur in tournament.Joueurs)
                {
                    command = connection.CreateCommand();
                    command.CommandText =
                    $"INSERT INTO joueur (tournamentId, nom, personnage, kart) VALUES ({(int)LastRowID64}, '{joueur.Nom}', '{joueur.Personnage}', '{joueur.Kart}');";
                    command.ExecuteNonQuery();
                }

                connection.Close();

            }
        }

        public void addScoreToJoueur()
        {

        }

        public void editScore()
        {

        }
    }

}
