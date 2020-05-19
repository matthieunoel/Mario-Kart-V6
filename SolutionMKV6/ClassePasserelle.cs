using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Windows;

namespace SolutionMKV6
{
    public class ClassePasserelle
    {
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
            try
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

                this.ListePersonnages = new string[25] {
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

                this.ListeKarts = new string[31] {
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

                this.Vitesses = new string[4]
                {
                "50Cc",
                "100Cc",
                "150Cc",
                "Miroir"
                };

                this.ModesJeu = new string[4]
                {
                "Grand Prix",
                "Contre-la-montre",
                "Course VS",
                "Bataille"
                };
                
                #region Specs

                Random rnd = new Random();

                if (rnd.Next(0, 100) + 1 == 11)
                {
                    MessageBox.Show("Avant de commencer, le groupe vous invite a faire des recherche sur le va-11 hall-a.",
                                   "DEBUG",
                                   MessageBoxButton.OK,
                                   MessageBoxImage.Information);
                }

                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est intervenue lors de l'initialisation : {ex.Message}",
                                   "Erreur d'initialisation",
                                   MessageBoxButton.OK,
                                   MessageBoxImage.Error);

                Application.Current.Shutdown();
            }
        }

        /// <summary>
        /// Permet de récupérer tout les tournois de la base, leurs joueurs des tournois, ainsi que les scores des joueurs.
        /// </summary>
        /// <returns>Une liste des tournois de la base</returns>
        public List<Tournament> GetAllTournaments()
        {

            List<Tournament> ListeTournament = new List<Tournament>();

            try
            {
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
                                            scores.Add(new Score((int)readerScore.GetInt64(0), (int)readerScore.GetInt64(1)));
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Un erreur est apparue lors de la récupération des donées : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                throw ex;
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

        /// <summary>
        /// Permet d'ajouter un tournois en base, ainsi que ces joueurs (Attention ! Les scores des joueurs ne sont pas pris en compte !).
        /// </summary>
        /// <param name="tournament">Le tournois à ajouter en base</param>
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

        /// <summary>
        /// Permet d'ajouter un score à un joueur
        /// </summary>
        /// <param name="joueur">Le joueur concerné par le score</param>
        /// <param name="score">Le score à ajouter au joueur</param>
        /// <returns>L'id du score ajouté. A implémenter au score (style "score.Id = passerelle.addScoreToJoueur(joueurn score)" )</returns>
        public int addScoreToJoueur(Joueur joueur, Score score)
        {
            try
            {
                #region Guard clauses

                if (!(joueur.Id >= 0))
                {
                    throw new Exception($"joueur.Id isn't valid ({joueur.Id.ToString()})");
                }

                #endregion

                int scoreId = 0;


                using (var connection = new SqliteConnection($"Data Source={this.filePath}"))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText =
                    $"INSERT INTO score (joueurId, numCourse, valeur) VALUES ({joueur.Id}, {score.NumCourse}, {score.Valeur})";
                    command.ExecuteNonQuery();

                    command.CommandText = "select last_insert_rowid()";

                    scoreId = (int)(Int64)command.ExecuteScalar();

                    connection.Close();

                }

                return scoreId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est apparue : {ex.Message}",
                                   "Erreur",
                                   MessageBoxButton.OK,
                                   MessageBoxImage.Error);
                throw;
            }
        }

        //public void HeyJoeuur(Joueur joueur)
        //{
        //    using (SqliteConnection connection = new SqliteConnection($"Data Source={this.filePath}"))
        //    {
        //        connection.Open();

        //        var command = connection.CreateCommand();
        //        command.CommandText =
        //        $"select * from joueur ";
        //        command.ExecuteNonQuery();

        //        connection.Close();
        //    }

        //}


        /// <summary>
        /// Permet d'éditer le score d'un joueur à partir de l'ID du score.
        /// </summary>
        /// <param name="score">Le score à modifier</param>
        public void editScore(Score score)
        {

            try
            {
                #region Guard clauses

                if (!(score.Id >= 0))
                {
                    throw new Exception($"score.Id isn't valid ({score.Id.ToString()})");
                }

                #endregion

                using (var connection = new SqliteConnection($"Data Source={this.filePath}"))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText =
                    $"UPDATE score SET numCourse={score.NumCourse}, valeur={score.Valeur} WHERE id={score.Id}";
                    command.ExecuteNonQuery();

                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est apparue : {ex.Message}",
                                   "Erreur",
                                   MessageBoxButton.OK,
                                   MessageBoxImage.Error);
                throw;
            }
        }
    }

}
