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

namespace ProjetBibliotheque
{
    /// <summary>
    /// Logique d'interaction pour frmClient.xaml
    /// </summary>
    public partial class frmClient : Window
    {
        bibliothequeEntities gst;
        utilisateur monUtilisateur;
        public frmClient(bibliothequeEntities unGst, utilisateur unUtilisateur)
        {
            InitializeComponent();
            gst = unGst;
            monUtilisateur = unUtilisateur;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtBonjour.Text = "Content de vous revoir " + monUtilisateur.login;
            lstLivres.ItemsSource = gst.livre.ToList();
        }

        private void btnReserver_Click(object sender, RoutedEventArgs e)
        {
            livre leLivre = gst.livre.ToList().Find(li => li.idLivre == (lstLivres.SelectedItem as livre).idLivre);
            reserver laReservation = gst.reserver.ToList().Find(re => re.utilisateur == monUtilisateur && re.livre == leLivre);
            if(laReservation == null)
            {
                reserver maReservation = new reserver()
                {
                    livre = (lstLivres.SelectedItem as livre),
                    utilisateur = monUtilisateur,
                    dateRemise = DateTime.Now,
                    dateReserve = DateTime.Now.AddDays(14)
                };
                gst.reserver.Add(maReservation);
                gst.SaveChanges();
                MessageBox.Show("Vous avez réservé " + (lstLivres.SelectedItem as livre).titre, "Livre réservé", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Impossible de réserver 2 fois le même livre", "Livre déjà réservé", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            livre leLivre = gst.livre.ToList().Find(li => li.idLivre == (lstLivres.SelectedItem as livre).idLivre);
            genrelivre leGenre = leLivre.genrelivre;
            themelivre leTheme = leLivre.themelivre;
            MessageBox.Show("Nom: " + leLivre.titre + 
                "\r\nAuteur : " + leLivre.auteur +
                "\r\nGenre : " + leGenre.libelleGenre +
                "\r\nTheme : " + leTheme.libelleTheme +
                "\r\nQuantité disponible: " + leLivre.quantite, "Informations du livre", MessageBoxButton.OK);
        }

        private void btnProfil_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
