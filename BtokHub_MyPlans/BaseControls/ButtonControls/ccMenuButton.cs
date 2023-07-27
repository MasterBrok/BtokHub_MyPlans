
using System.Windows;
using System.Windows.Controls;

namespace BtokHub_MyPlans.BaseControls.ButtonControls
{
    public class ccMenuButton : Button
    {
        static ccMenuButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ccMenuButton), new FrameworkPropertyMetadata(typeof(ccMenuButton)));
        }
    }
}
