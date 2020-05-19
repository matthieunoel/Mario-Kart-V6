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
        private ClassePasserelle passerelle;
      
        public SeeTournament(ClassePasserelle passerelleParam)
        {
            InitializeComponent();
            this.passerelle = passerelleParam;

            //string[] tabx = new string[] { "tournament.id", "tournament.nom", "tournament.joueur" };
            //this.Grid1.ItemsSource = tabx;
            //this.JoueursList = passerelle.HeyJoeuur();
            

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            


            //AdventureWorksLT2008Entities advenWorksEntities = new AdventureWorksLT2008Entities();

            //ObjectQuery<Customer> customers = advenWorksEntities.Customers;

            //var query =
            //from customer in customers
            //orderby customer.CompanyName
            //select new
            //{
            //    Tournament.Nom,
            //    customer.FirstName,
            //    customer.CompanyName,
            //    customer.Title,
            //    customer.EmailAddress,
            //    customer.Phone,
            //    customer.SalesPerson
            //};

            //Grid1.ItemsSource = query.ToList();
        }


        private void Button_Add(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            //var id = Convert.ToInt32(DgEmp.Rows[e.RowIndex].Cells[2].Value.ToString());
            //if (id != 0)
            //{
            //    // Delete query on basis of id
            //    GridBind();
            //    ClearData();
            //}
        }

        private void Button_Refresh(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Export(object sender, RoutedEventArgs e)
        {

        }
    }
}
