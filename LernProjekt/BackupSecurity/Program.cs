using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BackupSecurity
{
    public class Program
    {
        private static string quelle = @"F:\OneDrive\DH-Wirtschaftsinformatik\Projektarbeit\Projektarbeit_II\Backup\";
        private static string ziel = @"E:\Projektarbeit\Projektarbeit_II\Backup\";
        private static List<string> sourceFolders;
        private static List<string> targetFolders;
        public static void Main(string[] args)
        {
            try
            {
                sourceFolders = new List<string>();
                targetFolders = new List<string>();

                var sourceDir = Directory.GetDirectories(quelle).ToList();
                var backupDir = Directory.GetDirectories(ziel).ToList();
                foreach (var directory in sourceDir)
                {
                    sourceFolders.Add(directory.Remove(0, quelle.Length));
                }
                foreach (var directory in backupDir)
                {
                    targetFolders.Add(directory.Remove(0, ziel.Length));
                }

                var notInBackup = sourceFolders.Except(targetFolders).ToList();

                foreach (var dir in notInBackup)
                {
                    var folderSource = sourceDir.Where(x => x.EndsWith(dir)).ToArray()[0];

                    Copy(folderSource, ziel);
                }
            }
            catch (Exception e1)
            {
                var stw = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\FEHLER.txt");
                stw.Write($"Fehler in Backup Security!!! {e1.ToString()}");
                stw.Close();
            }
            
        }

        private static void Copy(string source, string target)
        {
            var sourceDir = new DirectoryInfo(source);
            var targetDir = new DirectoryInfo(target + sourceDir.Name);

            CopyDirectory(sourceDir, targetDir);
        }

        private static void CopyDirectory(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                //Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyDirectory(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}
