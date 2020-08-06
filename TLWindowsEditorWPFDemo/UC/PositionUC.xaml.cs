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
    /// Interaction logic for PositionUC.xaml
    /// </summary>
    public partial class PositionUC : UserControl
    {
        public PositionUC()
        {
            InitializeComponent();
        }


        public double ItemX
        {
            get
            {
                try
                {
                    return double.Parse(txtItemX.Text);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                txtItemX.Text = value.ToString();
            }
        }

        public double ItemY
        {
            get
            {
                try
                {
                    return double.Parse(txtItemY.Text);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                txtItemY.Text = value.ToString();
            }
        }

    }

}
