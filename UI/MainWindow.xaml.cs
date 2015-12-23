using System.Windows;
using Microsoft.Win32;
using BinaryToXmlConverter;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OpenFileDialog fileDialog = new OpenFileDialog();
        private BinaryToXmlConverterHelper converter = new BinaryToXmlConverterHelper();
        public MainWindow()
        {
            InitializeComponent();
            fileDialog.FileOk += FileDialog_FileOk;
        }

        private void FileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            lblFileName.Content = fileDialog.FileName;
            lblFileName.ToolTip = fileDialog.FileName;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            fileDialog.ShowDialog();
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            string text = converter.ConvertToXmlWithBase64(fileDialog.FileName);
            txtXml.Text = text;
        }

        private void btnCopyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txtXml.Text);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            fileDialog.Reset();
            Reset();
        }

        private void Reset()
        {
            lblFileName.Content = null;
            txtXml.Text = null;
        }
    }
}
