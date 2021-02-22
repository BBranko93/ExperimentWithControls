using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExperimentWithControls
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

        private void numberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*This line of code sets the text in the TextBlock so it's
             the same as the text in the TextBox, and it gets called
            any time the user changes the text in the TextBox*/
            number.Text = numberTextBox.Text;
        }
        private void numberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            /*The event handler is called when the user enters text into the TextBox, but before the TextBox is updated.
             It uses a special method called int.TryParse to check if the text that the user entered is a number.
            If the user entered a number, it sets e.Hadled to true, which tells WPF to ignore the input.*/
            e.Handled = !int.TryParse(e.Text, out int result);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                number.Text = radioButton.Content.ToString();
            }
        }

        private void smallSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            /*The value of the Slider is a fractional number with a decimal point.
             This "0" converts it to a whole number.*/
            number.Text = smallSlider.Value.ToString("0");
        }

        private void bigSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            /*The zero and hyphens cause the method to format any 10-digit number
             as a US phone number.*/
            number.Text = bigSlider.Value.ToString("000-000-0000");
        }

        private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (myListBox.SelectedItem is ListBoxItem listBoxItem)
            {
                number.Text = listBoxItem.Content.ToString();
            }
        }

        private void readOnlyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (readOnlyComboBox.SelectedItem is ListBoxItem listBoxItem)
            {
                number.Text = listBoxItem.Content.ToString();
            }
        }
        private void editableComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                number.Text = comboBox.Text;
            }

        }
    }
}
