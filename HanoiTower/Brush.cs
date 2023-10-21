using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HanoiTower
{
    public class Brush
    {
        public int RingsCount { get; set; }
        public double Speed { get; set; }
        //public int RingsCount;
        public static readonly int RingMinWidth = 240;
        public static readonly int RingHeight = 30;
        public static readonly int Difference = 14;
        public static SolidColorBrush ColorBrash(string color)
        {
            return (SolidColorBrush)new BrushConverter().ConvertFrom(color)!;
        }

        public static class Colors
        {
            public static readonly List<string> ColorsList = new()
                {
                    "#FF0000", "#8B0000",   // Красный и его темный оттенок
                    "#FFA500", "#8B4513",   // Оранжевый и его темный оттенок
                    "#FFFF00", "#808000",   // Желтый и его темный оттенок
                    "#008000", "#006400",   // Зеленый и его темный оттенок
                    "#0000FF", "#000080",   // Синий и его темный оттенок
                    "#4B0082", "#2E0854",   // Фиолетовый и его темный оттенок
                    "#FF69B4", "#FF1493"
                };
        }
    }
}
