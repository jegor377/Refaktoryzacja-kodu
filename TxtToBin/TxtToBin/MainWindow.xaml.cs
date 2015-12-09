using System;
using System.Windows;
using System.Windows.Documents;
using TxtToBin.Converter;

namespace TxtToBin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public NumeralSystemConverter Converter = null;

        public MainWindow()
        {
            InitializeComponent();
            Converter = new BinAndTextConverter();
        }

        private void ToBin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var binary = Converter.ConvertToNumbers(new TextRange(TextBox.Document.ContentStart, TextBox.Document.ContentEnd).Text);
                if (!binary.Equals(""))
                {
                    BinaryBox.Document.Blocks.Clear();
                    BinaryBox.Document.Blocks.Add(new Paragraph(new Run(binary)));
                }
            }
            catch(Exception)
            {
                MessageBox.Show("You wrote some wrong value");
            }
        }

        private void ToText_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var text = Converter.ConvertFromNumbers(new TextRange(BinaryBox.Document.ContentStart, BinaryBox.Document.ContentEnd).Text);
                if (!text.Equals(""))
                {
                    TextBox.Document.Blocks.Clear();
                    TextBox.Document.Blocks.Add(new Paragraph(new Run(text)));
                }
            }
            catch(Exception)
            {
                MessageBox.Show("You wrote some wrong value");
            }
        }

        private void AsBin_Click(object sender, RoutedEventArgs e)
        {
            Converter = new BinAndTextConverter();
        }

        private void AsHex_Click(object sender, RoutedEventArgs e)
        {
            Converter = new HexAndTextConverter();
        }

        private void AsDec_Click(object sender, RoutedEventArgs e)
        {
            Converter = new DecAndTextConverter();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This program is used to converting between string of numbers and text.", "About this program");
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Author: Igor Santarek\n"
                          + "Version: 1.0v", "Info");
        }
    }
}
