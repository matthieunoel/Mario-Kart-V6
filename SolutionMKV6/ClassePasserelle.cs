﻿using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace SolutionMKV6
{
    public class ClassePasserelle
    {
        //private const string DbString = "va-11 hall-a";
        private string[] listePersonnages;
        public string[] ListePersonnages { get => listePersonnages; set => listePersonnages = value; }

        private string[] listeKarts;
        public string[] ListeKarts { get => listeKarts; set => listeKarts = value; }
        
        //private int testvar { get; set; }

        public ClassePasserelle()
        {
            using (var connection = new SqliteConnection("Data Source=data.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                "CREATE TABLE IF NOT EXISTS tournament('id' INT PRIMARY KEY, 'nom' TEXT, 'date' DATETIME, 'modeJeu' TEXT, 'vitesse' TEXT, 'avecIA' BOOLEAN, 'avecEquipe' BOOLEAN)";
                command.ExecuteNonQuery();

                command = connection.CreateCommand();
                command.CommandText =
                "CREATE TABLE IF NOT EXISTS joueur('id' INT PRIMARY KEY, 'tournamentId' int, 'nom' TEXT, 'personnage' TEXT, 'kart' TEXT)";
                command.ExecuteNonQuery();

                command = connection.CreateCommand();
                command.CommandText =
                "CREATE TABLE IF NOT EXISTS score('id' INT PRIMARY KEY, 'joueurId' int, 'numCourse' int, 'valeur' int)";
                command.ExecuteNonQuery();

                //command = connection.CreateCommand();
                //command.CommandText =
                //"CREATE TABLE IF NOT EXISTS score('id' INT NOT NULL AUTO_INCREMENT, 'joueurId' int, PRIMARY KEY('id') )";
                //command.ExecuteNonQuery();

                command = connection.CreateCommand();
                command.CommandText =
                "INSERT INTO tournament (nom, date, modeJeu, vitesse, avecIA, avecEquipe) VALUES ('TournoiTest', date('now'), 'ModeJeuTest', '12.798Cc', false, false)";
                command.ExecuteNonQuery();

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
        public List<Tournament> GetAllTournaments()
        {

            List<Tournament> ListeTournament = new List<Tournament>();

            using (var connection = new SqliteConnection("Data Source=data.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                "SELECT nom, date, modeJeu, vitesse, avecIA, avecEquipe FROM tournament";
                //command.ExecuteNonQuery();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader.GetString(0);
                        Console.WriteLine(name);
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
