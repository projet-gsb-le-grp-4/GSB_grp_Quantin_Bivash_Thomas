using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOfClass
{
    public class Medicament
    {
        private int med_depotlegal;
        private string med_nomcommerciale;
        private Famille laFamille;
        private string med_composition;
        private string med_effets;
        private string med_contreindic;
        private double med_prixechantillon;

        public Medicament(int unMed_depotlegal, string unMed_nomcommerciale, Famille uneFam, string uneMed_compostion, string unMed_effets, string unMed_contreindic, double unMed_prixechantillon)
        {
            Med_depotlegal = unMed_depotlegal;
            Med_nomcommerciale = unMed_nomcommerciale;
            LaFamille = uneFam;
            Med_composition = uneMed_compostion;
            Med_effets = unMed_effets;
            Med_contreindic = unMed_contreindic;
            Med_prixechantillon = unMed_prixechantillon;
        }

        public int Med_depotlegal { get => med_depotlegal; set => med_depotlegal = value; }
        public string Med_nomcommerciale { get => med_nomcommerciale; set => med_nomcommerciale = value; }
        public Famille LaFamille { get => laFamille; set => laFamille = value; }
        public string Med_composition { get => med_composition; set => med_composition = value; }
        public string Med_effets { get => med_effets; set => med_effets = value; }
        public string Med_contreindic { get => med_contreindic; set => med_contreindic = value; }
        public double Med_prixechantillon { get => med_prixechantillon; set => med_prixechantillon = value; }
    }
}
