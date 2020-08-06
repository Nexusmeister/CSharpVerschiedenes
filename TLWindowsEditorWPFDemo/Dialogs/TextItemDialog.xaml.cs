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
    /// Interaction logic for TextItemDialog.xaml
    /// </summary>
    public partial class TextItemDialog : Window
    {
        public TextItemDialog()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboForeColor.ItemsSource = Enum.GetNames(typeof(Neodynamic.SDK.Printing.Color));
            cboTextSizing.ItemsSource = Enum.GetNames(typeof(Neodynamic.SDK.Printing.TextSizing));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private TextItem _textItem = null;
        public TextItem TextItem
        {
            get
            {
                //set properties based on dialog inputs
                _textItem.Comments = generalUC1.ItemComments;
                _textItem.CornerRadius = new RectangleCornerRadius(strokeFillUC1.ItemCornerRadius);
                _textItem.BackColor = strokeFillUC1.ItemFillColor;
                _textItem.Height = sizeUC1.ItemHeight;
                _textItem.Width = sizeUC1.ItemWidth;
                _textItem.Name = generalUC1.ItemName;
                _textItem.PrintAsGraphic = generalUC1.PrintAsGraphic;
                _textItem.BorderColor = strokeFillUC1.ItemStrokeColor;
                _textItem.BorderThickness = new FrameThickness(strokeFillUC1.ItemStrokeThickness);
                _textItem.X = positionUC1.ItemX;
                _textItem.Y = positionUC1.ItemY;
                _textItem.RotationAngle = sizeUC1.ItemRotationAngle;
                _textItem.Font.UpdateFrom(fontUC1.GetFont());
                _textItem.ForeColor = (Neodynamic.SDK.Printing.Color)Enum.Parse(typeof(Neodynamic.SDK.Printing.Color), cboForeColor.SelectedValue.ToString());
                _textItem.Sizing = (Neodynamic.SDK.Printing.TextSizing)Enum.Parse(typeof(Neodynamic.SDK.Printing.TextSizing), cboTextSizing.SelectedValue.ToString());
                _textItem.DataField = dataBindingUC1.ItemDataField;
                _textItem.DataFieldFormatString = dataBindingUC1.ItemDataFieldFormatString;
                _textItem.ForeColorHex = this.ItemForeColorHex;
                _textItem.BackColorHex = strokeFillUC1.ItemFillColorHex;
                _textItem.BorderColorHex = strokeFillUC1.ItemStrokeColorHex;
                return _textItem;
            }
            set 
            {
                _textItem = value.Clone() as TextItem;

                //set font
                fontUC1.SetFont(_textItem.Font);

                //set fill & stroke                
                strokeFillUC1.ItemFillColor = _textItem.BackColor;
                //for simplicity we are going to use uniform corner radius (but you can change it if needed!)
                strokeFillUC1.ItemCornerRadius = _textItem.CornerRadius.TopLeft;
                strokeFillUC1.ItemStrokeColor = _textItem.BorderColor;
                //for simplicity we are going to use uniform border thickness (but you can change it if needed!)
                strokeFillUC1.ItemStrokeThickness = _textItem.BorderThickness.Left;

                cboForeColor.SelectedItem = _textItem.ForeColor.ToString();
                this.ItemForeColorHex = _textItem.ForeColorHex;
                strokeFillUC1.ItemFillColorHex = _textItem.BackColorHex;
                strokeFillUC1.ItemStrokeColorHex = _textItem.BorderColorHex;

                //set position & size tab
                positionUC1.ItemX = _textItem.X;
                positionUC1.ItemY = _textItem.Y;
                sizeUC1.ItemWidth = _textItem.Width;
                sizeUC1.ItemHeight = _textItem.Height;
                sizeUC1.ItemRotationAngle = _textItem.RotationAngle;

                cboTextSizing.SelectedItem = _textItem.Sizing.ToString();

                //set data binding
                dataBindingUC1.ItemDataField = _textItem.DataField;
                dataBindingUC1.ItemDataFieldFormatString = _textItem.DataFieldFormatString;

                //set general tab
                generalUC1.ItemName = _textItem.Name;
                generalUC1.ItemComments = _textItem.Comments;

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

                return $"#{Convert.ToString(c.A, 16).PadLeft(2,'0')}{Convert.ToString(c.R, 16).PadLeft(2, '0')}{Convert.ToString(c.G, 16).PadLeft(2, '0')}{Convert.ToString(c.B, 16).PadLeft(2, '0')}";

            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    cmdForeColorHex.Background = new SolidColorBrush(_textItem.ForeColor == Neodynamic.SDK.Printing.Color.Black ? Colors.Black : Colors.White);
                else
                    cmdForeColorHex.Background = new SolidColorBrush((System.Windows.Media.Color)(new ColorConverter().ConvertFrom(value)));
            }
        }
    }
}
