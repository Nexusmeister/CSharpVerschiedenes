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
    /// Interaction logic for SizeUC.xaml
    /// </summary>
    public partial class SizeUC : UserControl
    {
        public SizeUC()
        {
            InitializeComponent();
        }


        public double ItemWidth
        {
            get
            {
                try
                {
                    return double.Parse(txtItemWidth.Text);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                txtItemWidth.Text = value.ToString();
            }
        }

        public double ItemHeight
        {
            get
            {
                try
                {
                    return double.Parse(txtItemHeight.Text);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                txtItemHeight.Text = value.ToString();
            }
        }

        public int ItemRotationAngle
        {
            get
            {
                try
                {
                    return int.Parse(txtItemRotationAngle.Text);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                txtItemRotationAngle.Text = value.ToString();
            }
        }


        public Visibility RotationAngleVisibility
        {
            get
            {
                return gbRotation.Visibility;
            }
            set
            {
                gbRotation.Visibility = value;
            }
        }


    }

}
