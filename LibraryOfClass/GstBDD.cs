using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace LibraryOfClass
{
    public class GstBDD
    {
        //Ce gestionnaire est permet toutes les communication avec la base de données
        private MySqlConnection cnx;
        private MySqlCommand cmd;
        private MySqlDataReader dr;


        // Constructeur
        public GstBDD()
        {
            string chaine = "Server=localhost;Database=gsbfilrouge;Uid=root;Pwd=;SslMode=none";
            //string chaine = "Server=https://databases.000webhost.com/index.php;Database=id18098042_gsbfilrouge;Uid=id18098042_projetgsbfilrouge;Pwd=T6g[Z#4~&b&_<Ndo;SslMode=none";
            cnx = new MySqlConnection(chaine);
            cnx.Open();
        }


        //Recupere la totalité des types de Famille dans la Base de données
        public List<Famille> getAllFamille()
        {
            List<Famille> lesFamille = new List<Famille>();
            cmd = new MySqlCommand("SELECT famille.fam_code, famille.fam_libelle FROM famille;", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Famille uneNouvFamille = new Famille(Convert.ToInt16(dr[0]), dr[1].ToString());
                lesFamille.Add(uneNouvFamille);
            }
            dr.Close();
            return lesFamille;
        }


        //Recupere tous les Medicaments dans la Base de données
        public List<Medicament> getAllMedicament()
        {
            List<Medicament> lesMedicaments = new List<Medicament>();
            cmd = new MySqlCommand("SELECT medicament.med_depotlegal, medicament.med_nomcommerciale, medicament.med_composition, medicament.med_effets, medicament.med_contreindic, medicament.med_prixechantillon, famille.fam_code, famille.fam_libelle FROM medicament INNER JOIN famille ON medicament.fam_code = famille.fam_code", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Famille laFamille = new Famille(Convert.ToInt16(dr[6]), dr[7].ToString());
                Medicament unNouvMedicament = new Medicament(Convert.ToInt16(dr[0]), dr[1].ToString(), laFamille, dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), Convert.ToDouble(dr[5]));
                lesMedicaments.Add(unNouvMedicament);
            }
            dr.Close();
            return lesMedicaments;
        }


        //Récupere tous les types d'individus dans la base de données
        public List<Type_Individu> getAllTypeIndividus()
        {
            List<Type_Individu> lesIndividus= new List<Type_Individu>();
            cmd = new MySqlCommand("SELECT type_individu.tin_code, type_individu.tin_libelle FROM type_individu", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Type_Individu unNouvType_Indivu = new Type_Individu(Convert.ToInt16(dr[0]), dr[1].ToString());
                lesIndividus.Add(unNouvType_Indivu);
            }
            dr.Close();
            return lesIndividus;
        }


        //Retourne les medicaments qui ne sont pas compatible avec le medicament selectionner
        public List<int> getIdMedicamentsCompatible(int id_medicament)
        {
            List<int> lesIdMedNonCompatible = new List<int>();
            cmd = new MySqlCommand("SELECT interagir.med_perturbateur FROM interagir WHERE interagir.med_med_perturbe = " + id_medicament, cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lesIdMedNonCompatible.Add(Convert.ToInt16(dr[0]));
            }
            dr.Close();
            return lesIdMedNonCompatible;
        }


        //Récupere le doage dons le code correspond 
        public Dosage GetDosageById(int dose_code)
        {
            Dosage leDosage = null;
            cmd = new MySqlCommand("SELECT dosage.dos_code, dosage.dos_quantite, dosage.dos_unite FROM dosage WHERE dos_code = " + dose_code, cnx);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                leDosage = new Dosage(Convert.ToInt16(dr[0]), Convert.ToInt16(dr[1]), dr[2].ToString());
            }
            dr.Close();
            return leDosage;
        }

        public List<Dosage> GetAllDosage()
        {
            List<Dosage> lesDosages = new List<Dosage>();
            cmd = new MySqlCommand("SELECT dosage.dos_code, dosage.dos_quantite, dosage.dos_unite FROM dosage;", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Dosage leDosage = new Dosage(Convert.ToInt16(dr[0]), Convert.ToInt16(dr[1]), dr[2].ToString());
                lesDosages.Add(leDosage);
            }
            dr.Close();
            return lesDosages;
        }


        // Récupere les informations du Medicament selectionné
        public Medicament GetInfosMedicamentById(int id_medicament)
        {
            Medicament leMedicament = null;//remplire
            cmd = new MySqlCommand("SELECT medicament.med_depotlegal, medicament.med_nomcommerciale, medicament.med_composition, medicament.med_effets, medicament.med_contreindic, medicament.med_prixechantillon, famille.fam_code, famille.fam_libelle FROM medicament INNER JOIN famille ON medicament.fam_code = famille.fam_code WHERE medicament.med_depotlegal = " + id_medicament, cnx);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Famille laFamille = new Famille(Convert.ToInt16(dr[6]), dr[7].ToString());
                leMedicament = new Medicament(Convert.ToInt16(dr[0]), dr[1].ToString(), laFamille, dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), Convert.ToDouble(dr[5]));
            }
            dr.Close();
            return leMedicament;
        }


        //Renvoie le nombre de medicament total dans la base de données
        public int GetNbMedicament()
        {
            int nbMedicament = 0;
            cmd = new MySqlCommand("SELECT COUNT(medicament.med_depotlegal) FROM medicament;", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            nbMedicament = Convert.ToInt32(dr[0]);
            dr.Close();
            return nbMedicament;
        }


        //Renvoie le nombre de prescription total dans la base de données
        public int GetNbPrescription()
        {
            int nbPrescription = 0;
            cmd = new MySqlCommand("SELECT COUNT(*) FROM prescrire;", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            nbPrescription = Convert.ToInt32(dr[0]);
            dr.Close();
            return nbPrescription;
        }


        //Inserer un medicament dans la base de données
        public void AddMedicament(Medicament leMedicament)
        {
            string nomCommercial = leMedicament.Med_nomcommerciale.Replace("'", " ").Replace('"', ' ');
            string composition = leMedicament.Med_composition.Replace("'", " ").Replace('"', ' ');
            string effet = leMedicament.Med_effets.Replace("'", "  ").Replace('"', ' ');
            string contreIndic = leMedicament.Med_contreindic.Replace("'", " ").Replace('"', ' ');
            double prix = leMedicament.Med_prixechantillon;
            //double prix = Convert.ToDouble(leMedicament.Med_prixechantillon.ToString().Replace(",", "."));

            cmd = new MySqlCommand("INSERT INTO `medicament` (`med_depotlegal`, `med_nomcommerciale`, `fam_code`, `med_composition`, `med_effets`, `med_contreindic`, `med_prixechantillon`) VALUES (NULL, '" + nomCommercial + "', '" + leMedicament.LaFamille.Fam_code + "', '" + composition + "', '" + effet + "', '" + contreIndic + "', '" + prix + "');", cnx);
            dr = cmd.ExecuteReader();
            dr.Close();
        }


        //Modifier un medicament dans la base de données
        public void ModifierMedicament(Medicament leMedicament)
        {
            string nomCommercial = leMedicament.Med_nomcommerciale.Replace("'", " ").Replace('"', ' ');
            string composition = leMedicament.Med_composition.Replace("'", " ").Replace('"', ' ');
            string effet = leMedicament.Med_effets.Replace("'", "  ").Replace('"', ' ');
            string contreIndic = leMedicament.Med_contreindic.Replace("'", " ").Replace('"', ' ');
            double prix = leMedicament.Med_prixechantillon;
            //double prix = Convert.ToDouble(leMedicament.Med_prixechantillon.ToString().Replace(",", "."));

            cmd = new MySqlCommand("UPDATE `medicament` SET `med_nomcommerciale`= '"+ nomCommercial +"',`fam_code`= "+ leMedicament.LaFamille.Fam_code +",`med_composition`= '"+ composition +"',`med_effets`= '" + effet + "',`med_contreindic`= '"+ contreIndic +"',`med_prixechantillon`= "+ prix +" WHERE medicament.med_depotlegal = " + leMedicament.Med_depotlegal, cnx);
            dr = cmd.ExecuteReader();
            dr.Close();
        }


        //Inserer un medicament
        public void AddPrescription(Prescrire laPrescription)
        {
            cmd = new MySqlCommand("INSERT INTO `prescrire` (`med_depotlegal`, `tin_code`, `dos_code`, `pre_posologie`) VALUES ('" + laPrescription.LeMedicament.Med_depotlegal + "', '" + laPrescription.LeTypeIndividu.Tin_code + "', '" + laPrescription.LeDosage.Dos_code + "', '" + laPrescription.Pre_posologie +"');", cnx);
            dr = cmd.ExecuteReader();
            dr.Close();
        }

        public void AddTypeIndividus(string leType_libelle)
        {
            cmd = new MySqlCommand("INSERT INTO `type_individu`(`tin_code`, `tin_libelle`) VALUES (null,'"+ leType_libelle + "')", cnx);
            dr = cmd.ExecuteReader();
            dr.Close();
        }

        //Retire un medicament de la liste perturbateur d'un autre medicament
        public void RetirerMedocPerturbateur(int id_medicament_perturber, int id_medicament_perturbateur)
        {
            cmd = new MySqlCommand("DELETE FROM `interagir` WHERE `interagir`.`med_perturbateur` = " + id_medicament_perturbateur + " AND `interagir`.`med_med_perturbe` = " + id_medicament_perturber + ";", cnx);
            dr = cmd.ExecuteReader();
            dr.Close();

        }


        //Ajoute un medicament dans la liste perturbateur d'un autre medicament
        public void AjouterMedocPerturbateur(int id_medicament_perturber, int id_medicament_perturbateur)
        {
            cmd = new MySqlCommand("INSERT INTO `interagir` (`med_perturbateur`, `med_med_perturbe`) VALUES ('" + id_medicament_perturbateur + "', '" + id_medicament_perturber + "');", cnx);
            dr = cmd.ExecuteReader();
            dr.Close();
        }


        //Verifier si le nouveau nom de medicament existe deja dans la base de données
        //Si existe renvoie true, sinon false
        public bool VerifNomExist(string nom_proposer)
        {
            bool exist = false;
            cmd = new MySqlCommand("SELECT medicament.med_depotlegal FROM medicament WHERE medicament.med_nomcommerciale = " + nom_proposer + ";", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            if ( dr.FieldCount != 0 )
            {
                exist = true;
            }
            dr.Close();
            return exist;
        }

        //Recupere les medicaments qui ne sont pas perturbateur du medicament selectionner
        public List<Medicament> GetMedicamentNonPerturbateur(int id_med)
        {
            List<Medicament> lesMedicaments = new List<Medicament>();
            cmd = new MySqlCommand("SELECT medicament.med_depotlegal, medicament.med_nomcommerciale, medicament.med_composition, medicament.med_effets, medicament.med_contreindic, medicament.med_prixechantillon, famille.fam_code, famille.fam_libelle FROM medicament INNER JOIN famille ON medicament.fam_code = famille.fam_code LEFT OUTER JOIN interagir ON medicament.med_depotlegal = interagir.med_med_perturbe WHERE medicament.med_depotlegal NOT IN (SELECT med_perturbateur FROM interagir WHERE interagir.med_med_perturbe = " + id_med + ") ", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            while (dr.Read())
            {
                Famille laFamille = new Famille(Convert.ToInt16(dr[6]), dr[7].ToString());
                Medicament unNouvMedicament = new Medicament(Convert.ToInt16(dr[0]), dr[1].ToString(), laFamille, dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), Convert.ToDouble(dr[5]));
                lesMedicaments.Add(unNouvMedicament);
            }
            dr.Close();
            return lesMedicaments;
        }

        //Modifier une Famille par son Id
        public void ModifierFamilleById(int id_famille, string libelle_famille)
        {
            cmd = new MySqlCommand("UPDATE `famille` SET `fam_libelle` = '" + libelle_famille + "' WHERE `fam_code` = '" + id_famille + "';", cnx);
            dr = cmd.ExecuteReader();
            dr.Close();
        }

        //Ajouter une nouvelle Famille
        public void AddFamille(string libelle_famille)
        {
            cmd = new MySqlCommand("INSERT INTO `famille` (`fam_code`, `fam_libelle`) VALUES (NULL, '" + libelle_famille +"');", cnx);
            dr = cmd.ExecuteReader();
            dr.Close();
        }

        //Modifier le type d'individus par son Id
        public void ModifierTypeIndividusById(int id_type, string libelle_type)
        {
            cmd = new MySqlCommand("UPDATE `type_individu` SET `tin_libelle` = '"+ libelle_type +"' WHERE `type_individu`.`tin_code` = "+ id_type +";", cnx);
            dr = cmd.ExecuteReader();
            dr.Close();
        }

        //Insertion de chaque prescription de la liste recuperer
        public void AddPrescrire(List<Prescrire> lesmedocPrescrit)
        {
            string test = "dz,hd " + lesmedocPrescrit[0].LeMedicament.Med_composition;
            foreach(Prescrire laPrescription in lesmedocPrescrit)
            {

                //string text = "INSERT INTO `prescrire` (`med_depotlegal`, `tin_code`, `dos_code`, `pre_posologie`) VALUES ('" + laPrescription.LeMedicament.Med_depotlegal + "', '" + laPrescription.LeTypeIndividu.Tin_code + "', '" + laPrescription.LeDosage.Dos_code + "', '" + laPrescription.Pre_posologie + "');";
                cmd = new MySqlCommand("INSERT INTO `prescrire` (`med_depotlegal`, `tin_code`, `dos_code`, `pre_posologie`) VALUES ('" + laPrescription.LeMedicament.Med_depotlegal + "', '"+ laPrescription.LeTypeIndividu.Tin_code +"', '"+ laPrescription.LeDosage.Dos_code +"', '"+ laPrescription.Pre_posologie +"');", cnx);
                
                dr = cmd.ExecuteReader();
                dr.Close();
            }
            
        }


    }
}
