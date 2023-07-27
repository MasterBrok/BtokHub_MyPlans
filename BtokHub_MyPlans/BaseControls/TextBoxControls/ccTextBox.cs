using System.Windows;
using System.Windows.Controls;

namespace BtokHub_MyPlans.BaseControls.TextBoxControls
{
    
    public class ccTextBox : TextBox
    {
        static ccTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ccTextBox), new FrameworkPropertyMetadata(typeof(ccTextBox)));
        }
    }
}
