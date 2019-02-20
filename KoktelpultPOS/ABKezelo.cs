using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace KoktelpultPOS
{
    static class ABKezelo
    {
        static SqlConnection connection;
        static SqlCommand command;
        static Receptura[] receptura;
        static List<Alapanyag> alapanyagok;
        static List<Koktel> koktelok;

        /// <summary>
        /// Csatlakozás az adatbázishoz
        /// </summary>
        public static void Csatlakozas()
        {
            try
            {
                connection = new SqlConnection();
                connection.ConnectionString = "Data Source=CHARLIE-NOTEBOO\\SQLEXPRESS;Initial Catalog=KoktelPOS;Integrated Security=True";
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
            }
            catch (Exception ex)
            {
                throw new Exception("A csatlakozás sikertelen!", ex);
            }
        }

        /// <summary>
        /// Bontja a kapcsolatot az adatbázissal
        /// </summary>
        public static void KapcsolatBontasa()
        {
            try
            {
                connection.Close();
                command = null;
            }
            catch (Exception ex)
            {
                throw new Exception("A kapcsolat bontása sikertelen!", ex);
            }
        }

        /// <summary>
        /// Az adatbázisból kiolvassa a koktélokat névvel, árral és a hozzá tartozó receptúrával együtt
        /// </summary>
        /// <returns>Visszaadja a koktélok listáját</returns>
        public static List<Koktel> Beolvasas()
        {
            try
            {
                Csatlakozas();
                command.CommandText = $"SELECT * FROM [Receptura]";
                command.Parameters.Clear();
                koktelok = new List<Koktel>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        receptura = new Receptura[8];

                        receptura[0].alapanyag = reader["Alapanyag1"].ToString();
                        receptura[0].mennyiseg = double.Parse(reader["Mennyiseg1"].ToString());
                        receptura[1].alapanyag = reader["Alapanyag2"].ToString();
                        receptura[1].mennyiseg = double.Parse(reader["Mennyiseg2"].ToString());
                        receptura[2].alapanyag = reader["Alapanyag3"].ToString();
                        receptura[2].mennyiseg = double.Parse(reader["Mennyiseg3"].ToString());
                        receptura[3].alapanyag = reader["Alapanyag4"].ToString();
                        receptura[3].mennyiseg = double.Parse(reader["Mennyiseg4"].ToString());
                        receptura[4].alapanyag = reader["Alapanyag5"].ToString();
                        receptura[4].mennyiseg = double.Parse(reader["Mennyiseg5"].ToString());
                        receptura[5].alapanyag = reader["Alapanyag6"].ToString();
                        receptura[5].mennyiseg = double.Parse(reader["Mennyiseg6"].ToString());
                        receptura[6].alapanyag = reader["Alapanyag7"].ToString();
                        receptura[6].mennyiseg = double.Parse(reader["Mennyiseg7"].ToString());
                        receptura[7].alapanyag = reader["Alapanyag8"].ToString();
                        receptura[7].mennyiseg = double.Parse(reader["Mennyiseg8"].ToString());

                        koktelok.Add(new Koktel(reader["Nev"].ToString(), (int)reader["Ar"], receptura));
                    }
                    reader.Close();
                }

                return koktelok;
            }
            catch (Exception ex)
            {
                throw new Exception("Nem sikerült beolvasni az adatokat az adatbázisból", ex);
            }
        }

        /// <summary>
        /// Az adatbázisból kiolvassa az alapanyagok nevét, árát és az aktuális készletet
        /// </summary>
        /// <returns>Visszaadja az alapanyagok listáját</returns>
        public static List<Alapanyag> KeszletBeolvasas()
        {
            try
            {
                Csatlakozas();
                command.CommandText = $"SELECT * FROM [Keszlet]";
                command.Parameters.Clear();
                alapanyagok = new List<Alapanyag>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        alapanyagok.Add(new Alapanyag(reader["Nev"].ToString(), double.Parse(reader["Keszlet"].ToString()), (int)reader["Ar"]));
                    }
                    reader.Close();
                }

                return alapanyagok;
            }
            catch (Exception ex)
            {
                throw new Exception("Nem sikerült beolvasni az adatokat az adatbázisból", ex);
            }
        }

        /// <summary>
        /// A stand során rögzített értékeket elmenti az adott napra létrehozott adattáblába
        /// </summary>
        /// <param name="standlap">A rögzített standok listája</param>
        /// <param name="datum">Az aktuális dátum</param>
        public static void StandRogzitese(List<Stand> standlap, string datum)
        {
            try
            {
                Csatlakozas();
                foreach (Stand item in standlap)
                {
                    command.Parameters.Clear();
                    command.CommandText = $"INSERT INTO [Stand_{datum}] ([Nev], [NyitoKeszlet], [ZaroKeszlet], [Ar], [ValosFogyas], [ValosErtek], [GepSzerintiFogyas], [GepSzerintiErtek], [StandElteres], [StandElteresErtek]) VALUES (@nev, @nyito, @zaro, @ar, @vFogyas, @vErtek, @gFogyas, @gErtek, @elteres, @penzElteres)";
                    command.Parameters.AddWithValue("@nev", item.ItalNev);
                    command.Parameters.AddWithValue("@nyito", item.NyitoKeszlet);
                    command.Parameters.AddWithValue("@zaro", item.ZaroKeszlet);
                    command.Parameters.AddWithValue("@ar", item.Ar);
                    command.Parameters.AddWithValue("@vFogyas", item.ValosFogyas);
                    command.Parameters.AddWithValue("@vErtek", item.ValosErtek);
                    command.Parameters.AddWithValue("@gFogyas", item.GepSzerintiFogyas);
                    command.Parameters.AddWithValue("@gErtek", item.GepSzerintiErtek);
                    command.Parameters.AddWithValue("@elteres", item.StandElteres);
                    command.Parameters.AddWithValue("@penzElteres", item.StandElteresErteke);
                    command.ExecuteNonQuery();

                    command.Parameters.Clear();
                    command.CommandText = $"UPDATE [Keszlet] SET [Keszlet] = @mennyiseg WHERE [Nev] = @nev";
                    command.Parameters.AddWithValue("@nev", item.ItalNev);
                    command.Parameters.AddWithValue("@mennyiseg", item.ZaroKeszlet);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Nem sikerült feltölteni az adatokat az adatbázisba", ex);
            }
        }

        /// <summary>
        /// Létrehozza az adott naphoz tartozó üres adattáblát
        /// </summary>
        /// <param name="datum">Az aktuális dátum</param>
        public static void StandAB(string datum)
        {
            try
            {
                Csatlakozas();
                command.Parameters.Clear();
                command.CommandText = $"CREATE TABLE [Stand_{datum}]([Nev] VARCHAR(24) NOT NULL PRIMARY KEY, [NyitoKeszlet] FLOAT NOT NULL, [ZaroKeszlet] FLOAT NOT NULL, [Ar] INT NOT NULL, [ValosFogyas] FLOAT NOT NULL, [ValosErtek] INT NOT NULL, [GepSzerintiFogyas] FLOAT NOT NULL, [GepSzerintiErtek] INT NOT NULL, [StandElteres] FLOAT NOT NULL, [StandElteresErtek] INT NOT NULL);";
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Nem sikerült létrehozni az adattáblát", ex);
            }
        }

        /// <summary>
        /// Rögzíti az adatbázisban a bevételezést
        /// </summary>
        /// <param name="megnevezes">Az adott alapanyag megnevezése</param>
        /// <param name="bevetelezes">Az adott alapanyaghoz tartozó új mennyiség</param>
        public static void Bevetelezes(string megnevezes, double bevetelezes)
        {
            Csatlakozas();
            command.Parameters.Clear();
            command.CommandText = $"UPDATE [Keszlet] SET [Keszlet] = @mennyiseg WHERE [Nev] = @nev";
            command.Parameters.AddWithValue("@nev", megnevezes);
            command.Parameters.AddWithValue("@mennyiseg", bevetelezes);
            command.ExecuteNonQuery();
        }
    }
}
