
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BtokHub_MyPlans.BaseControls.ListBoxControl
{
    
    public class ccListBoxItemPanel : ListBoxItem
    {
        static ccListBoxItemPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ccListBoxItemPanel), new FrameworkPropertyMetadata(typeof(ccListBoxItemPanel)));
        }



        public Brush BackgroundBorderTop
        {
            get { return (Brush)GetValue(BackgroundBorderTopProperty); }
            set { SetValue(BackgroundBorderTopProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackgroundBorderTop.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackgroundBorderTopProperty =
            DependencyProperty.Register("BackgroundBorderTop", typeof(Brush), typeof(ccListBoxItemPanel), new PropertyMetadata(Brushes.MediumBlue));



        public PathGeometry Icon
        {
            get { return (PathGeometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(PathGeometry), typeof(ccListBoxItemPanel), new PropertyMetadata(default));


    }
}
