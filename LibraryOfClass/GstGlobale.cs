using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOfClass
{
    //Ce gestionnaire globale qui n'interagie pas avec la base de données
    //Ce gestionnaire contient toutes les operation de l'application
    public class GstGlobale
    {
        GstBDD gst_bdd;

        private List<Prescrire> lesPrescription;

        public List<Prescrire> LesPrescription { get => lesPrescription; set => lesPrescription = value; }

        public GstGlobale()
        {
            LesPrescription = new List<Prescrire>();
        }

        public void ajouterPrescription(Prescrire laPrescription)
        {
            LesPrescription.Add(laPrescription);
        }
        public void ViderPrescription()
        {
            LesPrescription.Clear();
        }


        //Renvoie le pourcentage de medicament prescrit
        //Le nombre de total Medicament diviser par le le nombre total de prescription
        public float GetPourcentageMedocPrescrit()
        {
            gst_bdd = new GstBDD();
            float prcMedocPrescrit = 0;
            int nbMedoc = gst_bdd.GetNbMedicament();
            int nbPrescrit = gst_bdd.GetNbPrescription();
            prcMedocPrescrit = nbPrescrit / nbMedoc;
            return prcMedocPrescrit;
        }


        //Verifier si le medicament est perturber par un autre dans la liste de medicament recuperer
        //Pour chaque medicament ajouter, si le nouvMedicament ajouter fait partie de sa liste de medicament indesirrable alors retourne True
        //Utiliser dans le bouton ajouter de la page insertion d'une prescription
        public bool verifPerturbation(List<Prescrire> lesmedocPrescrit, Medicament nouvMedicament)
        {
            bool perturber = false;

            foreach(Prescrire laPrescription in lesmedocPrescrit)
            {
                List<Medicament> lesMedicamentNonCompatible = getMedicamentsPerturbateur(laPrescription.LeMedicament.Med_depotlegal);
                foreach (Medicament leMedocNonCompatible in lesMedicamentNonCompatible)
                {
                    if (leMedocNonCompatible.Med_depotlegal == nouvMedicament.Med_depotlegal)
                    {
                        perturber = true;
                    }
                }
            }
            
            return perturber;
        }


        //Renvoie les medicaments perturber par l'id
        public List<Medicament> getMedicamentsPerturbateur(int id_medicament)
        {
            gst_bdd = new GstBDD();
            List<int> lesIds =  gst_bdd.getIdMedicamentsCompatible(id_medicament);
            List<Medicament> lesMedicamentsNonCompatible = new List<Medicament>();

            foreach(int lId in lesIds)
            {
                Medicament leMed = gst_bdd.GetInfosMedicamentById(lId);
                lesMedicamentsNonCompatible.Add(leMed);
            }
            return lesMedicamentsNonCompatible;
        }



        





    }
}
