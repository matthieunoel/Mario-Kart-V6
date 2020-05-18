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
    /// Logique d'interaction pour SeeTournament.xaml
    /// </summary>
    public partial class SeeTournament : Window
    {
        protected ClassePasserelle passerelle;
        public SeeTournament(ClassePasserelle passerelleParam)
        {
            InitializeComponent();
            this.passerelle = passerelleParam;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            AddTournament add = new AddTournament(passerelle);
            this.Content = add.Content; 
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Refresh(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Export(object sender, RoutedEventArgs e)
        {
            //private List<string> ConvertDataToStringList()
            //{

            //    #region Guard clauses...



            //    if (this._ListeData.Count < 1)
            //    {
            //        throw new Exception("_ListeData est vide");
            //    }



            //    #endregion
            //    // On ajoute le première ligne, 
            //    List<string> DataText = new List<string>
            //{
            //    "id; nom; date; modeJeu; vitesse; avecIA; avecEquipe;"
            //};



            //    // On ajoute toutes les suivantes selon les données
            //    foreach (var data in this._ListeData)
            //    {
            //        DataText.Add($"{data.id}; {data.nom}; {data.date}; {data.modeJeu}; {data.vitesse}; {data.avecIA}; {data.Equipe}");
            //    }




            }
        }
}
