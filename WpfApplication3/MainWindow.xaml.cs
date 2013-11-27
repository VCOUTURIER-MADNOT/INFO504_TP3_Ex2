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

namespace WpfApplication3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            RowDefinition rd1 = new RowDefinition();
            RowDefinition rd2 = new RowDefinition();

            this.grid.RowDefinitions.Add(rd1);
            this.grid.RowDefinitions.Add(rd2);
            this.grid.ShowGridLines = true;

            TextBox tb = new TextBox();
            tb.Height = 200;
            this.RegisterName("textBox", tb);
            Grid.SetRow(tb, 0);

            WrapPanel wp = new WrapPanel();
            this.RegisterName("keyboard", wp);
            Grid.SetRow(wp, 1);

            this.grid.Children.Add(tb);
            this.grid.Children.Add(wp);

            generateKeyboard();

            this.Height = this.grid.Height;
        }

        private void generateKeyboard()
        {
            WrapPanel wp = (WrapPanel) this.FindName("keyboard");
            for(int i= 97; i <= 122; i++)
            {
                Button button = new Button();
                button.Content = Convert.ToChar(i);
                button.Width = 60;
                button.Height = 50;
                button.Click += onClick;
                wp.Children.Add(button);
            }
        }

        private void showKeyboard(Object sender, EventArgs e)
        {
            WrapPanel wp = (WrapPanel)this.FindName("keyboard");
            wp.Visibility = System.Windows.Visibility.Visible;
        }

        private void hideKeyboard(Object sender, EventArgs e)
        {
            WrapPanel wp = (WrapPanel)this.FindName("keyboard");
            wp.Visibility = System.Windows.Visibility.Hidden;
        }

        private void onClick(Object sender, EventArgs e)
        {
            Button button = (Button)sender;
            TextBox tb = (TextBox)this.FindName("textBox");

            tb.Text += button.Content;
        }
    }
}
