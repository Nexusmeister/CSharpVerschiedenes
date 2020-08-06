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

namespace TLWindowsEditorWPFDemo
{
    /// <summary>
    /// Interaction logic for LabelDoc.xaml
    /// </summary>
    public partial class LabelDoc : Window
    {
        public LabelDoc()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            cboUnit.DataContext = Enum.GetNames(typeof(Neodynamic.SDK.Printing.UnitType));

            

        }

        Neodynamic.SDK.Printing.UnitType _currentLabelUnit = Neodynamic.SDK.Printing.UnitType.Inch;
        public Neodynamic.SDK.Printing.UnitType LabelUnit
        {
            get { return _currentLabelUnit; }
            set {
                _currentLabelUnit = value;
                cboUnit.SelectedItem = _currentLabelUnit.ToString();
            }
        }
        
        public double LabelWidth
        {
            get { return double.Parse(txtWidth.Text); }
            set { txtWidth.Text = value.ToString(); }
        }

        public double LabelHeight
        {
            get { return double.Parse(txtHeight.Text); }
            set { txtHeight.Text = value.ToString(); }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void cboUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Neodynamic.SDK.Printing.UnitType newUnit = (Neodynamic.SDK.Printing.UnitType)Enum.Parse(typeof(Neodynamic.SDK.Printing.UnitType), cboUnit.SelectedItem.ToString());
            txtWidth.Text = Neodynamic.Windows.ThermalLabelEditor.UnitUtils.Convert(_currentLabelUnit, double.Parse(txtWidth.Text), newUnit, 2).ToString();
            txtHeight.Text = Neodynamic.Windows.ThermalLabelEditor.UnitUtils.Convert(_currentLabelUnit, double.Parse(txtHeight.Text), newUnit, 2).ToString();
            _currentLabelUnit = newUnit;

        }

        private void chkIsContinuous_Checked(object sender, RoutedEventArgs e)
        {
            txtGapLength.IsEnabled = txtMarkLength.IsEnabled = false;
        }

        private void chkIsContinuous_Unchecked(object sender, RoutedEventArgs e)
        {
            txtGapLength.IsEnabled = txtMarkLength.IsEnabled = true;
        }

        public double LabelGapLength
        {
            get { return double.Parse(txtGapLength.Text); }
            set { txtGapLength.Text = value.ToString();

            
            
            }
        }

        public double LabelMarkLength
        {
            get { return double.Parse(txtMarkLength.Text); }
            set { txtMarkLength.Text = value.ToString();

           
            
            }
        }

        public bool LabelIsContinuous
        {
            get { return chkIsContinuous.IsChecked.Value; }
            set { chkIsContinuous.IsChecked = value; }
        }

        public bool LabelPrintMirror
        {
            get { return chkPrintMirror.IsChecked.Value; }
            set { chkPrintMirror.IsChecked = value; }
        }

        public string LabelPrintSpeed
        {
            get { return txtPrintSpeed.Text; }
            set { txtPrintSpeed.Text = value; }
        }

        public bool LabelCutAfterPrinting
        {
            get { return chkCutAfterPrinting.IsChecked.Value; }
            set { chkCutAfterPrinting.IsChecked = value; }
        }
    }
}
