using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoktelpultPOS
{
    public class Alapanyag
    {
        string megnevezes;
        double nyitoKeszlet;
        int ar;

        public string Megnevezes { get => megnevezes; set => megnevezes = value; }
        public double NyitoKeszlet { get => nyitoKeszlet; set => nyitoKeszlet = value; }
        public int Ar { get => ar; set => ar = value; }

        public Alapanyag(string megnevezes, double nyitoKeszlet, int ar)
        {
            Megnevezes = megnevezes;
            NyitoKeszlet = nyitoKeszlet;
            Ar = ar;
        }

        public override string ToString()
        {
            return Megnevezes;
        }
    }
}
