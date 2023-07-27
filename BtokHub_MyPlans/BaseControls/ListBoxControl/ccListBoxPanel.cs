
using System.Windows;
using System.Windows.Controls;

namespace BtokHub_MyPlans.BaseControls.ListBoxControl
{
    
    public class ccListBoxPanel : ListBox
    {
        static ccListBoxPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ccListBoxPanel), new FrameworkPropertyMetadata(typeof(ccListBoxPanel)));
        }
    }
}
