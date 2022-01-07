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
    /// Logique d'interaction pour PagePrescription.xaml
    /// </summary>
    public partial class PagePrescription : Page
    {
        public PagePrescription()
        {
            InitializeComponent();
        }

        GstBDD gst;
        GstGlobale gstG;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new GstBDD();
            gstG = new GstGlobale();

            //List<Prescrire> laPrescription = new List<Prescrire>();

            lstMedicaments.ItemsSource = gst.getAllMedicament();
            cboTypeIndividu.ItemsSource = gst.getAllTypeIndividus();
            cboDose.ItemsSource = gst.GetAllDosage();

            lstMedicamentPrescription.ItemsSource = gstG.LesPrescription;
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if(lstMedicaments.SelectedItem != null)
            {
                if(cboDose.SelectedItem != null)
                {
                    if(txtPosologie.Text != "")
                    {
                        if(cboTypeIndividu.SelectedItem != null)
                        {
                            //Verifie si le medicament est pertber par un autre medicament dans les medicament deja ajouter
                            if(!gstG.verifPerturbation(gstG.LesPrescription, lstMedicaments.SelectedItem as Medicament))
                            {
                                Prescrire uneNouvPrescription = new Prescrire(lstMedicaments.SelectedItem as Medicament, cboTypeIndividu.SelectedItem as Type_Individu, cboDose.SelectedItem as Dosage, txtPosologie.Text);
                                gstG.ajouterPrescription(uneNouvPrescription);
                                lstMedicamentPrescription.Items.Refresh();
                            }
                            else
                            {
                                MessageBox.Show("Ce medicament perturbe un autre medicament selectionner", "erreur de compatibilite", MessageBoxButton.OK, MessageBoxImage.Error);

                            }

                        }
                        else
                        {
                            MessageBox.Show("Vous n'avez pas selectionner le type de l'individus", "erreur de selection", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vous n'avez pas saisie la posologie", "erreur de saisies", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vous n'avez pas selectionner le dosage", "erreur de selection", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Vous n'avez pas selectionner de medicament", "erreur de selection", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnPrescire_Click(object sender, RoutedEventArgs e)
        {
            if (gstG.LesPrescription.Count > 0)
            {
                //Insertion dans la BDD :
                gst.AddPrescrire(gstG.LesPrescription);

                MessageBox.Show("La prescription à été enregistrer", "validé", MessageBoxButton.OK);

                //Apres Validation :
                //Vider la Liste de prescription
                gstG.ViderPrescription();
                //Re alimenter la liste
                lstMedicamentPrescription.ItemsSource = gstG.LesPrescription;
            }
            else
            {
                MessageBox.Show("La prescription est vide", "erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
