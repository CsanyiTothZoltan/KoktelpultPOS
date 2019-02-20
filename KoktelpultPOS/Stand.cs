using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoktelpultPOS
{
    class Stand
    {
        string italNev;
        double nyitoKeszlet;
        double zaroKeszlet;
        int ar;
        double valosFogyas;
        int valosErtek;
        double gepSzerintiFogyas;
        int gepSzerintiErtek;
        double standElteres;
        int standElteresErteke;

        public string ItalNev { get => italNev; set => italNev = value; }
        public double NyitoKeszlet { get => nyitoKeszlet; set => nyitoKeszlet = value; }
        public double ZaroKeszlet { get => zaroKeszlet; set => zaroKeszlet = value; }
        public int Ar { get => ar; set => ar = value; }
        public double ValosFogyas { get => valosFogyas; set => valosFogyas = value; }
        public int ValosErtek { get => valosErtek; set => valosErtek = value; }
        public double GepSzerintiFogyas { get => gepSzerintiFogyas; set => gepSzerintiFogyas = value; }
        public int GepSzerintiErtek { get => gepSzerintiErtek; set => gepSzerintiErtek = value; }
        public double StandElteres { get => standElteres; set => standElteres = value; }
        public int StandElteresErteke { get => standElteresErteke; set => standElteresErteke = value; }

        public Stand(string italNev, double nyitoKeszlet, double zaroKeszlet, int ar, double valosFogyas, int valosErtek, double gepSzerintiFogyas, int gepSzerintiErtek, double standElteres, int standElteresErteke)
        {
            ItalNev = italNev;
            NyitoKeszlet = nyitoKeszlet;
            ZaroKeszlet = zaroKeszlet;
            Ar = ar;
            ValosFogyas = valosFogyas;
            ValosErtek = valosErtek;
            GepSzerintiFogyas = gepSzerintiFogyas;
            GepSzerintiErtek = gepSzerintiErtek;
            StandElteres = standElteres;
            StandElteresErteke = standElteresErteke;
        }

        public override string ToString()
        {
            return ItalNev;
        }
    }
}
