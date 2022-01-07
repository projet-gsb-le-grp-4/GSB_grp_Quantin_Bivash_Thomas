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
    /// Logique d'interaction pour PageTypesIndividus.xaml
    /// </summary>
    public partial class PageTypesIndividus : Page
    {
        GstBDD gst;
        public PageTypesIndividus()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new GstBDD();
            lstTypeIndividus.ItemsSource = gst.getAllTypeIndividus();
        }

        private void lstTypeIndividus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstTypeIndividus.SelectedItem != null)
            {
                txtModification.Text = (lstTypeIndividus.SelectedItem as Type_Individu).Tin_libelle;
            }
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            if(lstTypeIndividus.SelectedItem != null)
            {
                if (txtModification.Text != "")
                {
                    gst.ModifierTypeIndividusById((lstTypeIndividus.SelectedItem as Type_Individu).Tin_code, txtModification.Text);
                    MessageBox.Show("Le type de famille a été modifier", "Reussit", MessageBoxButton.OK, MessageBoxImage.Information);
                    //lstTypeIndividus.Items.Refresh();
                    lstTypeIndividus.ItemsSource = gst.getAllTypeIndividus();

                }
                else
                {
                    MessageBox.Show("Vous n'avez pas saisie le nom de la famille", "erreur de saisies", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Vous n'avez pas selectionner le type de famille a modifier", "erreur de selection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if(txtAjouter.Text != "")
            {
                gst.AddTypeIndividus(txtAjouter.Text);
                MessageBox.Show("Le Nouveau type de famille a été ajouter", "Reussit", MessageBoxButton.OK, MessageBoxImage.Information);
                //lstTypeIndividus.Items.Refresh();
                lstTypeIndividus.ItemsSource = gst.getAllTypeIndividus();

            }
            else
            {
                MessageBox.Show("Vous n'avez pas saisie le nom de la famille", "erreur de saisies", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }
    }
}
