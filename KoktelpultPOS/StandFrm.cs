using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoktelpultPOS
{
    public partial class StandFrm : Form
    {
        List<Alapanyag> italok = ABKezelo.KeszletBeolvasas();
        List<Stand> standlap = new List<Stand>();
        List<Stand> elteresek = new List<Stand>();
        int sorszam = 0;
        double zaroKeszlet;
        string[] gepSzerintiFogyasMegnevezes = Nyugta.FogyasLekerdezesMegnevezesek();
        double[] gepSzerintiFogyasMennyiseg = Nyugta.FogyasLekerdezesFogyasok();
        DateTime datum = DateTime.Today;
        string datumString;
        string elteresekString = "";
        int osszElteres = 0;


        public StandFrm()
        {
            InitializeComponent();
            LabelBeallitas();
            datum = datum.AddDays(-1);
            datumString = DatumSzoveg(datum);
        }

        private void StandFrm_Load(object sender, EventArgs e)
        {
            try
            {
                ABKezelo.Csatlakozas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Csatlakozási hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LabelBeallitas()
        {
            label1.Text = italok[sorszam].Megnevezes;
            label2.Text = "";
            button1.Enabled = false;
        }

        /// <summary>
        /// Megerősítés kérése után rögzíti a beírt zárókészletet, majd kiszámolja a gép szerinti és a valós fogyás közötti eltérés mértékét és értékét. Amikor az utolsó tétel is rögzítve lett, meghívja az ABKezelo vonatkozó függvényeit, kiírja az eltéréseket, majd bezárja a programot.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Biztos véglegesíti az aktuális zárókészletet?\n\n\r{label1.Text} - {label2.Text} liter", "Zárókészlet rögzítése", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (label2.Text[label2.Text.Length - 1] == ',')
                {
                    label2.Text += "0";
                }
                double nyitoKeszlet = Math.Round(italok[sorszam].NyitoKeszlet, 2);
                zaroKeszlet = Math.Round(double.Parse(label2.Text), 2);
                int ar = italok[sorszam].Ar;
                double valosFogyas = Math.Round((nyitoKeszlet - zaroKeszlet), 2);
                int valosErtek = (int)(valosFogyas * ar);
                double gepSzerintiFogyas = gepSzerintiFogyasMennyiseg[Array.IndexOf(gepSzerintiFogyasMegnevezes, label1.Text)];
                int gepSzerintiErtek = (int)(gepSzerintiFogyas * ar);
                double standElteres = Math.Round((gepSzerintiFogyas - valosFogyas), 2);
                int standElteresErteke = (int)(standElteres * ar);

                standlap.Add(new Stand(italok[sorszam].Megnevezes, nyitoKeszlet, zaroKeszlet, ar, valosFogyas, valosErtek, gepSzerintiFogyas, gepSzerintiErtek, standElteres, standElteresErteke));

                if (standElteres != 0)
                {
                    elteresekString += $"{italok[sorszam].Megnevezes}, eltérés: {standElteres}, értéke: {standElteresErteke}\n\n\r";
                    osszElteres += standElteresErteke;
                }

                sorszam++;

                if (sorszam < italok.Count)
                {
                    LabelBeallitas();
                }
                else
                {
                    ABKezelo.StandAB(datumString);
                    ABKezelo.StandRogzitese(standlap, datumString);

                    elteresekString += $"ÖSSZES ELTÉRÉS ÉRTÉKE: {osszElteres} Forint\n\n\rLEADANDÓ BEVÉTEL:{Nyugta.BevetelLekerdezes()} Forint\n\n\r(Adatok kinyomtatása blokknyomtatón - hardver hiányában nem kerül bemutatásra)";

                    MessageBox.Show(elteresekString, "Zárás", MessageBoxButtons.OK, MessageBoxIcon.None);

                    ABKezelo.KapcsolatBontasa();

                    Application.DoEvents();
                    Application.Exit();
                }
            }
        }

        /// <summary>
        /// Amennyiben van beírva bármilyen érték, engedélyezi a "Zárókészlet rögzítése" gomb használatát
        /// </summary>
        private void label2_TextChanged(object sender, EventArgs e)
        {
            if (label2.Text != "")
            {
                button1.Enabled = true;
            }
        }

        /// <summary>
        /// A lenyomott gomb értékét hozzáadja a label2-n kijelzett értékhez
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            label2.Text += (sender as Button).Text;
        }

        /// <summary>
        /// Amennyiben a label2 értéke már tartalmaz tizedesvesszőt, nem csinál semmit. Ha még nincs semmilyen érték beírva "0," értékkel írja ki, amennyiben már van kijelzett szám, utána rakja a tizedesvesszőt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            if (!label2.Text.Contains(","))
            {
                if (label2.Text.Length > 0)
                {
                    label2.Text += ",";
                }
                else
                {
                    label2.Text += "0,";
                }
            }
        }

        /// <summary>
        /// Kitörli a kijelzett érték utolsó karakterét
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button13_Click(object sender, EventArgs e)
        {
            if (label2.Text != "")
            {
                label2.Text = label2.Text.Substring(0, label2.Text.Length - 1);
            }
        }

        /// <summary>
        /// Stringként adja vissza az Aktuális dátumot, hogy az adatbáziskezelő fel tudja dolgozni
        /// </summary>
        /// <param name="datum"></param>
        /// <returns></returns>
        private string DatumSzoveg(DateTime datum)
        {
            string konvert = datum.ToString();
            konvert = konvert.Replace(" ", string.Empty);
            konvert = konvert.Replace(".", "_");
            konvert = konvert.Remove(10);

            return konvert;
        }
    }
}
