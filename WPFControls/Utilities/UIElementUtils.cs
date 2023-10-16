using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFControls.Utilities
{
    public static class UIElementUtils
    {
        public static void BringToFront(this UIElement uiElement)
        {
            Panel.SetZIndex(uiElement, int.MaxValue);
        }

        public static void SendToBack(this UIElement uiElement)
        {
            Panel.SetZIndex(uiElement, int.MinValue);
        }
    }
}
