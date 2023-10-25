using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Numerics;
using System;
using FractalPrinter;
using System.Collections.Generic;

namespace FractalPrinter
{
    public class FractalCanvas : Canvas
    {
        public void DrawSierpinskiTriangle(Point p1, Point p2, Point p3, int depth)
        {
            if (depth == 0)
            {
                // Отрисовываем треугольник
                var polygon = new Polygon();
                polygon.Points.Add(p1);
                polygon.Points.Add(p2);
                polygon.Points.Add(p3);
                polygon.Stroke = Brushes.Black;
                polygon.StrokeThickness = 1;
                polygon.Fill = Brushes.Black; // Закрасить треугольник
                this.Children.Add(polygon);
            }
            else
            {
                // Разбиваем текущий треугольник на 3 более мелких и отрисовываем фрактал для каждого
                var mid1 = new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
                var mid2 = new Point((p2.X + p3.X) / 2, (p2.Y + p3.Y) / 2);
                var mid3 = new Point((p1.X + p3.X) / 2, (p1.Y + p3.Y) / 2);

                DrawSierpinskiTriangle(p1, mid1, mid3, depth - 1);
                DrawSierpinskiTriangle(mid1, p2, mid2, depth - 1);
                DrawSierpinskiTriangle(mid3, mid2, p3, depth - 1);
            }
        }
        public void DrawSierpinskiCarpet(int depth, double x, double y, double size)
        {
            if (depth == 0)
            {
                // Отрисовываем прямоугольник
                var rectangle = new Rectangle
                {
                    Width = size,
                    Height = size,
                    Fill = Brushes.Black
                };

                this.Children.Add(rectangle);
                Canvas.SetLeft(rectangle, x);
                Canvas.SetTop(rectangle, y);
            }
            else
            {
                double newSize = size / 3;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (i != 1 || j != 1)
                        {
                            double newX = x + i * newSize;
                            double newY = y + j * newSize;

                            DrawSierpinskiCarpet(depth - 1, newX, newY, newSize);
                        }
                    }
                }
            }
        }
    }
    

}





