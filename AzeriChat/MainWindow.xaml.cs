#nullable disable

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace AzeriChat
{
    public partial class MainWindow : Window
    {
        private bool autosave = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Load_From(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Metin Dosyaları|*.txt|Tüm Dosyalar|*.*";
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                try
                {
                    string fileContent = System.IO.File.ReadAllText(selectedFilePath);
                    TextBox1.Text = fileContent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.Filter = "Metin Dosyaları|*.txt|Tüm Dosyalar|*.*";
            bool? result = saveFileDialog.ShowDialog();
            if (result == true)
            {
                string selectedFilePath = saveFileDialog.FileName;
                string textToSave = TextBox1.Text;
                try
                {
                    System.IO.File.WriteAllText(selectedFilePath, textToSave);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ToLeft(object sender, RoutedEventArgs e)
        {
            if (TextBox1 != null)
                TextBox1.TextAlignment = TextAlignment.Left;
        }

        private void ToCenter(object sender, RoutedEventArgs e)
        {
            if (TextBox1 != null)
                TextBox1.TextAlignment = TextAlignment.Center;
        }

        private void ToRight(object sender, RoutedEventArgs e)
        {
            if (TextBox1 != null)
                TextBox1.TextAlignment = TextAlignment.Right;
        }

        private void ToJustify(object sender, RoutedEventArgs e)
        {
            if (TextBox1 != null)
                TextBox1.TextAlignment = TextAlignment.Justify;
        }

        private void Bold_Selected(object sender, RoutedEventArgs e)
        {
            TextBox1.FontWeight = FontWeights.Bold;
        }

        private void Bold_Unselected(object sender, RoutedEventArgs e)
        {
            TextBox1.FontWeight = FontWeights.Normal;
        }

        private void Italic_Selected(object sender, RoutedEventArgs e)
        {
            TextBox1.FontStyle = FontStyles.Italic;
        }

        private void Italic_Unselected(object sender, RoutedEventArgs e)
        {
            TextBox1.FontStyle = FontStyles.Normal;
        }

        private void Underline_Selected(object sender, RoutedEventArgs e)
        {
            TextDecoration underline = new TextDecoration();
            underline.Location = TextDecorationLocation.Underline;
            TextBox1.TextDecorations = new TextDecorationCollection(new List<TextDecoration> { underline });
        }

        private void Underline_Unselected(object sender, RoutedEventArgs e)
        {
            TextBox1.TextDecorations = new TextDecorationCollection();
        }

        private void Toggle_Check(object sender, RoutedEventArgs e)
        {
            autosave = true;
        }

        private void Toggle_Uncheck(object sender, RoutedEventArgs e)
        {
            autosave = false;
        }

        private void FontSize_Changed(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)FontSizeCombo.SelectedItem;
            if (selectedItem != null)
            {
                string selectedFontSize = selectedItem.Content.ToString();
                if (TextBox1 != null)
                    TextBox1.FontSize = Convert.ToDouble(selectedFontSize);
            }
        }

        private void TextBox1_Changed(object sender, TextChangedEventArgs e)
        {
            if (autosave)
            {
                string textToSave = TextBox1.Text;
                string filePath = "text.txt";
                try
                {
                    System.IO.File.WriteAllText(filePath, textToSave);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}