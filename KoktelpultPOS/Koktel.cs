using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoktelpultPOS
{
    public struct Receptura
    {
        public string alapanyag;
        public double mennyiseg;
    }

    public class Koktel
    {
        string megnevezes;
        int ar;
        Receptura[] receptura = new Receptura[8];
        
        
        public string Megnevezes
        {
            get => megnevezes;
            set => megnevezes = value;
        }

        public int Ar
        {
            get => ar;
            set => ar = value;
        }

        public Receptura[] Receptura
        {
            get => receptura;
            set => receptura = value;
        }

        public Koktel(string megnevezes, int ar, Receptura[] receptura)
        {
            Megnevezes = megnevezes;
            Ar = ar;
            Receptura = receptura;
        }

        public override string ToString()
        {
            return Megnevezes;
        }
    }
}
