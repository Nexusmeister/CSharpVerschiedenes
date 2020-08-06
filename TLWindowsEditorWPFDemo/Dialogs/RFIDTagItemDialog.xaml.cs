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
using System.Windows.Shapes;
using Neodynamic.SDK.Printing;

namespace TLWindowsEditorWPFDemo.Dialogs
{
    /// <summary>
    /// Interaction logic for RFIDTagItemDialog.xaml
    /// </summary>
    public partial class RFIDTagItemDialog : Window
    {
        public RFIDTagItemDialog()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] dataFormats = Enum.GetNames(typeof(Neodynamic.SDK.Printing.RFIDTagDataFormat));
            Array.Sort(dataFormats);

            cboDataFormats.ItemsSource = dataFormats;
        }


        private RFIDTagItem _rfidTagItem = null;
        public RFIDTagItem RFIDTagItem
        {
            get
            {
                //set properties based on dialog inputs
                _rfidTagItem.Comments = generalUC1.ItemComments;
                _rfidTagItem.Name = generalUC1.ItemName;
                _rfidTagItem.PrintAsGraphic = generalUC1.PrintAsGraphic;
                _rfidTagItem.DataFormat = this.DataFormat;
                _rfidTagItem.DataToEncode = this.DataToEncode;
                _rfidTagItem.EPCDataStructure = this.EPCDataStructure;
                return _rfidTagItem;
            }
            set
            {
                _rfidTagItem = value.Clone() as RFIDTagItem;

                this.DataFormat = _rfidTagItem.DataFormat;
                this.DataToEncode = _rfidTagItem.DataToEncode;
                this.EPCDataStructure = _rfidTagItem.EPCDataStructure;
                
                //set general tab
                generalUC1.ItemName = _rfidTagItem.Name;
                generalUC1.ItemComments = _rfidTagItem.Comments;

            }
        }



        public Neodynamic.SDK.Printing.RFIDTagDataFormat DataFormat
        {
            get
            {
                return (Neodynamic.SDK.Printing.RFIDTagDataFormat)Enum.Parse(typeof(Neodynamic.SDK.Printing.RFIDTagDataFormat), cboDataFormats.SelectedValue.ToString());
            }
            set
            {
                cboDataFormats.SelectedItem = value.ToString();
            }
        }


        public string DataToEncode
        {
            get
            {
                return txtData.Text;
            }
            set
            {
                txtData.Text = value;
            }
        }

        public string EPCDataStructure
        {
            get
            {
                return txtEPCDataStructure.Text;
            }
            set
            {
                txtEPCDataStructure.Text = value;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

    }
}
