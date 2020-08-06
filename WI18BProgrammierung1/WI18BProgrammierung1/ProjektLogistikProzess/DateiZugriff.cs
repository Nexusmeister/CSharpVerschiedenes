using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProzessLernen
{
    class DateiZugriff
    {
        public static void SchreibeDatei(string input)
        {
            System.IO.File.WriteAllText(@"D:\Test.txt", input);
        }

        public static void SchreibeDateiWeiter(string zusätzlicherInput)
        {
            if (zusätzlicherInput == null)
            {
                throw new ArgumentNullException(nameof(zusätzlicherInput));
            }

            //File.AppendAllLines(@"D:\Test.txt", zusätzlicherInput);
        }

        public static void GebeLaufwerkeAus()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("Laufwerk({3}): {0} mit {1}GB, hat noch {2}GB freien Speicher",
                    drive.Name, drive.TotalSize, drive.TotalFreeSpace, drive.DriveType);
            }
        }
    }
}
