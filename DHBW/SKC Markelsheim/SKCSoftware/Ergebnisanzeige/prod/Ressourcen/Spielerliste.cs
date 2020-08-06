using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Ergebnisanzeige.Views;

namespace Ergebnisanzeige.Ressourcen
{
    public class Spielerliste
    {
        public List<string> listeSpieler = new List<string>();
        public static string[] spielerArray = new string[100];

        public static List<string> listeSpieler2 = new List<string>();
        public static string[] spielerArray2 = new string[100];

        private static readonly string listePath = Application.LocalUserAppDataPath;
        private static readonly string listeName = "\\SKCSavedSpielernamen.txt";
        private static readonly string fullPath = listePath + listeName;

        public Spielerliste()
        {
            ErzeugeSpielerListe();
        }
        
        [Obsolete]
        public void ErzeugeSpielerListe()
        {
            listeSpieler.Add("");
            listeSpieler.Add("Braun, Rudolf");
            listeSpieler.Add("Braun, Ursula");
            listeSpieler.Add("Diez, Ralf");
            listeSpieler.Add("Freymüller, Christian");
            listeSpieler.Add("Freymüller, Doreen");
            listeSpieler.Add("Freymüller, Helmut");
            listeSpieler.Add("Freymüller, Stefanie");
            listeSpieler.Add("Glaser, Matthias");
            listeSpieler.Add("Hefner, Torsten");
            listeSpieler.Add("Kaltenbach, Robin");
            listeSpieler.Add("Kleefeld, Eckhardt");
            listeSpieler.Add("Kübler, Hans");
            listeSpieler.Add("Kuhnhäuser, Stefan");
            listeSpieler.Add("Lang, Bruno");
            listeSpieler.Add("Leber, Heiko");
            listeSpieler.Add("Leber, Timo");           
            listeSpieler.Add("Lehr, Manfred");
            listeSpieler.Add("Lehr, Steffen");
            listeSpieler.Add("Marquardt, Dirk");
            listeSpieler.Add("Maurer, Björn");
            listeSpieler.Add("Mehburger, Andreas");
            listeSpieler.Add("Müller, Tobias");
            listeSpieler.Add("Neft, Juliane");
            listeSpieler.Add("Öhm, Christian");
            listeSpieler.Add("Reißenweber, Gerd");
            listeSpieler.Add("Rumm, Michael");
            listeSpieler.Add("Schneider, Alois");
            listeSpieler.Add("Stauch, Wolfgang");
            listeSpieler.Add("Wittmann, Markus");

            spielerArray = listeSpieler.ToArray();
        }

        /// <summary>
        /// Hole alle SKC Spieler aus einer Datei
        /// </summary>
        /// <returns></returns>
        public static string[] HoleSpielerAusTextFile()
        {
            var dateipfad = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Ressourcen\Spielerliste.txt";
            if (Directory.Exists(dateipfad))
            {
                return null;
            }
            string[] lineOfContents = File.ReadAllLines(dateipfad, Encoding.GetEncoding(1252));
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(';');
                listeSpieler2.Add(string.Join("", tokens));
            }

            spielerArray2 = listeSpieler2.ToArray();

            return listeSpieler2.ToArray();
        }

        /// <summary>
        /// Speichere neue Spielernamen
        /// </summary>
        /// <param name="frmEingabe"></param>
        public static void SpeichereNeueSpielernamen(frmEingabe frmEingabe)
        {
            if (!File.Exists(fullPath))
            {
                var fs = File.Create(fullPath);
                fs.Close();
            }

            var listeExistingSpieler = HoleAlleDatensaetze().ToList();
            var listeControls = GetAll(frmEingabe, typeof(TextBox));
            var listeNeueSpieler = new List<string>();
            foreach (var txt in listeControls)
            {
                var count = listeExistingSpieler.Count(x => x.Equals(txt.Text.Trim(), StringComparison.OrdinalIgnoreCase));
                if (count == 0 && !string.IsNullOrWhiteSpace(txt.Text))
                {
                    var name = NormalisiereName(txt.Text);
                    listeNeueSpieler.Add(name);
                    listeExistingSpieler.Add(name);
                }
            }

            File.AppendAllLines(fullPath, listeNeueSpieler);
        }

        private static string NormalisiereName(string text)
        {
            var name = text.Trim().ToLower();
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
        }

        /// <summary>
        /// Erhalte eine Sammlung von Controls, die einem bestimmten Typen angehören
        /// </summary>
        /// <param name="control"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type && c.Name.Contains("txtEingabeGast"));
        }

        /// <summary>
        /// Holt alle Datensätze aus einem Dateipfad
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> HoleAlleDatensaetze()
        {
            if (File.Exists(fullPath))
            {
                return File.ReadAllLines(fullPath).ToList();
            }

            return new List<string>();
        }
    }
}
