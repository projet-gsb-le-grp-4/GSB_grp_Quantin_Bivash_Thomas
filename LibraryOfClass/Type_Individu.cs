using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOfClass
{
    public class Type_Individu
    {
        private int tin_code;
        private string tin_libelle;

        public Type_Individu(int unTin_code, string unTin_libelle)
        {
            Tin_code = unTin_code;
            Tin_libelle = unTin_libelle;
        }

        public int Tin_code { get => tin_code; set => tin_code = value; }
        public string Tin_libelle { get => tin_libelle; set => tin_libelle = value; }
    }
}
