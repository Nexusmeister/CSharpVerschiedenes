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
using Neodynamic.Windows.ThermalLabelEditor;
using TLWindowsEditorWPFDemo.Dialogs;

namespace TLWindowsEditorWPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            

        }

        

        private void tbbPointer_Click(object sender, RoutedEventArgs e)
        {
            //Set the ActiveTool to Pointer
            thermalLabelEditor1.ActiveTool = EditorTool.Pointer;
        }

        private void tbbRect_Click(object sender, RoutedEventArgs e)
        {
            //is there any label on the editor's surface...
            if (thermalLabelEditor1.LabelDocument != null)
            {
                //Set the ActiveTool to Rectangle
                thermalLabelEditor1.ActiveTool = EditorTool.Rectangle;

                //Create and set the ActiveToolItem i.e. a RectangleShapeItem
                RectangleShapeItem rectItem = new RectangleShapeItem();
                rectItem.ConvertToUnit(thermalLabelEditor1.LabelDocument.UnitType);

                thermalLabelEditor1.ActiveToolItem = rectItem;
            }
        }

        private void tbbEllipse_Click(object sender, RoutedEventArgs e)
        {
            
            //is there any label on the editor's surface...
            if (thermalLabelEditor1.LabelDocument != null)
            {
                //Set the ActiveTool to Ellipse
                thermalLabelEditor1.ActiveTool = EditorTool.Ellipse;

                //Create and set the ActiveToolItem i.e. a EllipseShapeItem
                EllipseShapeItem ellItem = new EllipseShapeItem();
                ellItem.ConvertToUnit(thermalLabelEditor1.LabelDocument.UnitType);

                thermalLabelEditor1.ActiveToolItem = ellItem;
            }
        }

        private void tbbLine_Click(object sender, RoutedEventArgs e)
        {
            //is there any label on the editor's surface...
            if (thermalLabelEditor1.LabelDocument != null)
            {
                //Set the ActiveTool to Line
                thermalLabelEditor1.ActiveTool = EditorTool.Line;

                //Create and set the ActiveToolItem i.e. a LineShapeItem
                LineShapeItem lineItem = new LineShapeItem();
                lineItem.ConvertToUnit(thermalLabelEditor1.LabelDocument.UnitType);

                thermalLabelEditor1.ActiveToolItem = lineItem;
            }
        }

        private void tbbText_Click(object sender, RoutedEventArgs e)
        {
            //is there any label on the editor's surface...
            if (thermalLabelEditor1.LabelDocument != null)
            {
                //Set the ActiveTool to Text
                thermalLabelEditor1.ActiveTool = EditorTool.Text;

                //Create and set the ActiveToolItem i.e. a TextItem
                TextItem txtItem = new TextItem();
                txtItem.Font.Name = Font.NativePrinterFontA;
                txtItem.Font.Size = 10;
                txtItem.Text = "Type here";

                txtItem.ConvertToUnit(thermalLabelEditor1.LabelDocument.UnitType);

                thermalLabelEditor1.ActiveToolItem = txtItem;
            }

        }

        private void tbbImage_Click(object sender, RoutedEventArgs e)
        {
            //is there any label on the editor's surface...
            if (thermalLabelEditor1.LabelDocument != null)
            {
                //HERE YOU COULD OPEN A FILE DIALOG TO THE USE FOR SELECTING SOME IMAGE FILE                
                //OR PICK ONE FROM A 'GALLERY', ETC.
                //imgItem.SourceFile = @"C:\Pictures\glass.gif";
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.Filter = "Image File (*.bmp, *.gif, *.jpg, *.png)|*.bmp; *.gif; *.jpg; *.png";
                if (dlg.ShowDialog() == true)
                {

                    //Set the ActiveTool to Image
                    thermalLabelEditor1.ActiveTool = EditorTool.Image;

                    //Create and set the ActiveToolItem i.e. an ImageItem
                    ImageItem imgItem = new ImageItem();
                    imgItem.SourceFile = dlg.FileName;

                    thermalLabelEditor1.ActiveToolItem = imgItem;
                }
                else
                {
                    thermalLabelEditor1.ActiveTool = EditorTool.Pointer;
                }

                
            }
        }

        private void tbbBarcode_Click(object sender, RoutedEventArgs e)
        {
            //is there any label on the editor's surface...
            if (thermalLabelEditor1.LabelDocument != null)
            {
                //Set the ActiveTool to Barcode
                thermalLabelEditor1.ActiveTool = EditorTool.Barcode;

                //Create and set the ActiveToolItem i.e. a BarcodeItem
                //HERE YOU COULD CHANGE THE DEFAULT BARCODE TO BE DISPLAYED
                //OR OPEN A BARCODE DIALOG FOR SETTINGS, ETC.
                BarcodeItem bcItem = new BarcodeItem();
                bcItem.Symbology = BarcodeSymbology.Code128;
                bcItem.AddChecksum = false;
                bcItem.Code = BarcodeItemUtils.GenerateSampleCode(bcItem.Symbology);
                bcItem.Font.Name = Font.NativePrinterFontA;
                bcItem.Font.Size = 5;
                bcItem.BarcodeAlignment = BarcodeAlignment.MiddleCenter;

                bcItem.Sizing = BarcodeSizing.FitProportional; //New feature since v7.0

                bcItem.ConvertToUnit(thermalLabelEditor1.LabelDocument.UnitType);

                thermalLabelEditor1.ActiveToolItem = bcItem;
            }
        }


        private void tbbRFID_Click(object sender, RoutedEventArgs e)
        {
            
            //is there any label on the editor's surface...
            if (thermalLabelEditor1.LabelDocument != null)
            {
                //Set image, logo or icon you'd like to show for RFID tag!
                //thermalLabelEditor1.RFIDTagImageFileName = @"C:\Images\rfid.png";


                //Set the ActiveTool to RFID Tag
                thermalLabelEditor1.ActiveTool = EditorTool.RFIDTag;

                //Create and set the ActiveToolItem i.e. a RFIDTagItem
                RFIDTagItem rfidTagItem = new RFIDTagItem();
                rfidTagItem.ConvertToUnit(thermalLabelEditor1.LabelDocument.UnitType);

                thermalLabelEditor1.ActiveToolItem = rfidTagItem;
            }

        }

        private void tbbZoom100_Click(object sender, RoutedEventArgs e)
        {
            //Set up zoom to 100%
            this.sldZoom.Value = 100;
        }

        private void menuOpen_Click(object sender, RoutedEventArgs e)
        {
             
            //open a thermal label template
            //NOTE: *.tl extension is just that! The content of such files should be a ThermalLabel XML Template
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "ThermalLabel Template (*.xml, *.tl)|*.xml;*.tl";
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    //Create a ThermalLabel obj from a Template
                    ThermalLabel tl = ThermalLabel.CreateFromXmlTemplate(System.IO.File.ReadAllText(dlg.FileName));

                    //load it on the editor surface
                    thermalLabelEditor1.LoadThermalLabel(tl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
            
        }

        private void menuNew_Click(object sender, RoutedEventArgs e)
        {
            //Create a new 'document'
            LabelDoc labelSetup = new LabelDoc();
            labelSetup.LabelUnit = UnitType.Inch;
            labelSetup.LabelWidth = 4;
            labelSetup.LabelHeight = 3;
            labelSetup.LabelGapLength = 0;
            labelSetup.LabelMarkLength = 0;

            if (labelSetup.ShowDialog() == true)
            {
                //Create a ThermalLabel object based on the dialog box info
                //NOTE: In that dialog you should also ask for the "GapLength" 
                //and other properties which may be relevant to the creation
                //of teh ThermalLabel object!
                ThermalLabel tLabel = new ThermalLabel();
                tLabel.Width = labelSetup.LabelWidth;
                tLabel.Height = labelSetup.LabelHeight;
                tLabel.UnitType = labelSetup.LabelUnit;
                tLabel.IsContinuous = labelSetup.LabelIsContinuous;
                tLabel.GapLength = labelSetup.LabelGapLength;
                tLabel.MarkLength = labelSetup.LabelMarkLength;
                tLabel.PrintMirror = labelSetup.LabelPrintMirror;
                tLabel.PrintSpeed = labelSetup.LabelPrintSpeed;
                tLabel.CutAfterPrinting  = labelSetup.LabelCutAfterPrinting;

                //load it on the editor surface
                thermalLabelEditor1.LoadThermalLabel(tLabel);    
            }
            
        }


        private void menuSave_Click(object sender, RoutedEventArgs e)
        {
            //is there any label on the editor's surface...
            if (thermalLabelEditor1.LabelDocument != null)
            {
                //open save dialog...
                //NOTE: we have used *.tl file extension for ThermalLabel XML templates
                //BUT you can change it to whatever you want
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.DefaultExt = ".tl";
                dlg.Filter = "ThermalLabel XML Template (.tl)|*.tl";
                if (dlg.ShowDialog() == true)
                {
                    try
                    {
                        //save ThermalLabel template
                        thermalLabelEditor1.Save(dlg.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }



        private void thermalLabelEditor1_SelectionChanged(object sender, EventArgs e)
        {
            //The items selection has changed...

            //For simplicity, we will not show any dialog if there's a multiple item selection
            tbbProp.IsEnabled = false;
            if (thermalLabelEditor1.CurrentSelection != null)
            {
                tbbProp.IsEnabled = !(thermalLabelEditor1.CurrentSelection is MultipleSelectionItem);
            }            
        }

        private void thermalLabelEditor1_SelectionAreaChanged(object sender, EventArgs e)
        {

            //Show in the 'status bar' the dimensions of the selected area
            //we're going to format it including the unit

            Rect selArea = thermalLabelEditor1.CurrentSelectionArea;

            if (selArea.Width > 0 && selArea.Height > 0)
            {
                string unitDescription;
                if (thermalLabelEditor1.LabelDocument.UnitType == UnitType.Inch)
                    unitDescription = "in";
                else if (thermalLabelEditor1.LabelDocument.UnitType == UnitType.DotsPerInch)
                    unitDescription = "dpi";
                else if (thermalLabelEditor1.LabelDocument.UnitType == UnitType.Pica)
                    unitDescription = "pc";
                else if (thermalLabelEditor1.LabelDocument.UnitType == UnitType.Point)
                    unitDescription = "pt";
                else
                    unitDescription = thermalLabelEditor1.LabelDocument.UnitType.ToString().ToLower();


                object[] data = new object[]{unitDescription,
                                         selArea.X,
                                         selArea.Y,
                                         selArea.Width,
                                         selArea.Height};

                string decimals = "0".PadRight(thermalLabelEditor1.LabelDocument.NumOfFractionalDigits, '0');

                txtSelectionInfo.Text = string.Format("X: {1:0." + decimals + "}{0}   Y: {2:0." + decimals + "}{0}   Width: {3:0." + decimals + "}{0}   Height: {4:0." + decimals + "}{0}", data);
            }
            else
            {
                txtSelectionInfo.Text = "";
            }
        }

        

        

        

        

        private void menuLabelSetup_Click(object sender, RoutedEventArgs e)
        {
            //is there any label on the editor's surface...
            if (thermalLabelEditor1.LabelDocument != null)
            {
                //Open dialog for label document setup
                LabelDoc labelSetup = new LabelDoc();
                labelSetup.LabelUnit = thermalLabelEditor1.LabelDocument.UnitType;
                labelSetup.LabelWidth = thermalLabelEditor1.LabelDocument.Width;
                labelSetup.LabelHeight = thermalLabelEditor1.LabelDocument.Height;
                labelSetup.LabelIsContinuous = thermalLabelEditor1.LabelDocument.IsContinuous;
                labelSetup.LabelGapLength = thermalLabelEditor1.LabelDocument.GapLength;
                labelSetup.LabelMarkLength = thermalLabelEditor1.LabelDocument.MarkLength;
                labelSetup.LabelPrintMirror = thermalLabelEditor1.LabelDocument.PrintMirror;
                labelSetup.LabelPrintSpeed = thermalLabelEditor1.LabelDocument.PrintSpeed;
                labelSetup.LabelCutAfterPrinting = thermalLabelEditor1.LabelDocument.CutAfterPrinting;

                labelSetup.Owner = this;

                if (labelSetup.ShowDialog() == true)
                {
                    //Save LabelDocument settings
                    thermalLabelEditor1.LabelDocument.IsContinuous = labelSetup.LabelIsContinuous;
                    thermalLabelEditor1.LabelDocument.GapLength = labelSetup.LabelGapLength;
                    thermalLabelEditor1.LabelDocument.MarkLength = labelSetup.LabelMarkLength;
                    thermalLabelEditor1.LabelDocument.PrintMirror = labelSetup.LabelPrintMirror;
                    thermalLabelEditor1.LabelDocument.PrintSpeed = labelSetup.LabelPrintSpeed;
                    thermalLabelEditor1.LabelDocument.CutAfterPrinting  = labelSetup.LabelCutAfterPrinting;

                    //Invoke UpdateLabelDocument method for updating the label document inside the editor
                    thermalLabelEditor1.UpdateLabelDocument(labelSetup.LabelUnit, labelSetup.LabelWidth, labelSetup.LabelHeight, thermalLabelEditor1.LabelDocument.NumOfFractionalDigits);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            //THIS IS A LIST OF PROPERTIES FOR CUSTOMIZING THE EDITOR UI

            
            //thermalLabelEditor1.RulerBackground = Brushes.Tomato;
            //thermalLabelEditor1.RulerLinesColor = Colors.Gold;
            //thermalLabelEditor1.RulerForeColor = Colors.White;
            //thermalLabelEditor1.RulerSelectionColor = Colors.Purple;

            //LinearGradientBrush lgb = new LinearGradientBrush(Colors.LightGray, Colors.White, 45);
            //thermalLabelEditor1.LabelDocumentFrameBackground = lgb;
            //thermalLabelEditor1.LabelDocumentFrameBorderColor = Colors.Black;
            //thermalLabelEditor1.LabelDocumentFrameBorderThickness = 3;
            //thermalLabelEditor1.LabelDocumentFrameCornerRadius = 0;

            //thermalLabelEditor1.NoImageFileName = @"c:\noimage.jpg";


            //thermalLabelEditor1.AdornerHandlerBackColor = Colors.Yellow;
            //thermalLabelEditor1.AdornerHandlerHoverBackColor = Colors.DarkCyan;
            //thermalLabelEditor1.AdornerHandlerBorderColor = Colors.Gray;
            //thermalLabelEditor1.AdornerFrameBorderColor = Colors.Gray;

            //thermalLabelEditor1.AdornerSelectionBackColor = System.Windows.Media.Color.FromArgb(128, 255, 0, 128);
            //thermalLabelEditor1.AdornerSelectionBorderColor = System.Windows.Media.Color.FromArgb(128, 255, 0, 255);

            //thermalLabelEditor1.AngleSnap = 45;

            //thermalLabelEditor1.ImageProcessingDpi = 300;

            //thermalLabelEditor1.TextItemEditModeEnabled = false;
        }

        

        private void editorContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            //Disable/Enable context menu items based on the selected items on the editor's surface
            Item selItem = thermalLabelEditor1.CurrentSelection;

            //Font option is available for TextItem and BarcodeItem only
            if (selItem is TextItem ||
                selItem is BarcodeItem)
            {
                cmFont.Visibility = System.Windows.Visibility.Visible;                
            }
            else
            {
                cmFont.Visibility = System.Windows.Visibility.Collapsed;
            }
            Sep1.Visibility = cmFont.Visibility;

            //update "format" name based on the type of the selected Item
            cmFormat.Visibility = System.Windows.Visibility.Visible;
            if (selItem is TextItem)
                cmFormat.Header = "Format Text...";
            else if (selItem is BarcodeItem)
                cmFormat.Header = "Format Barcode...";
            else if (selItem is RectangleShapeItem)
                cmFormat.Header = "Format Rectangle...";
            else if (selItem is EllipseShapeItem)
                cmFormat.Header = "Format Ellipse...";
            else if (selItem is LineShapeItem)
                cmFormat.Header = "Format Line...";
            else if (selItem is ImageItem)
                cmFormat.Header = "Format Picture...";
            else if (selItem is RFIDTagItem)
                cmFormat.Header = "Format RFID Tag...";
            else
                cmFormat.Visibility = System.Windows.Visibility.Collapsed;

            Sep3.Visibility = cmFormat.Visibility;

        }

        

        private void cmFont_Click(object sender, RoutedEventArgs e)
        {
            //get current selection
            Item selItem = thermalLabelEditor1.CurrentSelection;
            //show Font dialog only for TextItem or BarcodeItem objects
            if (selItem is TextItem ||
                selItem is BarcodeItem)
            {
                //Get current Font of selected item
                Font itemFont;
                if (selItem is TextItem)
                    itemFont = ((TextItem)selItem).Font;
                else
                    itemFont = ((BarcodeItem)selItem).Font;

                //create and open a FontDialog
                FontDialog fontDialog = new FontDialog();
                fontDialog.Font = itemFont;
                fontDialog.Owner = this;

                if (fontDialog.ShowDialog() == true)
                {
                    //get new Font settings
                    itemFont = fontDialog.Font;
                    
                    //update font settings on item
                    if (selItem is TextItem)
                    {
                        ((TextItem)selItem).Font.UpdateFrom(itemFont);
                    }
                    else
                    {
                        ((BarcodeItem)selItem).Font.UpdateFrom(itemFont);
                    }

                    //update editor's surface
                    thermalLabelEditor1.UpdateSelectionItemsProperties();
                }
                
            }
            

        }

        private void cmFormat_Click(object sender, RoutedEventArgs e)
        {
            //get current selection
            Item selItem = thermalLabelEditor1.CurrentSelection;

            if (selItem is ImageItem)
            { 
                //create and open ImageItemDialog
                ImageItemDialog imgItemDialog = new ImageItemDialog();
                imgItemDialog.Owner = this;
                //set current ImageItem to dialog
                ImageItem curImgItem = selItem as ImageItem;
                imgItemDialog.ImageItem = curImgItem;
                if (imgItemDialog.ShowDialog() == true)
                { 
                    //update ImageItem based on dialog result
                    curImgItem.UpdateFrom(imgItemDialog.ImageItem);

                    //update editor's surface
                    thermalLabelEditor1.UpdateSelectionItemsProperties();
                }
            }
            else if (selItem is ShapeItem)
            {
                //create and open ShapeItemDialog
                ShapeItemDialog shapeItemDialog = new ShapeItemDialog();
                shapeItemDialog.Owner = this;                
                //set current ShapeItem to dialog
                ShapeItem curShapeItem = selItem as ShapeItem;
                shapeItemDialog.ShapeItem = curShapeItem;
                //customize dialog title
                shapeItemDialog.Title = curShapeItem.ToString().Replace("Neodynamic.SDK.Printing.", "").Replace("ShapeItem", "");

                if (shapeItemDialog.ShowDialog() == true)
                {
                    //update ShapeItem based on dialog result
                    curShapeItem.UpdateFrom(shapeItemDialog.ShapeItem);

                    //update editor's surface
                    thermalLabelEditor1.UpdateSelectionItemsProperties();
                }
            }
            else if (selItem is TextItem)
            {
                //create and open TextItemDialog
                TextItemDialog textItemDialog = new TextItemDialog();
                textItemDialog.Owner = this;
                //set current TextItem to dialog
                TextItem curTextItem = selItem as TextItem;
                textItemDialog.TextItem = curTextItem;

                if (textItemDialog.ShowDialog() == true)
                {
                    //update TextItem based on dialog result
                    curTextItem.UpdateFrom(textItemDialog.TextItem);

                   
                    //update editor's surface
                    thermalLabelEditor1.UpdateSelectionItemsProperties();
                }
            }
            else if (selItem is BarcodeItem)
            {
                //create and open BarcodeItemDialog
                BarcodeItemDialog bcItemDialog = new BarcodeItemDialog();
                bcItemDialog.Owner = this;
                //set current BarcodeItem to dialog
                BarcodeItem curBarcodeItem = selItem as BarcodeItem;
                bcItemDialog.BarcodeItem = curBarcodeItem;

                if (bcItemDialog.ShowDialog() == true)
                {
                    //update BarcodeItem based on dialog result
                    curBarcodeItem.UpdateFrom(bcItemDialog.BarcodeItem);

                    //update editor's surface
                    thermalLabelEditor1.UpdateSelectionItemsProperties();
                }
            }
            else if (selItem is RFIDTagItem)
            {
                //create and open RFIDTagItemDialog
                RFIDTagItemDialog rfidTagItemDialog = new RFIDTagItemDialog();
                rfidTagItemDialog.Owner = this;
                //set current RFIDTagItem to dialog
                RFIDTagItem curRFIDTagItem = selItem as RFIDTagItem;
                rfidTagItemDialog.RFIDTagItem = curRFIDTagItem;

                if (rfidTagItemDialog.ShowDialog() == true)
                {
                    //update RFIDTagItem based on dialog result
                    curRFIDTagItem.UpdateFrom(rfidTagItemDialog.RFIDTagItem);

                    //update editor's surface
                    thermalLabelEditor1.UpdateSelectionItemsProperties();
                }
            }
        }


        private void menuOptions_Click(object sender, RoutedEventArgs e)
        {
            //is there any label on the editor's surface...
            if (thermalLabelEditor1.LabelDocument != null)
            {
                //Open dialog for View settings
                Dialogs.ViewOptionsDialog viewOpt = new Dialogs.ViewOptionsDialog();
                viewOpt.ShowGrid = thermalLabelEditor1.ShowGrid;
                viewOpt.GridSize = thermalLabelEditor1.GridSize;
                viewOpt.SnapToGrid = thermalLabelEditor1.SnapToGrid;
                viewOpt.AngleSnap = thermalLabelEditor1.AngleSnap;
                viewOpt.ArrowKeysShortStep = thermalLabelEditor1.ArrowKeysShortStep;
                viewOpt.ArrowKeysLargeStep = thermalLabelEditor1.ArrowKeysLargeStep;

                viewOpt.SetUnitLegends(thermalLabelEditor1.LabelDocument.UnitType);

                viewOpt.Owner = this;

                if (viewOpt.ShowDialog() == true)
                {
                    thermalLabelEditor1.ShowGrid = viewOpt.ShowGrid;
                    thermalLabelEditor1.GridSize = viewOpt.GridSize;
                    thermalLabelEditor1.SnapToGrid = viewOpt.SnapToGrid;
                    thermalLabelEditor1.AngleSnap = viewOpt.AngleSnap;
                    thermalLabelEditor1.ArrowKeysShortStep = viewOpt.ArrowKeysShortStep;
                    thermalLabelEditor1.ArrowKeysLargeStep = viewOpt.ArrowKeysLargeStep;
                }
            }
        }

        private void menuPrint_Click(object sender, RoutedEventArgs e)
        {

            //Create the ThermalLabel obj from the editor
            ThermalLabel tLabel = thermalLabelEditor1.CreateThermalLabel();

            if (tLabel != null)
            {
                //Display Print Job dialog...           
                PrintJobDialog frmPrintJob = new PrintJobDialog();
                frmPrintJob.Owner = this;
                if (frmPrintJob.ShowDialog() == true)
                {
                    //create a PrintJob object
                    using (WindowsPrintJob pj = new WindowsPrintJob(frmPrintJob.PrinterSettings))
                    {
                        pj.Copies = frmPrintJob.Copies; // set copies
                        pj.PrintOrientation = frmPrintJob.PrintOrientation; //set orientation
                        pj.ThermalLabel = tLabel; // set the ThermalLabel object
                        if (frmPrintJob.PrintAsGraphic)
                            pj.PrintAsGraphic(); //print to any printer using Windows driver
                        else
                            pj.Print(); //print to thermal printer                  
                    }
                }
            }
        }

        private void menuAbout_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.neodynamic.com/products/printing/thermal-label/editor");

        }

        private void menuPdf_Click(object sender, RoutedEventArgs e)
        {
            //Create the ThermalLabel obj from the editor
            ThermalLabel tLabel = thermalLabelEditor1.CreateThermalLabel();

            if (tLabel != null)
            {
                //open save dialog...
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.DefaultExt = ".pdf";
                dlg.Filter = "Adobe PDF (.pdf)|*.pdf";
                if (dlg.ShowDialog() == true)
                {
                    try
                    {
                        //export ThermalLabel to PDF
                        using (PrintJob pj = new PrintJob())
                        {
                            pj.ThermalLabel = tLabel;
                            pj.ExportToPdf(dlg.FileName, 96);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void menuUploadTTFToPrinterStorage_Click(object sender, RoutedEventArgs e)
        {
            Dialogs.TTFtoPrinterStorageDialog ttfToPrinter = new Dialogs.TTFtoPrinterStorageDialog();
            ttfToPrinter.Owner = this;
            ttfToPrinter.ShowDialog();
        }

        private void menuManageFontsInPrinterStorage_Click(object sender, RoutedEventArgs e)
        {
            Dialogs.PrinterFontsDialog printerFonts = new Dialogs.PrinterFontsDialog();
            printerFonts.Owner = this;
            printerFonts.ShowDialog();
        }

        private void thermalLabelEditor1_CurrentSelectionBeforeDelete(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = (MessageBox.Show("Do you really want to delete the selected items?", "Delete Current Selection", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No);
        }

        private void CmExpression_Click(object sender, RoutedEventArgs e)
        {
            //get current selection
            Item selItem = thermalLabelEditor1.CurrentSelection;
            
            //show Expression dialog
            ExpressionDialog exprDialog = new ExpressionDialog();
            exprDialog.Owner = this;

            exprDialog.Expression = selItem.Expression;

            if (thermalLabelEditor1.LabelDocument != null)
                exprDialog.CurrentThermalLabel = thermalLabelEditor1.CreateThermalLabel();
            else
                exprDialog.CurrentThermalLabel = null;

            if (exprDialog.ShowDialog() == true)
            {
                //get new Expression
                selItem.Expression = exprDialog.Expression;
                
                //update editor's surface
                thermalLabelEditor1.UpdateSelectionItemsProperties();
            }

        }
    }
}
