using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LearningSkills
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeFlowLayoutPanel();
            WindowsFormsHost.EnableWindowsFormsInterop();
            Ergebnisanzeige.frmEingabe f = new Ergebnisanzeige.frmEingabe
            {
                TopLevel = false
            };
            
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button b = sender as System.Windows.Forms.Button;

            b.Top = 20;
            b.Left = 20;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.host1.Visibility = Visibility.Hidden;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.host1.Visibility = Visibility.Collapsed;
        }

        private void InitializeFlowLayoutPanel()
        {
            System.Windows.Forms.FlowLayoutPanel flp =
                this.flowLayoutHost.Child as System.Windows.Forms.FlowLayoutPanel;

            flp.WrapContents = true;

            const int numButtons = 6;

            for (int i = 0; i < numButtons; i++)
            {
                System.Windows.Forms.Button b = new System.Windows.Forms.Button();
                b.Text = "Button";
                b.BackColor = System.Drawing.Color.AliceBlue;
                b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

                flp.Controls.Add(b);
            }
        }
    }
}
