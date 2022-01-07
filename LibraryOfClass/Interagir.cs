using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOfClass
{
    public class Interagir
    {
        private Medicament med_perturbateur;
        private Medicament med_med_perturbe;

        public Interagir(Medicament unPertubateur, Medicament unMedPertube)
        {
            Med_perturbateur = unPertubateur;
            Med_med_perturbe = unMedPertube;
        }

        public Medicament Med_perturbateur { get => med_perturbateur; set => med_perturbateur = value; }
        public Medicament Med_med_perturbe { get => med_med_perturbe; set => med_med_perturbe = value; }
    }
}
