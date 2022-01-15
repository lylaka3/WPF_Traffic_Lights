using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;

namespace XamlApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // Переключение режима
        bool auto;

        public void Auto(TextBox red, TextBox yellow, TextBox green)
        {
            auto = true;
            Timer(red, yellow, green);
        }
        public void Manual(TextBox red, TextBox yellow, TextBox green)
        {
            File.WriteAllText("settings.txt", "m");
            File.AppendAllText("settings.txt", Environment.NewLine);
            File.AppendAllText("settings.txt", red.Text);
            File.AppendAllText("settings.txt", Environment.NewLine);
            File.AppendAllText("settings.txt", yellow.Text);
            File.AppendAllText("settings.txt", Environment.NewLine);
            File.AppendAllText("settings.txt", green.Text);
            auto = false;
        }
        public void Red()
        {
            RedColor.Fill = Brushes.Red;
            YellowColor.Fill = Brushes.DarkGoldenrod;
            GreenColor.Fill = Brushes.DarkGreen;
        }
        public void Yellow()
        {
            RedColor.Fill = Brushes.Maroon;
            YellowColor.Fill = Brushes.Yellow;
            GreenColor.Fill = Brushes.DarkGreen;
        }
        public void Green()
        {
            RedColor.Fill = Brushes.Maroon;
            YellowColor.Fill = Brushes.DarkGoldenrod;
            GreenColor.Fill = Brushes.Lime;
        }
        async public void Timer(TextBox red, TextBox yellow, TextBox green)
        {
            while (auto)
            {
                File.WriteAllText("settings.txt", "a");
                File.AppendAllText("settings.txt", Environment.NewLine);
                File.AppendAllText("settings.txt", red.Text);
                File.AppendAllText("settings.txt", Environment.NewLine);
                File.AppendAllText("settings.txt", yellow.Text);
                File.AppendAllText("settings.txt", Environment.NewLine);
                File.AppendAllText("settings.txt", green.Text);
                int redDuration, yellowDuration, greenDuration;
                if (red.Text == "") redDuration = 5000;
                else redDuration = Convert.ToInt32(red.Text) * 1000;
                if (yellow.Text == "") yellowDuration = 5000;
                else yellowDuration = Convert.ToInt32(yellow.Text) * 1000;
                if (green.Text == "") greenDuration = 5000;
                else greenDuration = Convert.ToInt32(green.Text) * 1000;
                RedColor.Fill = Brushes.Red;
                YellowColor.Fill = Brushes.DarkGoldenrod;
                GreenColor.Fill = Brushes.DarkGreen;
                for (int i = redDuration; i > 0; i -= 1000)
                {
                    timer.Text = (i / 1000).ToString();
                    await Task.Delay(1000);
                }
                RedColor.Fill = Brushes.Maroon;
                YellowColor.Fill = Brushes.Yellow;
                for (int i = yellowDuration; i > 0; i -= 1000)
                {
                    timer.Text = (i / 1000).ToString();
                    await Task.Delay(1000);
                }
                YellowColor.Fill = Brushes.DarkGoldenrod;
                GreenColor.Fill = Brushes.Lime;
                for (int i = greenDuration; i > 0; i -= 1000)
                {
                    timer.Text = (i / 1000).ToString();
                    await Task.Delay(1000);
                }
                YellowColor.Fill = Brushes.Yellow;
                GreenColor.Fill = Brushes.DarkGreen;
                for (int i = yellowDuration; i > 0; i -= 1000)
                {
                    timer.Text = (i / 1000).ToString();
                    await Task.Delay(1000);
                }
            }
            YellowColor.Fill = Brushes.DarkGoldenrod;
            timer.Text = "0";
        }
    }
}