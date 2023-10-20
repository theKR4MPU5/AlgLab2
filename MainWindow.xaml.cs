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

namespace AlgLab2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            //FractalCanvas fractalCanvas = new FractalCanvas();
            //fractalCanvas.DrawSierpinskiCarpet(3, 150, 10, 500);
            //Content = fractalCanvas;

            //FractalCanvas fractalCanvas = new FractalCanvas();
            //fractalCanvas.DrawSierpinskiTriangle(new Point(400, 25), new Point(100, 425), new Point(700, 425), 10);
            //Content = fractalCanvas;
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // Обработчик выбора фрактала
            RadioButton radioButton = (RadioButton)sender;
            // Здесь можно выполнять действия в зависимости от выбранного фрактала
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            int depth;
            if (int.TryParse(depthTextBox.Text, out depth))
            {
                // Получить значение глубины из текстового поля

                if (triangleRadioButton.IsChecked == true)
                {
                    FractalCanvas fractalCanvas = new FractalCanvas();
                    fractalCanvas.DrawSierpinskiTriangle(new Point(400, 25), new Point(100, 425), new Point(700, 425), depth);
                    Content = fractalCanvas;
                }
                else if (carpetRadioButton.IsChecked == true)
                {
                    FractalCanvas fractalCanvas = new FractalCanvas();
                    fractalCanvas.DrawSierpinskiCarpet(depth, 150, 10, 500);
                    Content = fractalCanvas;
                    
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректное значение глубины.");
            }
        }
    }
}
