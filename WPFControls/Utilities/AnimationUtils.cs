using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Animation;

namespace WPFControls.Utilities
{
    public static class AnimationUtils
    {
        public static Storyboard CreateLeftPropertyStoryboard(this FrameworkElement frameworkElement, double from, double to, double milliseconds)
        {
            Storyboard storyboard = new Storyboard();

            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = from;
            doubleAnimation.To = to;
            doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(milliseconds));
            storyboard.Children.Add(doubleAnimation);

            Storyboard.SetTarget(doubleAnimation, frameworkElement);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Canvas.LeftProperty));

            return storyboard;
        }
    }
}
