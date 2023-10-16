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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFControls.Utilities;

namespace WPFControls.Controls
{
    /// <summary>
    /// SlidePanel.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SlidePanel : UserControl
    {
        private Border? _slider;
        private SliderState _sliderState = SliderState.Closed;
        private readonly Lazy<AnimationManager> _slideAnimationLazy;
        private readonly Lazy<AnimationManager> _leftAnimationLazy;

        public AnimationManager SlideAnimationLazy => _slideAnimationLazy.Value;
        public AnimationManager LeftAnimationLazy => _leftAnimationLazy.Value;

        public static readonly DependencyProperty SliderWidthProperty =
            DependencyProperty.Register("SliderWidth", typeof(double), typeof(SlidePanel), new PropertyMetadata(300d, OnSliderChanged));

        public static readonly DependencyProperty SliderLocationProperty =
            DependencyProperty.Register("SliderLocation", typeof(SliderLocation), typeof(SlidePanel), new PropertyMetadata(SliderLocation.Left, OnSliderChanged));

        public double SliderWidth
        {
            get { return (double)GetValue(SliderWidthProperty); }
            set { SetValue(SliderWidthProperty, value); }
        }

        public SliderLocation SliderLocation
        {
            get { return (SliderLocation)GetValue(SliderLocationProperty); }
            set { SetValue(SliderLocationProperty, value); }
        }

        public double AnimationSpeed { get; set; } = 300d;

        public double ParentActualWidth
        {
            get
            {
                var parent = Parent as FrameworkElement;
                return parent != null ? parent.ActualWidth : 0;
            }
        }

        private double OpenedLeft => SliderLocation == SliderLocation.Left
            ? 0
            : ParentActualWidth - SliderWidth;

        private double ClosedLeft => SliderLocation == SliderLocation.Left
            ? -SliderWidth
            : ParentActualWidth;




        private static void OnSliderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SlidePanel slidePanel)
            {
                slidePanel.ChangeSliderLeft();
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _slider = (Border)GetTemplateChild("slider");
        }

        private void ChangeSliderLeft()
        {
            if (_slider != null)
            {
                double left = SliderLocation == SliderLocation.Left ? -SliderWidth : ParentActualWidth;
                Canvas.SetLeft(_slider, left);
            }            
        }

        public SlidePanel()
        {
            InitializeComponent();
            Loaded += SlidePanel_Loaded;
            SizeChanged += SlidePanel_SizeChanged;

            _slideAnimationLazy = new Lazy<AnimationManager>(() =>
            {
                var animationManager = new AnimationManager(_slider!);
                animationManager.Storyboard.Completed += Storyboard_Completed;
                return animationManager;
            });

            _leftAnimationLazy = new Lazy<AnimationManager>(() => new AnimationManager(_slider!));
        }

        private void SlidePanel_Loaded(object sender, RoutedEventArgs e)
        {
            this.SendToBack();
            ChangeSliderLeft();
        }

        private void SlidePanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SliderLocation == SliderLocation.Right)
            {
                if (_sliderState == SliderState.Opened || _sliderState == SliderState.Opening)
                {
                    LeftAnimationLazy.SetLeftProperty(from: OpenedLeft, to: OpenedLeft, milliseconds: 0);
                    LeftAnimationLazy.Begin();
                }
                else
                {
                    LeftAnimationLazy.SetLeftProperty(from: ClosedLeft, to: ClosedLeft, milliseconds: 0);
                    LeftAnimationLazy.Begin();
                }
            }
        }

        private (double from, double to) GetLeftRange()
        {
            if (_sliderState == SliderState.Opening)
            {
                return (from: ClosedLeft, to: OpenedLeft);
            }
            else
            {
                return (from: OpenedLeft, to: ClosedLeft);
            }
        }

        private void BeginAnimation()
        {
            var leftRange = GetLeftRange();
            SlideAnimationLazy.SetLeftProperty(from: leftRange.from, to: leftRange.to, milliseconds: AnimationSpeed);
            SlideAnimationLazy.Begin();
        }

        public void Open()
        {
            if (_sliderState != SliderState.Closed) return;

            _sliderState = SliderState.Opening;
            BeginAnimation();
            this.BringToFront();
        }

        public void Close()
        {
            if (_sliderState != SliderState.Opened) return;
            BeginAnimation();
            _sliderState = SliderState.Closing;
        }

        private void Storyboard_Completed(object? sender, EventArgs e)
        {
            if (_sliderState == SliderState.Opening)
            {
                _sliderState = SliderState.Opened;
            }
            else
            {
                _sliderState = SliderState.Closed;
                this.SendToBack();
            }
        }

        private void opacityGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
