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

using Neodynamic.SDK.Printing;

namespace TLWindowsEditorWPFDemo
{
    /// <summary>
    /// Interaction logic for FontUC.xaml
    /// </summary>
    public partial class FontUC : UserControl
    {
        public FontUC()
        {
            InitializeComponent();
        }


        private Font _curFont = new Font();

        public void SetFont(Font font)
        {

            _curFont.UpdateFrom(font);

            //set font name to listbox
            lstInstalledFonts.SelectedIndex = lstInstalledFonts.Items.IndexOf(new FontFamily(font.Name));
            lstInstalledFonts.ScrollIntoView(lstInstalledFonts.SelectedItem);

            //set style
            ((ListBoxItem)lstFontStyle.Items[0]).IsSelected = font.Bold || font.Name == Font.NativePrinterFontB;
            ((ListBoxItem)lstFontStyle.Items[1]).IsSelected = font.Italic;
            ((ListBoxItem)lstFontStyle.Items[2]).IsSelected = font.Strikeout;
            ((ListBoxItem)lstFontStyle.Items[3]).IsSelected = font.Underline;
            
            //set font size

            //NOTE: NativePrinterFonts (A, B & S) have fixed sizes
            if (font.IsNativePrinterFont)
                font.Size = Font.GetNearestSizeForNativePrinterFonts(font);

            //In this sample app we only support Point as Font Unit (you can change this, of course!)
            double fontSizeInPt = Neodynamic.Windows.ThermalLabelEditor.UnitUtils.Convert(font.Unit, font.Size, FontUnit.Point, 2);

            

            txtFontSize.Text = fontSizeInPt.ToString();

            //preview settings
            txbPreview.FontFamily = new FontFamily(font.Name);
            txbPreview.FontSize = fontSizeInPt / 72d * 96d; //size is in points and needs to be converted to WPF DIU
            txbPreview.FontStyle = font.IsNativePrinterFont == false && font.Italic ? FontStyles.Italic : FontStyles.Normal;
            txbPreview.FontWeight = font.IsNativePrinterFont == false && font.Bold ? FontWeights.Bold : FontWeights.Normal;
            if (font.Name == Font.NativePrinterFontB)
            {
                //NativePrinterFontB must be always Bold!
                txbPreview.FontWeight = FontWeights.Bold;
            }

            if (font.IsNativePrinterFont == false &&
                font.Strikeout)
            {
                txbPreview.TextDecorations.Add(TextDecorations.Strikethrough);
            }
            if (font.IsNativePrinterFont == false &&
                font.Underline)
            {
                txbPreview.TextDecorations.Add(TextDecorations.Underline);
            }


        }


        public Font GetFont()
        {
            
            //set name
            if (lstInstalledFonts.SelectedValue != null)
            {
                _curFont.Name = lstInstalledFonts.SelectedValue.ToString();
            }

            //set style
            _curFont.Bold = ((ListBoxItem)lstFontStyle.Items[0]).IsSelected;
            _curFont.Italic = ((ListBoxItem)lstFontStyle.Items[1]).IsSelected;
            _curFont.Strikeout = ((ListBoxItem)lstFontStyle.Items[2]).IsSelected;
            _curFont.Underline = ((ListBoxItem)lstFontStyle.Items[3]).IsSelected;

            //set font size
            try
            {
                _curFont.Size = double.Parse(txtFontSize.Text);
            }
            catch
            { }
            _curFont.Unit = FontUnit.Point;


            return _curFont;
        }

        private void lstInstalledFonts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selFont = lstInstalledFonts.SelectedValue.ToString();

            txbPreview.FontFamily = new FontFamily(selFont);

            if (selFont == Font.NativePrinterFontB)
            {
                //NativePrinterFontB must be always Bold!
                txbPreview.FontWeight = FontWeights.Bold;
            }

        }

        private void lstFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtFontSize.Text = ((ListBoxItem)lstFontSize.SelectedItem).Content.ToString();
        }

        private void txtFontSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double fontSizeInPts = double.Parse(txtFontSize.Text);
                string selFont = lstInstalledFonts.SelectedValue.ToString();
                if (selFont != null &&
                    (selFont == Font.NativePrinterFontA ||
                    selFont == Font.NativePrinterFontB ||
                    selFont == Font.NativePrinterFontS))
                {
                    Font tmpFont = new Font();
                    tmpFont.Name = selFont;
                    tmpFont.Unit = FontUnit.Point;
                    tmpFont.Size = fontSizeInPts;
                    //recalculate size for Native printer font
                    fontSizeInPts = Font.GetNearestSizeForNativePrinterFonts(tmpFont);
                    //update textbox
                    txtFontSize.Text = fontSizeInPts.ToString();
                }

                

                txbPreview.FontSize = fontSizeInPts / 72d * 96d; //size is in points and needs to be converted to WPF DIU
            }
            catch
            { }
        }

        private void lstFontStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstInstalledFonts.SelectedValue != null)
            {
                string selFont = lstInstalledFonts.SelectedValue.ToString();

                if (selFont != null &&
                    selFont != Font.NativePrinterFontA &&
                    selFont != Font.NativePrinterFontB &&
                    selFont != Font.NativePrinterFontS)
                {
                    txbPreview.FontStyle = ((ListBoxItem)lstFontStyle.Items[1]).IsSelected ? FontStyles.Italic : FontStyles.Normal;
                    txbPreview.FontWeight = ((ListBoxItem)lstFontStyle.Items[0]).IsSelected ? FontWeights.Bold : FontWeights.Normal;
                    if (((ListBoxItem)lstFontStyle.Items[2]).IsSelected)
                    {
                        txbPreview.TextDecorations.Add(TextDecorations.Strikethrough);
                    }
                    if (((ListBoxItem)lstFontStyle.Items[3]).IsSelected)
                    {
                        txbPreview.TextDecorations.Add(TextDecorations.Underline);
                    }

                }
            }
        }

    }
}
