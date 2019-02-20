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
    public partial class Form1 : Form
    {
        List<Koktel> koktelok;

        public Form1()
        {
            InitializeComponent();
            Nyugta.Nyitas();
            timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
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

        /// <summary>
        /// Automatikusan az aktuális felbontáshoz méretezi a gombokat és labeleket
        /// </summary>
        private void GombAtmeretezes()
        {
            koktelok = ABKezelo.Beolvasas();
            int szamlalo = 0;
            int i = 0;
            Control[] gombok = new Control[39];

            foreach (Control item in Controls)
            {
                if (item is Button)
                {
                    item.Text = "";
                    gombok[i] = item;
                    i++;
                }
            }

            Array.Sort(gombok, (x, y) => x.TabIndex.CompareTo(y.TabIndex));

            button37.Text = "Zárás";
            button36.Text = "Törlés";
            button38.Text = "Nyugta";
            button39.Text = "Bevételezés";

            foreach (Control item in gombok)
            {
                if (item is Button)
                {
                    item.Width = Size.Width / 6 - 25;
                    item.Height = Size.Height / 8 - 25;
                    item.Font = new Font(Font.FontFamily, item.Height / 5);
                    if (koktelok.Count > szamlalo)
                    {
                        item.Text = koktelok[szamlalo].Megnevezes;
                        item.Tag = koktelok[szamlalo];
                        item.Click -= button1_Click;
                        item.Click += button1_Click;
                    }

                    szamlalo++;

                    if (item.Text == "")
                    {
                        item.Enabled = false;
                        item.Visible = false;
                    }

                }
            }

            button1.Left = 10;
            button1.Top = 10;

            button2.Left = button1.Right + 10;
            button2.Top = button1.Top;

            button3.Left = button2.Right + 10;
            button3.Top = button1.Top;

            button4.Left = button3.Right + 10;
            button4.Top = button1.Top;

            button5.Left = button4.Right + 10;
            button5.Top = button1.Top;

            button6.Left = button1.Left;
            button6.Top = button1.Bottom + 10;

            button7.Left = button6.Right + 10;
            button7.Top = button6.Top;

            button8.Left = button7.Right + 10;
            button8.Top = button6.Top;

            button9.Left = button8.Right + 10;
            button9.Top = button6.Top;

            button10.Left = button9.Right + 10;
            button10.Top = button6.Top;

            button11.Left = button1.Left;
            button11.Top = button6.Bottom + 10;

            button12.Left = button11.Right + 10;
            button12.Top = button11.Top;

            button13.Left = button12.Right + 10;
            button13.Top = button11.Top;

            button14.Left = button13.Right + 10;
            button14.Top = button11.Top;

            button15.Left = button14.Right + 10;
            button15.Top = button11.Top;

            button16.Left = button1.Left;
            button16.Top = button11.Bottom + 10;

            button17.Left = button16.Right + 10;
            button17.Top = button16.Top;

            button18.Left = button17.Right + 10;
            button18.Top = button16.Top;

            button19.Left = button18.Right + 10;
            button19.Top = button16.Top;

            button20.Left = button19.Right + 10;
            button20.Top = button16.Top;

            button21.Left = button1.Left;
            button21.Top = button16.Bottom + 10;

            button22.Left = button21.Right + 10;
            button22.Top = button21.Top;

            button23.Left = button22.Right + 10;
            button23.Top = button21.Top;

            button24.Left = button23.Right + 10;
            button24.Top = button21.Top;

            button25.Left = button24.Right + 10;
            button25.Top = button21.Top;

            button26.Left = button1.Left;
            button26.Top = button21.Bottom + 10;

            button27.Left = button26.Right + 10;
            button27.Top = button26.Top;

            button28.Left = button27.Right + 10;
            button28.Top = button26.Top;

            button29.Left = button28.Right + 10;
            button29.Top = button26.Top;

            button30.Left = button29.Right + 10;
            button30.Top = button26.Top;

            button31.Left = button1.Left;
            button31.Top = button26.Bottom + 10;

            button32.Left = button31.Right + 10;
            button32.Top = button31.Top;

            button33.Left = button32.Right + 10;
            button33.Top = button31.Top;

            button34.Left = button33.Right + 10;
            button34.Top = button31.Top;

            button35.Left = button34.Right + 10;
            button35.Top = button31.Top;

            button36.Width = button35.Width / 2 - 5;
            button36.Height = button36.Width;
            button36.Top = Size.Height - (button36.Height + 50);
            button36.Left = button35.Left;

            button37.Top = Size.Height - (button37.Height + 50);
            button37.Left = button1.Left;
            button37.Font = new Font(Font.FontFamily, button37.Height / 3);

            button38.Width = button35.Width / 2 - 5;
            button38.Height = button38.Width;
            button38.Top = Size.Height - (button38.Height + 50);
            button38.Left = button36.Right + 10;

            button39.Top = button37.Top;
            button39.Left = button2.Left;
            button39.Font = new Font(Font.FontFamily, button39.Height / 3);

            label2.Top = button36.Top;
            label2.Left = button38.Right + 25;
            label2.Width = Size.Width / 6 + 25;
            label2.Height = button36.Height;
            label2.Font = new Font(Font.FontFamily, label2.Height / 3);

            label1.Top = button1.Top;
            label1.Left = button5.Right + 25;
            label1.Width = Size.Width / 6 + 25;
            label1.Height = button5.Height * 7 + 60;
            label1.Font = new Font(Font.FontFamily, button1.Height / 5);

            label3.Top = button36.Top;
            label3.Height = button36.Height;
            label3.Left = button3.Left;
            label3.Width = (button3.Width * 2) + 10;
            label3.Font= new Font(Font.FontFamily, label3.Height / 2);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            GombAtmeretezes();
        }

        /// <summary>
        /// Törli az aktuálisan kijelzett rendelés összes tételét
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button36_Click(object sender, EventArgs e)
        {
            if (label2.Text != "0")
            {
                if (MessageBox.Show("Biztos törli az aktuális rendelést?", "Rendelés törlése", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Nyugta.NyugtaTorlese();
                    label1.Text = "";
                    label2.Text = "0";
                }
            }
        }

        /// <summary>
        /// Az aktuális rendelés véglegesítése, nyugta kinyomtatása
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button38_Click(object sender, EventArgs e)
        {
            if (label2.Text != "0")
            {
                if (MessageBox.Show("Biztos véglegesíti az aktuális rendelést?", "Rendelés véglegesítése", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    MessageBox.Show($"(Blokknyomtatóra küldés - hardver hiányában nem kerül bemutatásra)", "Nyomtatás", MessageBoxButtons.OK, MessageBoxIcon.None);

                    Nyugta.Fizetes();
                    label1.Text = "";
                    label2.Text = "0";

                    if (button39.Enabled == true)
                    {
                        button39.Enabled = false;
                        button39.Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// Tételek felvitele a rendelés tételei közé
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Nyugta.Eladas((Koktel)(sender as Button).Tag);
                label1.Text = Nyugta.Label1Frissites();
                label2.Text = Nyugta.Label2Frissites();
            }
        }

        /// <summary>
        /// Zárás indítása, stand ablak megnyitása
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button37_Click(object sender, EventArgs e)
        {
            if (Nyugta.BevetelLekerdezes() > 0)
            {
                this.FormClosing -= Form1_FormClosing;
                StandFrm standFrm = new StandFrm();
                this.Hide();
                Application.DoEvents();
                standFrm.ShowDialog();
            }
            else
            {
                Close();
            }
        }

        /// <summary>
        /// Bevételezés ablak indítása
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button39_Click(object sender, EventArgs e)
        {
            BevetelFrm bevetelezes = new BevetelFrm();
            if (bevetelezes.ShowDialog() == DialogResult.OK)
            {
                button39.Enabled = false;
                button39.Visible = false;
            }
        }

        /// <summary>
        /// Megerősítés kérése az alkalmazás bezárásához
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Biztosan bezárja az alkalmazást?", "Bezárás", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Akutális idő kijelzése
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
