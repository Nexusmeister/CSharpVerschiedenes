using Ergebnisanzeige.Ressourcen;
using System.Windows.Forms;

namespace Ergebnisanzeige.Tools
{
    public class ComboBinding
    {
        public void BindeSpielerListeAnKomboBoxen(ComboBox cbo)
        {
            
            //cbo.DataSource = spielerliste.listeSpieler;
            for(int i = 0; i < Spielerliste.spielerArray.Length; i++)
            {
                cbo.Items.Add(Spielerliste.spielerArray[i].ToString());
                //cbo.Items.Add(spielerliste.)
            }          
        }

        public static void BindeSpielerListeAnKomboBoxen(ComboBox cbo, string[] spieler)
        {
            for (int i = 0; i < spieler.Length; i++)
            {
                cbo.Items.Add(spieler[i].ToString());
                //cbo.Items.Add(spielerliste.)
            }
        }
    }
}
