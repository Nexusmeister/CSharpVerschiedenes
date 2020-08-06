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
    /// Interaction logic for StrokeFillUC.xaml
    /// </summary>
    public partial class StrokeFillUC : UserControl
    {
        public StrokeFillUC()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //load colors
            cboFillColor.ItemsSource = Enum.GetNames(typeof(Neodynamic.SDK.Printing.Color));
            cboStrokeColor.ItemsSource = Enum.GetNames(typeof(Neodynamic.SDK.Printing.Color));

        }

        public Neodynamic.SDK.Printing.Color ItemStrokeColor
        {
            get
            {
                return cboStrokeColor.SelectedValue == null ? Neodynamic.SDK.Printing.Color.Black : (Neodynamic.SDK.Printing.Color)Enum.Parse(typeof(Neodynamic.SDK.Printing.Color), cboStrokeColor.SelectedValue.ToString());
                
            }
            set
            {
                cboStrokeColor.SelectedItem = value.ToString();
            }
        }

        public Neodynamic.SDK.Printing.Color ItemFillColor
        {
            get
            {
                return cboFillColor.SelectedValue == null ? Neodynamic.SDK.Printing.Color.White : (Neodynamic.SDK.Printing.Color)Enum.Parse(typeof(Neodynamic.SDK.Printing.Color), cboFillColor.SelectedValue.ToString());

            }
            set
            {
                cboFillColor.SelectedItem = value.ToString();
            }
        }

        public double ItemStrokeThickness
        {
            get
            {
                try
                {
                    return double.Parse(txtStrokeThickness.Text);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                txtStrokeThickness.Text = value.ToString();
            }
        }

        public double ItemCornerRadius
        {
            get
            {
                try
                {
                    return double.Parse(txtCornerRadius.Text);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                txtCornerRadius.Text = value.ToString();
            }
        }

        public Visibility CornerRadiusOptionVisibility
        {
            get
            {
                return gbRoundedCorners.Visibility;
            }
            set
            {
                gbRoundedCorners.Visibility = value;
            }
        }

        public Visibility FillOptionVisibility
        {
            get
            {
                return gbFill.Visibility;
            }
            set
            {
                gbFill.Visibility = value;
            }
        }

        private void cmdStrokeColorHex_Click(object sender, RoutedEventArgs e)
        {
            var c = ((SolidColorBrush)cmdStrokeColorHex.Background).Color;
            var colorDialog = new System.Windows.Forms.ColorDialog();
            colorDialog.Color = System.Drawing.Color.FromArgb(c.A, c.R, c.G, c.B);
            
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var c1 = colorDialog.Color;

                cmdStrokeColorHex.Background = new SolidColorBrush(Color.FromArgb(c1.A, c1.R, c1.G, c1.B));
            }
        }

        private void CmdFillColorHex_Click(object sender, RoutedEventArgs e)
        {
            var c = ((SolidColorBrush)cmdFillColorHex.Background).Color;
            var colorDialog = new System.Windows.Forms.ColorDialog();
            colorDialog.Color = System.Drawing.Color.FromArgb(c.A, c.R, c.G, c.B);

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var c1 = colorDialog.Color;

                cmdFillColorHex.Background = new SolidColorBrush(Color.FromArgb(c1.A, c1.R, c1.G, c1.B));
            }
        }


        public string ItemStrokeColorHex
        {
            get
            {
                var c = ((SolidColorBrush)cmdStrokeColorHex.Background).Color;

                return $"#{Convert.ToString(c.A, 16).PadLeft(2, '0')}{Convert.ToString(c.R, 16).PadLeft(2, '0')}{Convert.ToString(c.G, 16).PadLeft(2, '0')}{Convert.ToString(c.B, 16).PadLeft(2, '0')}";

            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    cmdStrokeColorHex.Background = new SolidColorBrush(this.ItemStrokeColor == Neodynamic.SDK.Printing.Color.Black ? Colors.Black : Colors.White);
                else
                    cmdStrokeColorHex.Background = new SolidColorBrush((System.Windows.Media.Color)(new ColorConverter().ConvertFrom(value)));
            }
        }

        public string ItemFillColorHex
        {
            get
            {
                var c = ((SolidColorBrush)cmdFillColorHex.Background).Color;

                return $"#{Convert.ToString(c.A, 16).PadLeft(2, '0')}{Convert.ToString(c.R, 16).PadLeft(2, '0')}{Convert.ToString(c.G, 16).PadLeft(2, '0')}{Convert.ToString(c.B, 16).PadLeft(2, '0')}";

            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    cmdFillColorHex.Background = new SolidColorBrush(this.ItemFillColor == Neodynamic.SDK.Printing.Color.Black ? Colors.Black : Colors.White);
                else
                    cmdFillColorHex.Background = new SolidColorBrush((System.Windows.Media.Color)(new ColorConverter().ConvertFrom(value)));
            }
        }

    }

}
