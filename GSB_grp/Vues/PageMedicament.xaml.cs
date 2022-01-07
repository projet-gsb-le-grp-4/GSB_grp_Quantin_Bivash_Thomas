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
    /// Logique d'interaction pour PageMedicament.xaml
    /// </summary>
    public partial class PageMedicament : Page
    {
        public PageMedicament()
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

        private void lstMedicament_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstMedicaments.SelectedItem != null)
            {
                //Medicament infosMecament = new Medicament()
                txtNom.Text = "Nom Commercial : " + (lstMedicaments.SelectedItem as Medicament).Med_nomcommerciale;
                txtFamille.Text = "Type de Famille : " + (lstMedicaments.SelectedItem as Medicament).LaFamille.Fam_libelle;
                txtEffet.Text = "Les effets : " + (lstMedicaments.SelectedItem as Medicament).Med_effets;
                txtComposition.Text = "Composition : " + (lstMedicaments.SelectedItem as Medicament).Med_composition;
                txtContreIndique.Text = (lstMedicaments.SelectedItem as Medicament).Med_contreindic;
            }
            else
            {
                MessageBox.Show("Selectionner le medicament que vous voulez retirer", "Erreur selection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnModif_Click(object sender, RoutedEventArgs e)
        {
            //faire les verification avant
            if (lstMedicaments.SelectedItem != null)
            {
                new FenetreModifierMed(lstMedicaments.SelectedItem as Medicament).Show();
            }
            else
            {
                MessageBox.Show("Selectionner le medicament que vous voulez retirer", "Erreur selection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnIns_Click(object sender, RoutedEventArgs e)
        {
            new FenetreAjouterMed().Show();
        }
    }
}
