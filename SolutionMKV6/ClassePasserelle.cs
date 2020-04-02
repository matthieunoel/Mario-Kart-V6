using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace SolutionMKV6
{
    class ClassePasserelle
    {
        private const string DbString = "va-11 hall-a";

        private int testvar { get; set; }

        public ClassePasserelle()
        {
            using (var connection = new SqliteConnection("Data Source=hello.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"SELECT nameFROM userWHERE id = $id";
                command.Parameters.AddWithValue("$id", 1);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader.GetString(0);

                        Console.WriteLine($"Hello, {name}!");
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool SendTournamentInfoToBase()
        {

            using (var connection = new SqliteConnection("Data Source=hello.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"SELECT nameFROM userWHERE id = $id";
                command.Parameters.AddWithValue("$id", 1);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader.GetString(0);

                        Console.WriteLine($"Hello, {name}!");
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Tournament> GetAllTournaments()
        {
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
    }

    class Tournament
    {

    }


}
