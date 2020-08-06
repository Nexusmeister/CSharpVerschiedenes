using System;
using System.Windows.Forms;

namespace SKCDLL.Tools
{
    public class SKCMessages
    {
        /// <summary>
        /// Fehlermeldung an User
        /// </summary>
        /// <param name="messageString">Nachricht</param>
        /// <param name="titel">Header</param>
        public static void ShowError(string messageString, string titel = "Ein Fehler ist aufgetreten")
        {
            MessageBox.Show(messageString, titel, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Logge Ereignis und zeige Fehler dem User
        /// </summary>
        /// <param name="e">Exception</param>
        /// <param name="messageString">Fehlermeldung</param>
        public static void ShowError(Exception e, string messageString)
        {
            Logger.LogToFile($"{e}");
            ShowError($"{messageString} -> {e.Message}");
        }

        /// <summary>
        /// Zeige Information für User an
        /// </summary>
        /// <param name="messageString">Information</param>
        /// <param name="titel">Header</param>
        public static void ShowInfo(string messageString, string titel = "Info")
        {
            MessageBox.Show(messageString, titel, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Zeige Dialog für User
        /// </summary>
        /// <param name="messageString">Frage an User</param>
        /// <param name="titel">Header</param>
        /// <returns></returns>
        public static DialogResult ShowFrage(string messageString, string titel = "")
        {
            return MessageBox.Show(messageString, titel, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
