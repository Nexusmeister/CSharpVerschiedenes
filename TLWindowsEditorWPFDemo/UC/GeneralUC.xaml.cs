using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TLWindowsEditorWPFDemo
{
    /// <summary>
    /// Interaction logic for GeneralUC.xaml
    /// </summary>
    public partial class GeneralUC : UserControl
    {
        public GeneralUC()
        {
            InitializeComponent();
        }


        public string ItemName
        {
            get
            {
                return txtItemName.Text;
            }
            set
            {
                txtItemName.Text = value;
            }
        }

        public string ItemComments
        {
            get
            {
                return txtItemComments.Text;
            }
            set
            {
                txtItemComments.Text = value;
            }
        }

        public bool PrintAsGraphic
        {
            get
            {
                return chkPrintAsGraphic.IsChecked == true;
            }
            set
            {
                chkPrintAsGraphic.IsChecked = value;
            }
        }
    }
}
