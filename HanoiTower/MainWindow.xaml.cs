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
using System.Windows.Media.Animation;

namespace HanoiTower
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
    {
        var count = Int32.Parse(RingCount.Text);
        if (count < 1 || count > 14)
        {
            MessageBox.Show("Введите количество колец от 1 до 14");
        }
        else
        {
            Brush a = new Brush { RingsCount = Int32.Parse(RingCount.Text) };
            Animation animation = new Animation(a, SpeedSlider.Value);
            animation.ShowDialog();
        }
    }

        }
}

