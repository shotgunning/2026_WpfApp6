using System.Windows;
using System.Windows.Input;

namespace _2026_WpfApp6
{
    /// <summary>
    /// MyDocumentViewer.xaml 的互動邏輯
    /// </summary>
    public partial class MyDocumentViewer : Window
    {
        public MyDocumentViewer()
        {
            InitializeComponent();
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