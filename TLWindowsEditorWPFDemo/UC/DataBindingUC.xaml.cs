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
    /// Interaction logic for DataBindingUC.xaml
    /// </summary>
    public partial class DataBindingUC : UserControl
    {
        public DataBindingUC()
        {
            InitializeComponent();
        }


        public string ItemDataField
        {
            get
            {
                return txtItemDataField.Text;
            }
            set
            {
                txtItemDataField.Text = value;
            }
        }

        public string ItemDataFieldFormatString
        {
            get
            {
                return txtItemDataFieldFormatString.Text;
            }
            set
            {
                txtItemDataFieldFormatString.Text = value;
            }
        }

    }

}
