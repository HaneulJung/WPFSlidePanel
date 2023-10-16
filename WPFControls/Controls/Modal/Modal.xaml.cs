using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFControls.Utilities;

namespace WPFControls.Controls
{
    /// <summary>
    /// Modal.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Modal : UserControl
    {
        private Lazy<AnimationManager> _popupAnimationLazy;
        private Border? _bodyBorder;

        public AnimationManager PopupAnimation => _popupAnimationLazy.Value;
        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(Modal), new PropertyMetadata(false, IsOpenChanged));

        private static void IsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Modal modal)
            {
                bool isOpen = (bool)e.NewValue;
                if (isOpen) 
                {
                    modal.BringToFront();
                    modal.PopupAnimation.SetMarginProperty(from: new Thickness(600), to: new Thickness(8), milliseconds: 400);
                    modal.PopupAnimation.Begin();
                    modal.Visibility = Visibility.Visible;
                }
                else
                {
                    modal.Visibility = Visibility.Collapsed;
                }
            }
        }

        public new SolidColorBrush Background
        {
            get { return (SolidColorBrush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        public new static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(SolidColorBrush), typeof(Modal), new PropertyMetadata(Brushes.White));


        public SolidColorBrush ShadowColor
        {
            get { return (SolidColorBrush)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register("ShadowColor", typeof(SolidColorBrush), typeof(Modal), new PropertyMetadata(Brushes.Gray));

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _bodyBorder = (Border)GetTemplateChild("bodyBorder");
        }

        public Modal()
        {
            InitializeComponent();
            _popupAnimationLazy = new Lazy<AnimationManager>(()=>new AnimationManager(_bodyBorder!));
            Visibility = Visibility.Hidden;
        }

        private void opacityGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IsOpen = false;
        }
    }
}
