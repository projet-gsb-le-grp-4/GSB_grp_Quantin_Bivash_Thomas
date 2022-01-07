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
using System.Windows.Shapes;
using LibraryOfClass;

namespace GSB_grp.Vues
{
    /// <summary>
    /// Logique d'interaction pour FenetreModifierMed.xaml
    /// </summary>
    public partial class FenetreModifierMed : Window
    {
        public FenetreModifierMed(Medicament leMedicament)
        {
            InitializeComponent();

            txtNomCommerciale.Text = leMedicament.Med_nomcommerciale;
            txtPrix.Text = leMedicament.Med_prixechantillon.ToString();
            txtEffet.Text = leMedicament.Med_effets;
            txtContreIndic.Text = leMedicament.Med_contreindic;
            txtCompo.Text = leMedicament.Med_composition;
            cboFamille.SelectedIndex = leMedicament.LaFamille.Fam_code;

            idMed.Text = leMedicament.Med_depotlegal.ToString();//Poussiere
        }

        GstBDD gst;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new GstBDD();
            cboFamille.ItemsSource = gst.getAllFamille();
        }
        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            if (txtNomCommerciale.Text != "")
            {
                if (txtPrix.Text != "")
                {
                    if (txtEffet.Text != "")
                    {
                        if (txtCompo.Text != "")
                        {
                            if (cboFamille.SelectedItem != null)
                            {
                                if (txtContreIndic.Text != "")
                                {
                                    //Ajout
                                    Famille laFamille = new Famille((cboFamille.SelectedItem as Famille).Fam_code, (cboFamille.SelectedItem as Famille).Fam_libelle);
                                    Medicament medicamentSaisie = new Medicament(Convert.ToInt32(idMed.Text), txtNomCommerciale.Text, laFamille, txtCompo.Text, txtEffet.Text, txtContreIndic.Text, Convert.ToDouble(txtPrix.Text));
                                    gst.ModifierMedicament(medicamentSaisie);
                                    //MessageBox.Show(test.ToString(), "oui");
                                    MessageBox.Show("Le medicament a été ajouter", "Reussit", MessageBoxButton.OK, MessageBoxImage.Information);
                                    //MessageBox.Show(medicamentSaisie.LaFamille.Fam_libelle, "Reussit", MessageBoxButton.OK, MessageBoxImage.Information);
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Vous n'avez pas saisie les contre indications", "erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Vous n'avez pas selectionner la familles", "erreur de selection", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vous n'avez pas saisie la composition", "erreur de saisies", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vous n'avez pas saisie les effets", "erreur de saisies", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vous n'avez pas saisie le prix", "erreur de saisies", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Vous n'avez pas saisie le nom", "erreur de saisies", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


    }
}
