using System.IO;
using System.Windows;

namespace XamlApp
{
    public partial class Setting : Window
    {
        public Setting()
        {
            InitializeComponent();
            mainWindow.Show();
            string[] settings = File.ReadAllLines("settings.txt");
            red.Text = settings[1].ToString();
            yellow.Text = settings[2].ToString();
            green.Text = settings[3].ToString();
            if (settings[0] == "m")
            {
                ManualControl.Visibility = Visibility.Visible;
                mainWindow.Manual(red, yellow, green);
            }
            else
            {
                AutoControl.Visibility = Visibility.Visible;
                mainWindow.Timer(red, yellow, green);
            }
        }

        readonly MainWindow mainWindow = new MainWindow();
        public void AutoButton(object sender, RoutedEventArgs e)
        {
            ManualControl.Visibility = Visibility.Hidden;
            AutoControl.Visibility = Visibility.Visible;
            mainWindow.Auto(red, yellow, green);
        }
        public void ManualButton(object sender, RoutedEventArgs e)
        {
            AutoControl.Visibility = Visibility.Hidden;
            ManualControl.Visibility = Visibility.Visible;
            mainWindow.Manual(red, yellow, green);
        }
        public void RedButton(object sender, RoutedEventArgs e)
        {
            mainWindow.Red();
        }
        public void YellowButton(object sender, RoutedEventArgs e)
        {
            mainWindow.Yellow();
        }
        public void GreenButton(object sender, RoutedEventArgs e)
        {
            mainWindow.Green();
        }

    }
}
