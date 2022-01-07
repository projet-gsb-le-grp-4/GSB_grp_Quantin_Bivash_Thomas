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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GSB_grp.Vues;
using LibraryOfClass;

namespace GSB_grp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageAcceuil();
            //Main.Content = new PageTest();
        }

        private void btnStatistique_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PagesStatistique();
        }

        private void btnTypeIndividus_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageTypesIndividus();
        }

        private void btnMedicaments_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageMedicament();
        }

        private void btnPrescription_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PagePrescription();
        }

        private void btnMedocPerturbateur_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageMedPerturbateur();
        }




    }
}
