using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoktelpultPOS
{
    public static class Nyugta
    {
        static List<Alapanyag> alapanyagok;
        static string[] ital;
        static double[] fogyas;
        static List<Koktel> eladott = new List<Koktel>();
        static string label2Kiiras;
        static int label2Ertek;
        static string labelLista;
        static int napiBevetel;

        static Nyugta()
        {

        }

        /// <summary>
        /// A Form1 létrehozásakor megnyitja a napot, létrehozza az ital és fogyas tömböket, nullára állítja a napi bevétel számlálót
        /// </summary>
        public static void Nyitas()
        {
            alapanyagok = ABKezelo.KeszletBeolvasas();
            ital = new string[alapanyagok.Count];
            fogyas = new double[alapanyagok.Count];
            for (int i = 0; i < alapanyagok.Count; i++)
            {
                ital[i] = alapanyagok[i].Megnevezes;
            }
            napiBevetel = 0;
        }

        /// <summary>
        /// Rögzíti az eladott koktélokat, amikből később ki tudja számolni a fogyást és a bevételt
        /// </summary>
        /// <param name="koktel">Az eladott koktél</param>
        public static void Eladas(Koktel koktel)
        {
            eladott.Add(koktel);
        }

        /// <summary>
        /// A Form1-en hozzáadja a label1 felsorolásához az éppen eladott koktél megnevezését és árát
        /// </summary>
        /// <returns>Visszaadja a teljes label1-en megjelenítendő eladott koktélok listáját</returns>
        public static string Label1Frissites()
        {
            labelLista = "";
            foreach (Koktel item in eladott)
            {
                labelLista += $"{item.Megnevezes}  -  {item.Ar}\n\r";
            }
            return labelLista;
        }

        /// <summary>
        /// Frissíti a Form1-en a kiírandó rendelés végösszegét
        /// </summary>
        /// <returns>Visszaadja az aktuálisan eladott koktélok árának végösszegét</returns>
        public static string Label2Frissites()
        {
            label2Kiiras = "";
            label2Ertek = 0;
            foreach (Koktel item in eladott)
            {
                label2Ertek += item.Ar;
            }
            label2Kiiras += $"{label2Ertek} Ft";
            return label2Kiiras;
        }

        /// <summary>
        /// <see langword="abstract"/>rögzített eladott koktélok listája alapján frissíti a napi bevételt és az alapanyagok fogyását
        /// </summary>
        public static void Fizetes()
        {
            foreach (Koktel item in eladott)
            {
                napiBevetel+=item.Ar;

                foreach (Receptura adag in item.Receptura)
                {
                    if (adag.alapanyag!="")
                    {
                        int index = Array.IndexOf(ital, adag.alapanyag);
                        fogyas[index] += adag.mennyiseg;
                    }
                }
            }
            eladott.Clear();
        }

        /// <summary>
        /// Törli az aktuális nyugtát
        /// </summary>
        public static void NyugtaTorlese()
        {
            eladott.Clear();
        }

        /// <summary>
        /// Visszaadja az eladott koktélok listája alapján számított napi össz bevétel összegét
        /// </summary>
        /// <returns>Visszaadja az eladott koktélok listája alapján számított napi össz bevétel összegét</returns>
        public static int BevetelLekerdezes()
        {
            return napiBevetel;
        }

        /// <summary>
        /// Visszaadja a fogyott italok tömbjét
        /// </summary>
        /// <returns>Visszaadja a fogyott italok tömbjét</returns>
        public static string[] FogyasLekerdezesMegnevezesek()
        {
            return ital;
        }

        /// <summary>
        /// Visszaadja a fogyott italok mennyiégeinek tömbjét
        /// </summary>
        /// <returns>Visszaadja a fogyott italok mennyiségeinek tömbjét</returns>
        public static double[] FogyasLekerdezesFogyasok()
        {
            return fogyas;
        }
    }
}
