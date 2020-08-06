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

namespace TLWindowsEditorWPFDemo
{
    /// <summary>
    /// Interaction logic for BarcodeItemDialog.xaml
    /// </summary>
    public partial class BarcodeItemDialog : Window
    {
        public BarcodeItemDialog()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboBarColor.ItemsSource = Enum.GetNames(typeof(Neodynamic.SDK.Printing.Color));
            cboForeColor.ItemsSource = Enum.GetNames(typeof(Neodynamic.SDK.Printing.Color));
            cboBarcodeAlignment.ItemsSource = Enum.GetNames(typeof(Neodynamic.SDK.Printing.BarcodeAlignment));
            cboBarcodeSizing.ItemsSource = Enum.GetNames(typeof(Neodynamic.SDK.Printing.BarcodeSizing));

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private BarcodeItem _bcItem = null;
        public BarcodeItem BarcodeItem
        {
            get
            {
                //set properties based on dialog inputs
                _bcItem.Comments = generalUC1.ItemComments;
                _bcItem.CornerRadius = new RectangleCornerRadius(strokeFillUC1.ItemCornerRadius);
                _bcItem.BackColor = strokeFillUC1.ItemFillColor;
                _bcItem.Height = sizeUC1.ItemHeight;
                _bcItem.Width = sizeUC1.ItemWidth;
                _bcItem.Name = generalUC1.ItemName;
                _bcItem.PrintAsGraphic = generalUC1.PrintAsGraphic;
                _bcItem.BorderColor = strokeFillUC1.ItemStrokeColor;
                _bcItem.BorderThickness = new FrameThickness(strokeFillUC1.ItemStrokeThickness);
                _bcItem.X = positionUC1.ItemX;
                _bcItem.Y = positionUC1.ItemY;
                _bcItem.RotationAngle = sizeUC1.ItemRotationAngle;
                _bcItem.Font.UpdateFrom(fontUC1.GetFont());
                _bcItem.ForeColor = (Neodynamic.SDK.Printing.Color)Enum.Parse(typeof(Neodynamic.SDK.Printing.Color), cboForeColor.SelectedValue.ToString());
                _bcItem.Sizing = (Neodynamic.SDK.Printing.BarcodeSizing)Enum.Parse(typeof(Neodynamic.SDK.Printing.BarcodeSizing), cboBarcodeSizing.SelectedValue.ToString());
                _bcItem.BarcodeAlignment = (Neodynamic.SDK.Printing.BarcodeAlignment)Enum.Parse(typeof(Neodynamic.SDK.Printing.BarcodeAlignment), cboBarcodeAlignment.SelectedValue.ToString());
                _bcItem.DataField = dataBindingUC1.ItemDataField;
                _bcItem.DataFieldFormatString = dataBindingUC1.ItemDataFieldFormatString;
                _bcItem.Symbology = barcodeUC1.BarcodeSymbology;
                _bcItem.Code = barcodeUC1.BarcodeCode;
                _bcItem.BarWidth = barcodeUC1.BarcodeBarWidth;
                _bcItem.BarRatio = barcodeUC1.BarcodeBarRatio;
                _bcItem.BarHeight = barcodeUC1.BarcodeBarHeight;
                _bcItem.DisplayCode = barcodeUC1.BarcodeDisplayCode;
                if(barcodeUC1.BarcodeModuleSize > 0) { 
                    _bcItem.AztecCodeModuleSize = _bcItem.DataMatrixModuleSize = _bcItem.QRCodeModuleSize = _bcItem.HanXinCodeModuleSize = barcodeUC1.BarcodeModuleSize;
                }
                _bcItem.BarColorHex = this.ItemBarColorHex;
                _bcItem.ForeColorHex = this.ItemForeColorHex;
                _bcItem.BackColorHex = strokeFillUC1.ItemFillColorHex;
                _bcItem.BorderColorHex = strokeFillUC1.ItemStrokeColorHex;
                return _bcItem;
            }
            set 
            {
                _bcItem = value.Clone() as BarcodeItem;

                //set barcode
                barcodeUC1.BarcodeSymbology = _bcItem.Symbology;
                barcodeUC1.BarcodeCode = _bcItem.Code;
                barcodeUC1.BarcodeBarWidth = _bcItem.BarWidth;
                barcodeUC1.BarcodeBarRatio = _bcItem.BarRatio;
                barcodeUC1.BarcodeBarHeight = _bcItem.BarHeight;
                barcodeUC1.BarcodeDisplayCode = _bcItem.DisplayCode;

                //set font
                fontUC1.SetFont(_bcItem.Font);

                //set fill & stroke                
                strokeFillUC1.ItemFillColor = _bcItem.BackColor;
                //for simplicity we are going to use uniform corner radius (but you can change it if needed!)
                strokeFillUC1.ItemCornerRadius = _bcItem.CornerRadius.TopLeft;
                strokeFillUC1.ItemStrokeColor = _bcItem.BorderColor;
                //for simplicity we are going to use uniform border thickness (but you can change it if needed!)
                strokeFillUC1.ItemStrokeThickness = _bcItem.BorderThickness.Left;

                cboForeColor.SelectedItem = _bcItem.ForeColor.ToString();
                this.ItemBarColorHex = _bcItem.BarColorHex;
                this.ItemForeColorHex = _bcItem.ForeColorHex;
                strokeFillUC1.ItemFillColorHex = _bcItem.BackColorHex;
                strokeFillUC1.ItemStrokeColorHex = _bcItem.BorderColorHex;

                //set position & size tab
                positionUC1.ItemX = _bcItem.X;
                positionUC1.ItemY = _bcItem.Y;
                sizeUC1.ItemWidth = _bcItem.Width;
                sizeUC1.ItemHeight = _bcItem.Height;
                sizeUC1.ItemRotationAngle = _bcItem.RotationAngle;

                cboBarcodeSizing.SelectedItem = _bcItem.Sizing.ToString();
                cboBarcodeAlignment.SelectedItem = _bcItem.BarcodeAlignment.ToString();

                //set data binding
                dataBindingUC1.ItemDataField = _bcItem.DataField;
                dataBindingUC1.ItemDataFieldFormatString = _bcItem.DataFieldFormatString;

                //set general tab
                generalUC1.ItemName = _bcItem.Name;
                generalUC1.ItemComments = _bcItem.Comments;

            }
        }

        private void CmdForeColorHex_Click(object sender, RoutedEventArgs e)
        {
            var c = ((SolidColorBrush)cmdForeColorHex.Background).Color;
            var colorDialog = new System.Windows.Forms.ColorDialog();
            colorDialog.Color = System.Drawing.Color.FromArgb(c.A, c.R, c.G, c.B);

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var c1 = colorDialog.Color;

                cmdForeColorHex.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(c1.A, c1.R, c1.G, c1.B));
            }
        }

        public string ItemForeColorHex
        {
            get
            {
                var c = ((SolidColorBrush)cmdForeColorHex.Background).Color;

                return $"#{Convert.ToString(c.A, 16).PadLeft(2, '0')}{Convert.ToString(c.R, 16).PadLeft(2, '0')}{Convert.ToString(c.G, 16).PadLeft(2, '0')}{Convert.ToString(c.B, 16).PadLeft(2, '0')}";

            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    cmdForeColorHex.Background = new SolidColorBrush(_bcItem.ForeColor == Neodynamic.SDK.Printing.Color.Black ? Colors.Black : Colors.White);
                else
                    cmdForeColorHex.Background = new SolidColorBrush((System.Windows.Media.Color)(new ColorConverter().ConvertFrom(value)));
            }
        }

        private void CmdBarColorHex_Click(object sender, RoutedEventArgs e)
        {
            var c = ((SolidColorBrush)cmdBarColorHex.Background).Color;
            var colorDialog = new System.Windows.Forms.ColorDialog();
            colorDialog.Color = System.Drawing.Color.FromArgb(c.A, c.R, c.G, c.B);

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var c1 = colorDialog.Color;

                cmdBarColorHex.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(c1.A, c1.R, c1.G, c1.B));
            }
        }

        public string ItemBarColorHex
        {
            get
            {
                var c = ((SolidColorBrush)cmdBarColorHex.Background).Color;

                return $"#{Convert.ToString(c.A, 16).PadLeft(2, '0')}{Convert.ToString(c.R, 16).PadLeft(2, '0')}{Convert.ToString(c.G, 16).PadLeft(2, '0')}{Convert.ToString(c.B, 16).PadLeft(2, '0')}";

            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    cmdBarColorHex.Background = new SolidColorBrush(_bcItem.BarColor == Neodynamic.SDK.Printing.Color.Black ? Colors.Black : Colors.White);
                else
                    cmdBarColorHex.Background = new SolidColorBrush((System.Windows.Media.Color)(new ColorConverter().ConvertFrom(value)));
            }
        }
    }
}
