
using BtokHub_MyPlans.BrokHub.BrokData;
using BtokHub_MyPlans.BrokHub.BrokICommands;
using BtokHub_MyPlans.BrokHub.BrokModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace BtokHub_MyPlans.BrokHub.BrokViewModels
{
    public class NewPlanViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void Notify(string target)
        {
            if (PropertyChanged is not null)
                PropertyChanged(this, new PropertyChangedEventArgs(target));
        }

        private readonly string[] ColorItems = new string[] { "bgItem1", "bgItem2", "bgItem3", "bgItem4", "bgItem5", "bgItem6" };
        private readonly string[] IconItems = new string[] { "IconWork", "IconStudy", "IconSocial", "IconSelfCare", "IconPlay", "IconEllipsis", "IconExercise", "IconEmpty" };
        private Plan? _plan;




        private ICommand _cmdAdd;

        public ICommand CmdAdd
        {
            get
            {
                if (_cmdAdd is null)
                    _cmdAdd = new IBrokCommand(AddList_Click, CanAddList_Click);
                return _cmdAdd;
            }
        }


        private ICommand _cmdDWM;

        public ICommand CmdDwm
        {
            get
            {
                if (_cmdDWM is null)
                    _cmdDWM = new IBrokCommand(DWM_Select, CanDWM_Select);
                return _cmdDWM;
            }
        }


        private ICommand _cmdClear;

        public ICommand CmdClear
        {
            get
            {
                if (_cmdClear is null)
                    _cmdClear = new IBrokCommand(Change_Click, CanChange_Click);
                return _cmdClear;
            }
        }

        private bool CanChange_Click(object obj)
        {
            return true;
        }

        private void Change_Click(object obj)
        {
            try
            {
                Plan = new Plan()
                {
                    Code = new Random().Next(0, 9999),
                    PlanSetting = new PlanSetting()
                    {
                        Color = RandomColor,
                        Icon = RandomIcon,
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CanDWM_Select(object obj)
        {
            return true;
        }

        private void DWM_Select(object obj)
        {
            Notify(nameof(Plan));
            Plan.Dwm = (Dwm)Enum.Parse(typeof(Dwm), obj.ToString());
            Notify(nameof(Plan));
        }

        private bool CanAddList_Click(object obj)
        {
            return true;
        }

        private async void AddList_Click(object obj)
        {
            var list = BrokConverterXML.ReadData() ?? new ObservableCollection<Plan>();
            list.Add(Plan);
            await BrokConverterXML.WriteData(list.ToList());
            Plan = new Plan()
            {
                Code = new Random().Next(0, 9999),
                PlanSetting = new PlanSetting()
                {
                    Color = RandomColor,
                    Icon = RandomIcon,
                }
            };
        }

        public Plan? Plan
        {
            get { return _plan; }
            set
            {
                _plan = value;
                Notify(nameof(Plan));
            }
        }




        public NewPlanViewModel()
        {
            Plan = new Plan()
            {
                Code = new Random().Next(0, 9999),
                PlanSetting = new PlanSetting()
                {
                    Color = RandomColor,
                    Icon = RandomIcon,
                }
            };
        }



        private string? RandomColor
        {
            get
            {
                return Application.Current.FindResource(ColorItems[new Random().Next(0, ColorItems.Length)]).ToString();
            }
        }
        private string? RandomIcon
        {
            get
            {
                return Application.Current.FindResource(IconItems[new Random().Next(0, IconItems.Length)]).ToString();
            }
        }


    }
}
