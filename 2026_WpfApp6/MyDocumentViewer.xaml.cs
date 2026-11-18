using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace _2026_WpfApp6
{
    public partial class MyDocumentViewer : Window
    {
        public MyDocumentViewer()
        {
            InitializeComponent();

            FontFamilyComboBox.ItemsSource = Fonts.SystemFontFamilies;
            FontFamilyComboBox.SelectedIndex = 0;

            double[] fontSizes = new double[] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 24, 28, 36, 48, 72 };
            FontSizeComboBox.ItemsSource = fontSizes;
            FontSizeComboBox.SelectedIndex = 4;

            FontFamilyComboBox.SelectionChanged += FontFamilyComboBox_SelectionChanged;
            FontSizeComboBox.SelectionChanged += FontSizeComboBox_SelectionChanged;
            FontColorPicker.SelectedColorChanged += FontColorPicker_SelectedColorChanged;

            BoldButton.Command = EditingCommands.ToggleBold;
            ItalicButton.Command = EditingCommands.ToggleItalic;
            UnderlineButton.Command = EditingCommands.ToggleUnderline;

            MainRichTextBox.SelectionChanged += MainRichTextBox_SelectionChanged;
        }

        private void FontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontFamilyComboBox.SelectedItem != null && !MainRichTextBox.Selection.IsEmpty)
            {
                MainRichTextBox.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, FontFamilyComboBox.SelectedItem);
            }
        }

        private void FontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontSizeComboBox.SelectedItem != null && !MainRichTextBox.Selection.IsEmpty)
            {
                MainRichTextBox.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, FontSizeComboBox.SelectedItem);
            }
        }

        private void FontColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (e.NewValue.HasValue && !MainRichTextBox.Selection.IsEmpty)
            {
                SolidColorBrush brush = new SolidColorBrush(e.NewValue.Value);
                MainRichTextBox.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, brush);
            }
        }

        private void MainRichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object boldProp = MainRichTextBox.Selection.GetPropertyValue(TextElement.FontWeightProperty);
            BoldButton.IsChecked = (boldProp != DependencyProperty.UnsetValue && boldProp.Equals(FontWeights.Bold));

            object italicProp = MainRichTextBox.Selection.GetPropertyValue(TextElement.FontStyleProperty);
            ItalicButton.IsChecked = (italicProp != DependencyProperty.UnsetValue && italicProp.Equals(FontStyles.Italic));

            object underlineProp = MainRichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            UnderlineButton.IsChecked = (underlineProp != DependencyProperty.UnsetValue && underlineProp.Equals(TextDecorations.Underline));
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MyDocumentViewer newWindow = new MyDocumentViewer();
            newWindow.Show();
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
    }
}