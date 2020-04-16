using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace SolutionMKV6
{
    class ClassePasserelle
    {
        //private const string DbString = "va-11 hall-a";
        private string[] listePersonnages;
        public string[] ListePersonnages { get => listePersonnages; set => listePersonnages = value; }

        private string[] listeKarts;
        public string[] ListeKarts { get => listeKarts; set => listeKarts = value; }
        
        //private int testvar { get; set; }

        public ClassePasserelle()
        {
            using (var connection = new SqliteConnection("Data Source=hello.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                "CREATE TABLE IF NOT EXIST tournament('id' INT NOT NULL AUTO_INCREMENT, 'nom' TEXT, 'date' DATETIME, 'modeJeu' TEXT, 'vitesse' TEXT, 'avecIA' BOOLEAN, 'avecEquipe' BOOLEAN, PRIMARY KEY('id') )";
                command.ExecuteNonQuery();

                command = connection.CreateCommand();
                command.CommandText =
                "CREATE TABLE IF NOT EXIST joueur('id' INT NOT NULL AUTO_INCREMENT, 'tournamentId' int, 'nom' TEXT, 'personnage' TEXT, 'kart' TEXT, PRIMARY KEY('id') )";
                command.ExecuteNonQuery();

                command = connection.CreateCommand();
                command.CommandText =
                "CREATE TABLE IF NOT EXIST score('id' INT NOT NULL AUTO_INCREMENT, 'joueurId' int, 'numCourse' int, 'valeur' int, PRIMARY KEY('id') )";
                command.ExecuteNonQuery();

                //command = connection.CreateCommand();
                //command.CommandText =
                //"CREATE TABLE IF NOT EXIST score('id' INT NOT NULL AUTO_INCREMENT, 'joueurId' int, PRIMARY KEY('id') )";
                //command.ExecuteNonQuery();

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



            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool SendTournamentInfoToBase()
        {

            //using (var connection = new SqliteConnection("Data Source=hello.db"))
            //{
            //    connection.Open();

            //    var command = connection.CreateCommand();
            //    command.CommandText =
            //    @"SELECT nameFROM userWHERE id = $id";
            //    command.Parameters.AddWithValue("$id", 1);

            //    using (var reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            var name = reader.GetString(0);

            //            Console.WriteLine($"Hello, {name}!");
            //        }
            //    }
            //}

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Tournament> GetAllTournaments()
        {

            //using (var connection = new SqliteConnection("Data Source=database.db"))
            //{
            //    connection.Open();


            //    var command = connection.CreateCommand();
            //    command.CommandText =
            //    @"SELECT * FROM score";
            //    command.Parameters.AddWithValue("$id", 1);

            //    using (var reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            var name = reader.GetString(0);

            //            Console.WriteLine($"Hello, {name}!");
            //        }
            //    }


            //    command = connection.CreateCommand();
            //    command.CommandText =
            //    @"SELECT * FROM joueur";
            //    command.Parameters.AddWithValue("$id", 1);

            //    using (var reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            var name = reader.GetString(0);

            //            Console.WriteLine($"Hello, {name}!");
            //        }
            //    }


                //command = connection.CreateCommand();
                //command.CommandText =
                //@"SELECT * FROM touranment";
                //command.Parameters.AddWithValue("$id", 1);

                //using (var reader = command.ExecuteReader())
                //{
                //    while (reader.Read())
                //    {
                //        var name = reader.GetString(0);

                //        Console.WriteLine($"Hello, {name}!");
                //    }
                //}
            //}

            return new List<Tournament>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TournamentId"></param>
        /// <returns></returns>
        Tournament GetTournamentInfo(int TournamentId)
        {
            return new Tournament();
        }

        //List<Joueur> GetAllJoueurs()
        //{

        //    using (var connection = new SqliteConnection("Data Source=hello.db"))
        //    {
        //        connection.Open();

        //        var command = connection.CreateCommand();
        //        command.CommandText =
        //        @"SELECT id, nom, perso, kart FROM joueur";
        //        command.Parameters.AddWithValue("$id", 1);

        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                var name = reader.GetString(0);

        //                Console.WriteLine($"Hello, {name}!");
        //            }
        //        }
        //    }
            
        //    return new List<Joueur>();
        //}
    }

}
