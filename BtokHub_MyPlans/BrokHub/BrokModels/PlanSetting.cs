
using System;
using System.Windows.Media;

namespace BtokHub_MyPlans.BrokHub.BrokModels
{
 
    [Serializable]
    public class PlanSetting
    {
        public int Code { get; set; }
        public string? Icon{ get; set; }
        public string? Color { get; set; }
    }
}
