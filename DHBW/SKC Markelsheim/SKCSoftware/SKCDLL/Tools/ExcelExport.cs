using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using SKCDLL.Entities.Models;
using System.Linq;

namespace SKCDLL.Tools
{
    public class ExcelExport
    {
        Application excel;
        Workbook workBook;
        Worksheet workSheet;
        Range cellRange;

        public string DateiPfad { get; set; }
        public List<string> ListeEmpfaenger { get; set; }
        public Partie PartieInformation { get; private set; }
        public string Empfaenger { get; set; }

        public ExcelExport(Partie dto)
        {
            PartieInformation = dto;
        }

        public ExcelExport(Partie dto, string empfaenger) : this(dto)
        {
            Empfaenger = empfaenger;
        }

        public ExcelExport()
        {

        }

        public ExcelExport(Partie dto, List<string> listeEmpfaenger) : this(dto)
        {
            ListeEmpfaenger = listeEmpfaenger;
        }

        public string ExportToExcel(bool unterdrueckeOeffnen = false)
        {
            try
            {
                //Anwendung bleibt offen und sichtbar, das gleich gedruckt werden kann
                if (!Directory.Exists(@"C:\SKC"))
                {
                    Logger.LogToFile("Erzeuge Excel-Ordner unter C:");
                    Directory.CreateDirectory(@"C:\SKC");
                }

                Logger.LogToFile("Unterdrücke Sichtbarkeit von Excel: " + unterdrueckeOeffnen);
                excel = new Application
                {
                    //Visible = true,
                    DisplayAlerts = false,
                };

                if (unterdrueckeOeffnen)
                {
                    excel.Visible = false;
                }
                else
                {
                    excel.Visible = true;
                }


                workBook = excel.Workbooks.Add(Type.Missing);
                workSheet = (Worksheet)workBook.ActiveSheet;
                workSheet.Name = "Spielergebnis";
                FormatiereExcelBlatt();
                FuelleExcelMitDaten();

                cellRange = workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, 10]];
                cellRange.EntireColumn.AutoFit();
                Borders border = workSheet.Cells.Borders;
                border.LineStyle = XlLineStyle.xlContinuous;
                border.Weight = 2d;

                string skc = ErzeugeStringOhneLeerzeichen(PartieInformation.SKCMarkelsheimName);
                string gast = ErzeugeStringOhneLeerzeichen(PartieInformation.GastmannschaftName);
                var dateipfad = @"C:\SKC\";
                var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                var dateiname = $@"Ergebnis_{skc}vs{gast}_{timestamp}";

                var dateipfadVollstaendig = dateipfad + dateiname;

                //Sollte die Datei bereits geöffnet worden sein, dann versuche nicht zu speichern
                var dateinamePruef = dateipfadVollstaendig + ".xlsx";
                DateiPfad = dateinamePruef;
                FileInfo fileInfo;
                if (File.Exists(dateinamePruef))
                {
                    if (unterdrueckeOeffnen)
                    {
                        workBook.SaveAs(dateipfadVollstaendig);
                        Logger.LogToFile($"Excelfile gespeichert unter: {dateipfadVollstaendig}");
                        workBook.Close(true, Type.Missing, Type.Missing);
                        excel.Quit();
                        Marshal.ReleaseComObject(workBook);
                        Marshal.ReleaseComObject(excel);
                        Logger.LogToFile("Excel Prozess beendet.");
                    }
                    else
                    {
                        fileInfo = new FileInfo(dateinamePruef);
                        Logger.LogToFile("Datei existiert bereits! Prüfe, ob blockiert...");
                        if (!IstDateiBlockiert(fileInfo))
                        {
                            Logger.LogToFile("Datei ist nicht blockiert: " + fileInfo.FullName);
                            workBook.SaveAs(dateipfadVollstaendig);
                            Logger.LogToFile($"Excelfile erstellt und gespeichert unter: {dateipfadVollstaendig}");
                            return dateinamePruef;
                        }
                        else
                        {
                            SKCMessages.ShowError($"Fehler beim Speichern des Spielberichts. Bitte schließen Sie alle Anwendungen, die eine Datei mit dem Dateinamen {dateiname} beinhaltet.");
                            Logger.LogToFile($"Excelfile konnte nicht gespeichert werden, da die Datei bereits geöffnet bzw. von einem anderem Prozess benutzt wird. \n\t\t\t\t\t Betroffene Datei -> " + fileInfo.FullName);
                        }
                    }
                }
                else
                {
                    //Wenn Datei nicht existiert, kann auch ohne Weiteres gespeichert werden
                    workBook.SaveAs(dateipfadVollstaendig);
                    if (unterdrueckeOeffnen)
                    {
                        workBook.Close(true, Type.Missing, Type.Missing);
                        excel.Quit();
                        Marshal.ReleaseComObject(workBook);
                        Marshal.ReleaseComObject(excel);
                    }
                    Logger.LogToFile($"Excelfile erstellt und gespeichert unter: {dateipfadVollstaendig}");
                }

                return dateinamePruef;
            }
            catch (Exception e1)
            {
                SKCMessages.ShowError($"Fehler beim Exportieren nach Excel. {e1.Message}");
                Logger.LogToFile($"Fehler beim Export nach Excel: {e1}");
            }

            return string.Empty;
        }

        private void CloseProcess()
        {
            workBook.Close(true, Type.Missing, Type.Missing);
            excel.Quit();
            Marshal.ReleaseComObject(workBook);
            Marshal.ReleaseComObject(excel);
            workBook = null;
            excel = null;
            GC.Collect();
        }

        private string ErzeugeStringOhneLeerzeichen(string mitLeerzeichen)
        {
            return mitLeerzeichen.Replace(" ", "_");
        }

        /// <summary>
        /// Versendet Mail an ausgewählten Empfänger
        /// </summary>
        public void ExportToExcelUndVersendeMail()
        {
            ExportToExcel(true);
            EMail.VersendeMailMitSpielbericht(DateiPfad, Empfaenger);
        }

        /// <summary>
        /// Prüft eine Datei, ob sie bereits geöffnet worden ist oder nicht
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        public bool IstDateiBlockiert(FileInfo fileInfo)
        {
            FileStream stream = null;

            try
            {
                stream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                Logger.LogToFile("IOException -> Datei wird blockiert: " + fileInfo.FullName);
                // Datei ist nicht verfügbar
                return true;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            return false;
        }

        private void FuelleExcelMitDaten()
        {
            //Befülle Mannschaftsnamen
            workSheet.Cells[1, 1] = PartieInformation.SKCMarkelsheimName;
            workSheet.Cells[1, 6] = PartieInformation.GastmannschaftName;

            //Befülle Spielerzellen
            workSheet.Cells[3, 1] = PartieInformation.SpielerSKC1.Name;
            workSheet.Cells[4, 1] = PartieInformation.SpielerSKC2.Name;
            workSheet.Cells[5, 1] = PartieInformation.SpielerSKC3.Name;
            workSheet.Cells[6, 1] = PartieInformation.SpielerSKC4.Name;
            workSheet.Cells[7, 1] = PartieInformation.SpielerSKC5.Name;
            workSheet.Cells[8, 1] = PartieInformation.SpielerSKC6.Name;

            workSheet.Cells[3, 9] = PartieInformation.SpielerGast1.Name;
            workSheet.Cells[4, 9] = PartieInformation.SpielerGast2.Name;
            workSheet.Cells[5, 9] = PartieInformation.SpielerGast3.Name;
            workSheet.Cells[6, 9] = PartieInformation.SpielerGast4.Name;
            workSheet.Cells[7, 9] = PartieInformation.SpielerGast5.Name;
            workSheet.Cells[8, 9] = PartieInformation.SpielerGast6.Name;

            //Befülle Ergebniszellen
            workSheet.Cells[3, 2] = PartieInformation.SpielerSKC1.Gesamt;
            workSheet.Cells[3, 3] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerSKC1.SatzPunkte);
            workSheet.Cells[3, 4] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerSKC1.MannschaftsPunkt);

            workSheet.Cells[4, 2] = PartieInformation.SpielerSKC2.Gesamt;
            workSheet.Cells[4, 3] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerSKC2.SatzPunkte);
            workSheet.Cells[4, 4] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerSKC2.MannschaftsPunkt);

            workSheet.Cells[5, 2] = PartieInformation.SpielerSKC3.Gesamt;
            workSheet.Cells[5, 3] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerSKC3.SatzPunkte);
            workSheet.Cells[5, 4] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerSKC3.MannschaftsPunkt);

            workSheet.Cells[6, 2] = PartieInformation.SpielerSKC4.Gesamt;
            workSheet.Cells[6, 3] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerSKC4.SatzPunkte);
            workSheet.Cells[6, 4] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerSKC4.MannschaftsPunkt);

            workSheet.Cells[7, 2] = PartieInformation.SpielerSKC5.Gesamt;
            workSheet.Cells[7, 3] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerSKC5.SatzPunkte);
            workSheet.Cells[7, 4] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerSKC5.MannschaftsPunkt);

            workSheet.Cells[8, 2] = PartieInformation.SpielerSKC6.Gesamt;
            workSheet.Cells[8, 3] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerSKC6.SatzPunkte);
            workSheet.Cells[8, 4] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerSKC6.MannschaftsPunkt);


            workSheet.Cells[3, 8] = PartieInformation.SpielerGast1.Gesamt;
            workSheet.Cells[3, 7] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerGast1.SatzPunkte);
            workSheet.Cells[3, 6] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerGast1.MannschaftsPunkt);

            workSheet.Cells[4, 8] = PartieInformation.SpielerGast2.Gesamt;
            workSheet.Cells[4, 7] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerGast2.SatzPunkte);
            workSheet.Cells[4, 6] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerGast2.MannschaftsPunkt);

            workSheet.Cells[5, 8] = PartieInformation.SpielerGast3.Gesamt;
            workSheet.Cells[5, 7] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerGast3.SatzPunkte);
            workSheet.Cells[5, 6] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerGast3.MannschaftsPunkt);

            workSheet.Cells[6, 8] = PartieInformation.SpielerGast4.Gesamt;
            workSheet.Cells[6, 7] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerGast4.SatzPunkte);
            workSheet.Cells[6, 6] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerGast4.MannschaftsPunkt);

            workSheet.Cells[7, 8] = PartieInformation.SpielerGast5.Gesamt;
            workSheet.Cells[7, 7] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerGast5.SatzPunkte);
            workSheet.Cells[7, 6] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerGast5.MannschaftsPunkt);

            workSheet.Cells[8, 8] = PartieInformation.SpielerGast6.Gesamt;
            workSheet.Cells[8, 7] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerGast6.SatzPunkte);
            workSheet.Cells[8, 6] = Uebertragen.FormatiereKommazahl(PartieInformation.SpielerGast6.MannschaftsPunkt);

            //Fülle Gesamtwerte
            workSheet.Cells[12, 4] = Uebertragen.FormatiereKommazahl(PartieInformation.MannschaftspunkteHeim);
            workSheet.Cells[12, 6] = Uebertragen.FormatiereKommazahl(PartieInformation.MannschaftspunkteGast);

            workSheet.Cells[11, 3] = Uebertragen.FormatiereKommazahl(PartieInformation.SatzpunkteHeim);
            workSheet.Cells[11, 7] = Uebertragen.FormatiereKommazahl(PartieInformation.SatzpunkteGast);

            workSheet.Cells[10, 2] = PartieInformation.MannschaftsErgebnisHeim;
            workSheet.Cells[10, 8] = PartieInformation.MannschaftsErgebnisGast;
            workSheet.Cells[10, 5] = PartieInformation.DifferenzText;
            workSheet.Cells[14, 2] = PartieInformation.Bemerkungen;
        }

        private void FormatiereExcelBlatt()
        {
            workSheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
            workSheet.Cells.Font.Size = 16;
            workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, 4]].Merge();
            workSheet.Range[workSheet.Cells[1, 6], workSheet.Cells[1, 9]].Merge();
            workSheet.Range[workSheet.Cells[1, 5], workSheet.Cells[8, 5]].Merge();
            workSheet.Range[workSheet.Cells[9, 1], workSheet.Cells[9, 9]].Merge();

            workSheet.Range[workSheet.Cells[14, 2], workSheet.Cells[14, 9]].Merge();
            workSheet.Cells[14, 1] = "Bemerkungen:";

            //workSheet.Cells[1, 1].Font.Size = 22;
            //workSheet.Cells[1, 1].Font.Bold = true;
            //workSheet.Cells[1, 6].Font.Size = 22;
            //workSheet.Cells[1, 6].Font.Bold = true;
            //workSheet.Cells[12, 4].Font.Size = 18;
            //workSheet.Cells[12, 6].Font.Size = 18;
            //workSheet.Cells[12, 4].Font.Bold = true;
            //workSheet.Cells[12, 6].Font.Bold = true;

            workSheet.Range[workSheet.Cells[1, 6], workSheet.Cells[13, 6]].Cells.HorizontalAlignment = XlHAlign.xlHAlignRight;
            workSheet.Range[workSheet.Cells[1, 7], workSheet.Cells[13, 7]].Cells.HorizontalAlignment = XlHAlign.xlHAlignRight;
            workSheet.Range[workSheet.Cells[1, 8], workSheet.Cells[13, 8]].Cells.HorizontalAlignment = XlHAlign.xlHAlignRight;
            workSheet.Range[workSheet.Cells[1, 9], workSheet.Cells[13, 9]].Cells.HorizontalAlignment = XlHAlign.xlHAlignRight;

            workSheet.Cells[2, 1] = "Name";
            workSheet.Cells[2, 2] = "Ergebnis";
            workSheet.Cells[2, 3] = "SP";
            workSheet.Cells[2, 4] = "MP";

            workSheet.Cells[2, 6] = "MP";
            workSheet.Cells[2, 7] = "SP";
            workSheet.Cells[2, 8] = "Ergebnis";
            workSheet.Cells[2, 9] = "Name";

            workSheet.Cells[10, 1] = "Gesamt";
            workSheet.Cells[10, 9] = "Gesamt";
            workSheet.Cells[11, 1] = "SP";
            workSheet.Cells[11, 9] = "SP";
            workSheet.Cells[12, 1] = "MP";
            workSheet.Cells[12, 9] = "MP";
        }
    }
}