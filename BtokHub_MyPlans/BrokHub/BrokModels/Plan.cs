
using System;
using System.ComponentModel;

namespace BtokHub_MyPlans.BrokHub.BrokModels
{
    [Serializable]
    public enum Dwm
    {
        Daily,
        Weekly,
        Monthly
    }
    [Serializable]
    public class Plan
    {
        public int? Code { get; set; }
        public string? Title { get; set; }
        public string? Current { get; set; }
        public string? Previous { get; set; }
        public Dwm? Dwm { get; set; }
        public PlanSetting? PlanSetting { get; set; }
    }
}
