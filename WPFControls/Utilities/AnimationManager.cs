using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WPFControls.Utilities
{
    public class AnimationManager
    {
        private readonly FrameworkElement _targetElement;
        private readonly Lazy<Storyboard> _storyboardLazy = new Lazy<Storyboard>(() => new Storyboard());
        private readonly Lazy<DoubleAnimation> _doubleAnimationLazy = new Lazy<DoubleAnimation>(() => new DoubleAnimation());
        private readonly Lazy<ThicknessAnimation> _thicknessAnimationLazy = new Lazy<ThicknessAnimation>(() => new ThicknessAnimation());

        public Storyboard Storyboard => _storyboardLazy.Value;
        public DoubleAnimation DoubleAnimation => _doubleAnimationLazy.Value;
        public ThicknessAnimation ThicknessAnimation => _thicknessAnimationLazy.Value;

        public AnimationManager(FrameworkElement targetElement)
        {
            _targetElement = targetElement;
        }

        public void SetLeftProperty(double from, double to, double milliseconds)
        {
            Storyboard.Children.Clear();

            DoubleAnimation.From = from;
            DoubleAnimation.To = to;
            DoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(milliseconds));
            Storyboard.Children.Add(DoubleAnimation);

            Storyboard.SetTarget(DoubleAnimation, _targetElement);
            Storyboard.SetTargetProperty(DoubleAnimation, new PropertyPath(Canvas.LeftProperty));
        }

        public void SetMarginProperty(Thickness from, Thickness to, double milliseconds)
        {
            Storyboard.Children.Clear();

            ThicknessAnimation.From = from;
            ThicknessAnimation.To = to;
            ThicknessAnimation.Duration = TimeSpan.FromMilliseconds(milliseconds);

            Storyboard.Children.Add(ThicknessAnimation);

            Storyboard.SetTarget(ThicknessAnimation, _targetElement);
            Storyboard.SetTargetProperty(ThicknessAnimation, new PropertyPath(FrameworkElement.MarginProperty));
        }

        public void Begin()
        {
            Storyboard.Begin();
        }
    }
}
