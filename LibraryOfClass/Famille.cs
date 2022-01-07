using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOfClass
{
    public class Famille
    {
        private int fam_code;
        private string fam_libelle;

        public Famille(int une_fam_code, string une_fam_libelle)
        {
            Fam_code = une_fam_code;
            Fam_libelle = une_fam_libelle;
        }

        public int Fam_code { get => fam_code; set => fam_code = value; }
        public string Fam_libelle { get => fam_libelle; set => fam_libelle = value; }
    }
}
