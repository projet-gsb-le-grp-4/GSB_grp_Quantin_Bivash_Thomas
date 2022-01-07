using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOfClass
{
    public class Dosage
    {
        private int dos_code;
        private int dos_quantite;
        private string dos_unite;

        public Dosage(int unCode, int uneQuantite, string uneUnite)
        {
            Dos_code = unCode;
            Dos_quantite = uneQuantite;
            Dos_unite = uneUnite;
        }

        public int Dos_code { get => dos_code; set => dos_code = value; }
        public int Dos_quantite { get => dos_quantite; set => dos_quantite = value; }
        public string Dos_unite { get => dos_unite; set => dos_unite = value; }
    }
}
