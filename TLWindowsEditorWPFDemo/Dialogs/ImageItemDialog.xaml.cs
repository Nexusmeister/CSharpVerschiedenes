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
    /// Interaction logic for ImageItemDialog.xaml
    /// </summary>
    public partial class ImageItemDialog : Window
    {
        public ImageItemDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public ImageItem ImageItem
        { 
            get
            {
                //create a new ImageItem and return it based on dialog settings
                ImageItem newImgItem = pictureUC1.GetImageItem();
                newImgItem.Name = generalUC1.ItemName;
                newImgItem.Comments = generalUC1.ItemComments;
                newImgItem.X = positionUC1.ItemX;
                newImgItem.Y = positionUC1.ItemY;
                newImgItem.DataField = dataBindingUC1.ItemDataField;
                newImgItem.DataFieldFormatString = dataBindingUC1.ItemDataFieldFormatString;
                return newImgItem;
            }
            set
            {
                //set picture tab
                pictureUC1.SetImageItem(value);
                //set position tab
                positionUC1.ItemX = value.X;
                positionUC1.ItemY = value.Y;
                //set data binding
                dataBindingUC1.ItemDataField = value.DataField;
                dataBindingUC1.ItemDataFieldFormatString = value.DataFieldFormatString;
                //set general tab
                generalUC1.ItemName = value.Name;
                generalUC1.ItemComments = value.Comments;
                
            }
        }
        
    }
}
