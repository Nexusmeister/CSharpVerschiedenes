using System.Data;
using System.Data.SqlClient;
using KMSFrame;

namespace ReleaseAuto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DB.GetConnectionIntegratedSecurity("ReleaseAutomatisierung");
            Logger.LogFilePath = App.Path;

            if (CheckMovegroup())
            {
                return;
            }

            var sql = "SELECT TOP 50000 * FROM WaKopf (nolock) ORDER BY ID DESC";
            using (var cmd = new SqlCommand(sql, DB.DBCon))
            {
                Logger.LogToFile("Wir laufen durch WaKöpfe");
                using (var dt = DB.GetDataTableByCMD(cmd))
                {
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        //Logger.LogToFile("ID: " + dataRow.Field<int>("Id"));
                    }
                }
            }

            if (CheckMovegroup())
            {
                return;
            }

            sql = "SELECT TOP 50000 * FROM WaPos (nolock) ORDER BY ID DESC";
            using (var cmd = new SqlCommand(sql, DB.DBCon))
            {
                Logger.LogToFile("Wir laufen durch MdePossen");
                using (var dt = DB.GetDataTableByCMD(cmd))
                {
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        //Logger.LogToFile("ID: " + dataRow.Field<int>("Id"));
                    }
                }
            }

            if (CheckMovegroup())
            {
                return;
            }

            sql = "SELECT TOP 50000 * FROM MdePos (nolock) ORDER BY ID DESC";
            using (var cmd = new SqlCommand(sql, DB.DBCon))
            {
                Logger.LogToFile("Wir laufen durch MdePos");
                using (var dt = DB.GetDataTableByCMD(cmd))
                {
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        //Logger.LogToFile("ID: " + dataRow.Field<int>("Id"));
                    }
                }
            }
        }

        public static bool CheckMovegroup()
        {
            //Ausgabe der CustomizingVariable KMSOffline
            //Beschreibung: Beendet kontrolliert alle Instanzen von KMS sowie alle Tools.
            int kmsOffline = Customizing.getWertInt(786);

            //Ausgabe der CustomizingVariable MoveGroup Faktura
            //Beschreibung: MoveGroup Steuerung für das Tool Faktura
            int moveGroupFaktura = Customizing.getWertInt(938);

            if (kmsOffline == 0 && moveGroupFaktura == 0)
            {
                return false;
            }

            Logger.LogToFile("Movegroup wurde gesetzt! Wir beenden uns hier");
            return true;

        }
    }
}
