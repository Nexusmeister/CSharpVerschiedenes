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
    /// Interaction logic for BarcodeUC.xaml
    /// </summary>
    public partial class BarcodeUC : UserControl
    {
        public BarcodeUC()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string[] symbs = Enum.GetNames(typeof(Neodynamic.SDK.Printing.BarcodeSymbology));
            Array.Sort(symbs);

            cboSymbology.ItemsSource = symbs;
        }


        public Neodynamic.SDK.Printing.BarcodeSymbology BarcodeSymbology
        {
            get
            {
                return (Neodynamic.SDK.Printing.BarcodeSymbology)Enum.Parse(typeof(Neodynamic.SDK.Printing.BarcodeSymbology), cboSymbology.SelectedValue.ToString());
            }
            set
            {
                cboSymbology.SelectedItem = value.ToString();
            }
        }


        public string BarcodeCode
        {
            get
            {
                return txtCode.Text;
            }
            set
            {
                txtCode.Text = value;
            }
        }

        public double BarcodeBarWidth
        {
            get
            {
                try
                {
                    return double.Parse(txtBarWidth.Text);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                txtBarWidth.Text = value.ToString();
            }
        }

        public double BarcodeBarRatio
        {
            get
            {
                try
                {
                    return double.Parse(txtBarRatio.Text);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                txtBarRatio.Text = value.ToString();
            }
        }

        public double BarcodeBarHeight
        {
            get
            {
                try
                {
                    return double.Parse(txtBarHeight.Text);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                txtBarHeight.Text = value.ToString();
            }
        }

        public bool BarcodeDisplayCode
        {
            get
            {
                return chkDisplayCode.IsChecked == true;
            }
            set
            {
                chkDisplayCode.IsChecked = value;
            }

        }

        public double BarcodeModuleSize
        {
            get
            {
                try
                {
                    return double.Parse(txtModuleSize.Text);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                txtModuleSize.Text = value.ToString();
            }
        }

    }

}
