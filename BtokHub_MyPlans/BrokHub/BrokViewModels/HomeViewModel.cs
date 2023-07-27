using BtokHub_MyPlans.BrokHub.BrokData;
using BtokHub_MyPlans.BrokHub.BrokICommands;
using BtokHub_MyPlans.BrokHub.BrokModels;
using BtokHub_MyPlans.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace BtokHub_MyPlans.BrokHub.BrokViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void Notify(string target)
        {
            if (PropertyChanged is not null)
                PropertyChanged(this, new PropertyChangedEventArgs(target));
        }

        private ICommand _cmdSelectMenu;
        private ICommand _cmdOpen;
        private ObservableCollection<Plan> _staticPlan;
        private IEnumerable<Plan>? _dynamicPlan;
        public ObservableCollection<Plan> StaticPlan
        {
            get { return _staticPlan; }
            set
            {
                _staticPlan = value;
                Notify(nameof(StaticPlan));
            }
        }
        public ICommand CmdOpen
        {
            get
            {
                if (_cmdOpen == null)
                    _cmdOpen = new IBrokCommand(Open_Click, CanOpen_Click);
                return _cmdOpen;
            }
        }

        public IEnumerable<Plan>? DynamicPlan
        {
            get { return _dynamicPlan; }
            set
            {
                _dynamicPlan = value;
                Notify(nameof(_dynamicPlan));
            }
        }
        public ICommand CmdSelectMenu
        {
            get
            {
                if (_cmdSelectMenu == null)
                    _cmdSelectMenu = new IBrokCommand(SelectMenu_Click, CanSelectMenu_Click);
                return _cmdSelectMenu;
            }
        }

        
        public HomeViewModel()
        {
            UpdateStaticData();
            Notify(nameof(StaticPlan));
        }
        private bool CanOpen_Click(object obj)
        {
            return true;
        }

        private void Open_Click(object obj)
        {
            wNewPlan window = new wNewPlan();
            window.ShowDialog();
        }

        private void UpdateStaticData()
        {
            StaticPlan = BrokConverterXML.ReadData() ?? new ObservableCollection<Plan>();
        }

        private bool CanSelectMenu_Click(object obj)
        {
            return true;
        }

        private void SelectMenu_Click(object obj)
        {
            UpdateStaticData();
            switch (obj is not null ? obj as string : "Daily")
            {
                case "Daily":
                    
                    DynamicPlan = _staticPlan.Where(plan => plan.Dwm.Value == Dwm.Daily);
                    Notify(nameof(DynamicPlan));
                    break;
                case "Weekly":
                    DynamicPlan = _staticPlan.Where(plan => plan.Dwm.Value == Dwm.Weekly);
                    Notify(nameof(DynamicPlan));
                    break;
                case "Monthly":
                    DynamicPlan = _staticPlan.Where(plan => plan.Dwm.Value == Dwm.Monthly);
                    Notify(nameof(DynamicPlan));
                    break;
                default:
                    break;
            }
        }

    }
}
