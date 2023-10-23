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

namespace FractalPrinter
{
    /// <summary>
    /// Логика взаимодействия для ItemLocation1.xaml
    /// </summary>
    public partial class ItemLocation1 : Page
    {

        public ItemLocation1(int depth, string name)
        {
            InitializeComponent();
            FractalCanvas fractalCanvas = new FractalCanvas();
            switch (name)
            {
                case "triangle":
                    fractalCanvas.DrawSierpinskiTriangle(new Point(400, 25), new Point(100, 425), new Point(700, 425), depth);
                    Content = fractalCanvas;
                    break;
                case "carpet":
                    fractalCanvas.DrawSierpinskiCarpet(depth, 150, 10, 500);
                    Content = fractalCanvas;
                    break;
              

            }
            
        }
    }
}
