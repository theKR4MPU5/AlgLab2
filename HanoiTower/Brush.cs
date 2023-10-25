using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace HanoiTower
{
	public class Brush
	{
        public static readonly List<string> ColorsOfPaint = new()
        {
            "#FF0000",
            "#8B0000",
            "#FFA500",
            "#8B4513",
            "#FFFF00",
            "#808000",
            "#008000",
            "#006400",
            "#0000FF",
            "#000080",
            "#4B0082",
            "#2E0854",
            "#FF69B4",
            "#FF1493"
        };

        public static SolidColorBrush RingsBrusher(int colorIndex)
        {
            return (SolidColorBrush)new BrushConverter().ConvertFrom(ColorsOfPaint[colorIndex])!;
        }
    }
}

