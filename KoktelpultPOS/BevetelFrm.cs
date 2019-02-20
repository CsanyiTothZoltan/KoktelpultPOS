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
    public partial class BevetelFrm : Form
    {
        string megnevezes;
        double bevetelezes;
        double keszlet;
        double ujMennyiseg;
        List<Alapanyag> italok;

        public BevetelFrm()
        {
            InitializeComponent();
            italok = ABKezelo.KeszletBeolvasas();
            LbFrissites();
            LabelBeallitas();
        }

        /// <summary>
        /// Lezárja a bevételezést, végrehajtja a fentmaradó feladatokat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
        }

        /// <summary>
        /// Amennyiben van valós érték beírva, engedélyezi a "Bevételezés rögzítése" gomb használatát
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_TextChanged(object sender, EventArgs e)
        {
            if (label1.Text != "" && label1.Text != ",")
            {
                button14.Enabled = true;
            }
        }

        /// <summary>
        /// A lenyomott gomb értékét hozzáadja a label1-en kijelzett értékhez
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            label1.Text += (sender as Button).Text;
        }

        /// <summary>
        /// Amennyiben a label1 értéke már tartalmaz tizedesvesszőt, nem csinál semmit. Ha még nincs semmilyen érték beírva "0," értékkel írja ki, amennyiben már van kijelzett szám, utána rakja a tizedesvesszőt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            if (!label1.Text.Contains(","))
            {
                if (label1.Text.Length > 0)
                {
                    label1.Text += ",";
                }
                else
                {
                    label1.Text += "0,";
                }
            }
        }

        /// <summary>
        ///  Kitörli a kijelzett érték utolsó karakterét
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button13_Click(object sender, EventArgs e)
        {
            if (label1.Text != "")
            {
                label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
            }
        }

        /// <summary>
        /// Rögzíti a bevételezést, a nyitókészlet és a bevételezés összeadásával kiszámolja az új, aktuális készletet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            if (label1.Text != "")
            {
                if (label1.Text[label1.Text.Length-1] == ',')
                {
                    label1.Text += "0";
                }
                megnevezes = listBox1.SelectedItem.ToString();
                keszlet = ((Alapanyag)listBox1.SelectedItem).NyitoKeszlet;
                bevetelezes = double.Parse(label1.Text);
                ujMennyiseg = keszlet + bevetelezes;
                if (MessageBox.Show($"Biztos véglegesíti az aktuális bevételezést?\n\n\r{megnevezes} - {bevetelezes} liter", "Bevételezés rögzítése", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ABKezelo.Bevetelezes(megnevezes, ujMennyiseg);
                    LabelBeallitas();
                }
            }
        }

        /// <summary>
        /// Beállítja a listbox adatforrását
        /// </summary>
        private void LbFrissites()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = italok;
        }

        /// <summary>
        /// Alaphelyzetbe állítja a label-t, letiltja a "Bevétel rögzítése" gombot
        /// </summary>
        private void LabelBeallitas()
        {
            label1.Text = "";
            button14.Enabled = false;
        }

        /// <summary>
        /// Megerősítést kér a form bezárására, amennyiben nem kapja meg, megszakítja a bezárást
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BevetelFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Biztosan végzett a bevételezéssel?\n\n\rAmennyiben visszatér a főképernyőre, a mai napon már nincs lehetősége bevételezésre!", "Visszatérés a főképernyőre", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
