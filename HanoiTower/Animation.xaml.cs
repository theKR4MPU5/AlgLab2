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

namespace HanoiTower;

public partial class Animation
{
    readonly RingsSettings ringsConfig;
    readonly List<Tuple<int, int>> _motion = new();
    double speed = 2 * 0.1;

    public Animation(RingsSettings ringsConfig, double animationSpeed)
    {
        InitializeComponent();
        this.ringsConfig = ringsConfig;
        speed = 1/animationSpeed;
        Start();
    }

    private async void Start()
    {
        CreateArea();
        HanoiTower(ringsConfig.Count);
        foreach (var tuple in _motion)
        {
            await Move(tuple.Item1, tuple.Item2);
        }
    }

    private void HanoiTower(int n, int from = 0, int to = 1, int dest = 2)
    {
        if (n <= 0) return;

        HanoiTower(n - 1, from, dest, to);

        _motion.Add(new Tuple<int, int>(from, to));

        HanoiTower(n - 1, dest, to, from);
    }

    private void Anima(Ellipse rec, int to, DoubleAnimation leftAnimation, DoubleAnimation bottomAnimation)
    {
        leftAnimation.From = Canvas.GetLeft(rec);
        bottomAnimation.From = Canvas.GetBottom(rec);

        switch (to)
        {
            case 0:
                leftAnimation.To = Canvas.GetLeft(Column1) + ((Column1.Width / 2) - (rec.Width / 2));
                bottomAnimation.To = Canvas.GetBottom(Column1) + (Column1.Children.Count * RingsSettings.Height);
                break;
            case 1:
                leftAnimation.To = Canvas.GetLeft(Column2) + ((Column2.Width / 2) - rec.Width / 2);
                bottomAnimation.To = Canvas.GetBottom(Column1) + (Column2.Children.Count * RingsSettings.Height);
                break;
            case 2:
                leftAnimation.To = Canvas.GetLeft(Column3) + (Column3.Width / 2 - rec.Width / 2);
                bottomAnimation.To = Canvas.GetBottom(Column1) + (Column3.Children.Count * RingsSettings.Height);
                break;
        }
        leftAnimation.Duration = TimeSpan.FromSeconds(speed);
        bottomAnimation.Duration = TimeSpan.FromSeconds(speed);
    }

    private void EllipseCopy(Ellipse source, Ellipse copy, int sourceCol)
    {
        copy.Fill = source.Fill;
        copy.Width = source.Width;
        copy.Height = source.Height;

        switch (sourceCol)
        {
            case 0:
                Canvas.SetLeft(copy, Canvas.GetLeft(source) + Canvas.GetLeft(Column1));
                Canvas.SetBottom(copy, Canvas.GetBottom(source) + Canvas.GetBottom(Column1));
                break;
            case 1:
                Canvas.SetLeft(copy, Canvas.GetLeft(source) + Canvas.GetLeft(Column2));
                Canvas.SetBottom(copy, Canvas.GetBottom(source) + Canvas.GetBottom(Column2));
                break;
            case 2:
                Canvas.SetLeft(copy, Canvas.GetLeft(source) + Canvas.GetLeft(Column3));
                Canvas.SetBottom(copy, Canvas.GetBottom(source) + Canvas.GetBottom(Column3));
                break;
        }
    }

    private async Task Move(int from, int to)
    {
        Canvas fromCol = from switch
        {
            0 => Column1,
            1 => Column2,
            2 => Column3,
            _ => Column1
        };
        Canvas toCol = to switch
        {
            0 => Column1,
            1 => Column2,
            2 => Column3,
            _ => Column1
        };
        DoubleAnimation leftAnimation = new DoubleAnimation();
        DoubleAnimation bottomAnimation = new DoubleAnimation();

        Ellipse copy = new Ellipse();
        Ellipse ring = (Ellipse)fromCol.Children[^1];

        EllipseCopy(ring, copy, from);
        Anima(copy, to, leftAnimation, bottomAnimation);
        fromCol.Children.Remove(ring);
        MainCanvas.Children.Add(copy);
        copy.BeginAnimation(Canvas.LeftProperty, leftAnimation);
        copy.BeginAnimation(Canvas.BottomProperty, bottomAnimation);
        Canvas.SetBottom(ring, toCol.Children.Count * RingsSettings.Height);
        await Task.Delay((int)(speed * 1000));
        toCol.Children.Add(ring);
        MainCanvas.Children.Remove(copy);
    }

    private void CreateArea()
    {
        Column1.Children.Clear();
        Column2.Children.Clear();
        Column3.Children.Clear();

        int ringWidth = RingsSettings.MaxWidth;
        for (int ringNumber = 0; ringNumber < ringsConfig.Count; ringNumber++)
        {
            Ellipse ring = new Ellipse
            {
                Width = ringWidth - ringNumber * (RingsSettings.Difference),
                Height = RingsSettings.Height,
                Fill = Brush.RingsBrusher(ringNumber)
            };
            Canvas.SetLeft(ring, 120 - ring.Width / 2);
            Canvas.SetBottom(ring, ring.Height * ringNumber);
            Column1.Children.Add(ring);
        }
    }

}