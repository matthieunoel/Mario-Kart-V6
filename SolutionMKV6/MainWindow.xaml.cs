using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SolutionMKV6
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClassePasserelle passerelle;
        private List<Tournament> tournamentList;
        private Tournament lastSelectedTournament;



        private void BtnClickAddTournament(object sender, RoutedEventArgs e)
        {
            AddTournament add = new AddTournament(this.passerelle);
            add.Show();
        }

        private void BtnClickSeeTournament(object sender, RoutedEventArgs e)
        {
            SeeTournament see = new SeeTournament(this.passerelle, lastSelectedTournament);
            //this.Content = see.Content;
            see.Show();

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Initialized(object sender, EventArgs e)
        {
            this.passerelle = new ClassePasserelle();
            this.tournamentList = passerelle.GetAllTournaments();
            //this.mainDataGrid.ItemsSource = tournamentList;

            List<TournamentDisplay> TournamentDisplaysList = new List<TournamentDisplay>();

            //foreach (Tournament tournament in tournamentList)
            //{
            //    TournamentDisplaysList.Add(new TournamentDisplay($"{tournament.Nom} -> {tournament.Date}"));
            //}

            for (int i = 0; i < tournamentList.Count; i++)
            {
                TournamentDisplaysList.Add(new TournamentDisplay(i, $"{tournamentList[i].Nom} -> {tournamentList[i].Date}"));
            }

            this.mainDataGrid.ItemsSource = TournamentDisplaysList;

        }

        private void DataGridSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (e.AddedCells.Count > 0)
            {
                //this.lastSelectedTournament = (Tournament)e.AddedCells[0].Item;
                int ligneNb = ((TournamentDisplay)e.AddedCells[0].Item).Index;
                //Console.WriteLine(ligneNb);

                this.lastSelectedTournament = tournamentList[ligneNb];

                Btn_See.IsEnabled = true;
                //MessageBox.Show(selectedTournament.Nom, "DEBUG", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Btn_See.IsEnabled = false;
            }
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            this.tournamentList = passerelle.GetAllTournaments();
            //this.mainDataGrid.ItemsSource = TournamentDisplayList;
            List<TournamentDisplay> TournamentDisplaysList = new List<TournamentDisplay>();

            for (int i = 0; i < tournamentList.Count; i++)
            {
                TournamentDisplaysList.Add(new TournamentDisplay(i, $"{tournamentList[i].Nom} -> {tournamentList[i].Date}"));
            }

            this.mainDataGrid.ItemsSource = TournamentDisplaysList;


        }
    }

    public class TournamentDisplay
    {
        private string nom;
        private int index;

        public TournamentDisplay(int index, string nomTournoi)
        {
            this.Index = index;
            this.Nom = nomTournoi;
        }

        public string Nom { get => nom; set => nom = value; }
        public int Index { get => index; set => index = value; }
    }

}
