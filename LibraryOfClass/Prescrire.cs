using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOfClass
{
    public class Prescrire
    {
        private Medicament leMedicament;
        private Type_Individu leTypeIndividu;
        private Dosage leDosage;
        private string pre_posologie;

        public Prescrire(Medicament unMedicament, Type_Individu unTypeIndividu, Dosage unDosage, string uneProsologie)
        {
            LeMedicament = unMedicament;
            LeTypeIndividu = unTypeIndividu;
            LeDosage = unDosage;
            Pre_posologie = uneProsologie;
        }

        public Medicament LeMedicament { get => leMedicament; set => leMedicament = value; }
        public Type_Individu LeTypeIndividu { get => leTypeIndividu; set => leTypeIndividu = value; }
        public Dosage LeDosage { get => leDosage; set => leDosage = value; }
        public string Pre_posologie { get => pre_posologie; set => pre_posologie = value; }
    }
}
