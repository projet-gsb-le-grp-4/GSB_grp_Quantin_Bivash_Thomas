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
    /// Logique d'interaction pour PageTest.xaml
    /// </summary>
    public partial class PageTest : Page
    {
        public PageTest()
        {
            InitializeComponent();
        }
        GstBDD gst;
        GstGlobale gstG;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new GstBDD();
            gstG = new GstGlobale();

            //lstBoxTest.ItemsSource = gst.getAllMedicament();

            //lstBoxTest2.ItemsSource = gst.getAllFamille();

            //text1.Text = gst.GetNbMedicament().ToString();
            //text2.Text = gst.GetNbPrescription().ToString();
            //text2.Text = gstG.GetPourcentageMedocPrescrit().ToString();

        }
    }
}
