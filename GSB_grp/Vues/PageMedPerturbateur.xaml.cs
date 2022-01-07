using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibraryOfClass;

namespace GSB_grp.Vues
{
    /// <summary>
    /// Logique d'interaction pour PageMedPerturbateur.xaml
    /// </summary>
    public partial class PageMedPerturbateur : Page
    {
        public PageMedPerturbateur()
        {
            InitializeComponent();
        }

        GstBDD gst;
        GstGlobale gstG;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new GstBDD();
            gstG = new GstGlobale();
            lstMedicaments.ItemsSource = gst.getAllMedicament();

        }

        private void lstMedicaments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstMedicaments.SelectedItem != null)
            {
                lstMedicPerturbateur.ItemsSource = gstG.getMedicamentsPerturbateur((lstMedicaments.SelectedItem as Medicament).Med_depotlegal);
                lstMedicNonPerturbateur.ItemsSource = gst.GetMedicamentNonPerturbateur((lstMedicaments.SelectedItem as Medicament).Med_depotlegal);
            }
        }

        private void lstMedicPerturbateur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btnRetirer_Click(object sender, RoutedEventArgs e)
        {
            if(lstMedicPerturbateur.SelectedItem != null)
            {
                gst.RetirerMedocPerturbateur((lstMedicaments.SelectedItem as Medicament).Med_depotlegal, (lstMedicPerturbateur.SelectedItem as Medicament).Med_depotlegal);
                //lstMedicPerturbateur.Items.Refresh();
                //lstMedicNonPerturbateur.Items.Refresh();
                lstMedicPerturbateur.ItemsSource = gstG.getMedicamentsPerturbateur((lstMedicaments.SelectedItem as Medicament).Med_depotlegal);
                lstMedicNonPerturbateur.ItemsSource = gst.GetMedicamentNonPerturbateur((lstMedicaments.SelectedItem as Medicament).Med_depotlegal);
            }
            else
            {
                MessageBox.Show("Selectionner le medicament que vous voulez retirer", "Erreur selection", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (lstMedicNonPerturbateur.SelectedItem != null)
            {
                gst.AjouterMedocPerturbateur((lstMedicaments.SelectedItem as Medicament).Med_depotlegal, (lstMedicNonPerturbateur.SelectedItem as Medicament).Med_depotlegal);
                //lstMedicPerturbateur.Items.Refresh();
                //lstMedicNonPerturbateur.Items.Refresh();
                lstMedicPerturbateur.ItemsSource = gstG.getMedicamentsPerturbateur((lstMedicaments.SelectedItem as Medicament).Med_depotlegal);
                lstMedicNonPerturbateur.ItemsSource = gst.GetMedicamentNonPerturbateur((lstMedicaments.SelectedItem as Medicament).Med_depotlegal);
            }
            else
            {
                MessageBox.Show("Selectionner le medicament que vous voulez retirer", "Erreur selection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
