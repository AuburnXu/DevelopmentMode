using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevelopMode.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace DevelopmentMode.ViewModels
{
    public class MainViewModel : ObservableObject
    {

        private string testText = "this is a test text";

        public string TestText { get => testText; set => SetProperty(ref testText, value); }

        private RelayCommand testBT;
        public ICommand TestBT => testBT ??= new RelayCommand(PerformTestBT);

        public RelayCommand Read { set; get; }

        private void PerformTestBT()
        {
            MessageBox.Show("test");

        }
        void DisplayMessage(string message) { MessageBox.Show(message); }

        private ObservableCollection<AcountList> acountLists;

        public ObservableCollection<AcountList> AcountLists { get => acountLists; set => SetProperty(ref acountLists, value); }
        //public ObservableCollection<AcountList> AcountLists =new ObservableCollection<AcountList>();

        public MainViewModel()
        {
            isChecked = false;
            Read = new RelayCommand(() =>
            {
                MessageBox.Show("Read");
            });
            //AcountLists = [new AcountList() {  }, new AcountList() { name = "qian" ,id="2"}];
            AcountLists = new ObservableCollection<AcountList>();

            for (int i = 0; i < 20; i++)
            {
                var a = new Random().Next(0, 100).ToString();
                AcountLists.Add(new AcountList() { name = "xianfei", id = a, time = DateTime.Now.Millisecond.ToString() });
                Thread.Sleep(20);
            }
        }

        private RelayCommand testBehave;
        public ICommand TestBehave => testBehave ??= new RelayCommand(PerformTestBehave);

        private void PerformTestBehave()
        {
            MessageBox.Show("Read");
        }

        private RelayCommand behaviors;
        public ICommand Behaviors => behaviors ??= new RelayCommand(PerformBehaviors);

        private void PerformBehaviors()
        {
            MessageBox.Show("Read");
        }

        private RelayCommand<object>? secondCommand;
        public ICommand SecondCommand => secondCommand ??= new RelayCommand<object>(element => Eidt(element));

        bool isTrue;
        //private RelayCommand? test;
        //public ICommand Test = new RelayCommand<object>(a => Eidt(a));
        private void Eidt(object element)
        {
            if (element != null) DisplayMessage(element.ToString());
            else DisplayMessage("Null");
            if (!isTrue)
            {
                isTrue = true;
                Task.Run(() =>
                {
                    var x = 0;
                    while (true)
                    {
                        x++;
                        TestText = x.ToString();
                        Thread.Sleep(1000);
                    }
                });
            }
        }

        private RelayCommand<object> userSelectedCmd;
        public ICommand UserSelectedCmd => userSelectedCmd ??= new RelayCommand<object>(PerformUserSelectedCmd);

        private void PerformUserSelectedCmd(object element)
        {
            var a = (AcountList)element;
            DisplayMessage(a.name);
        }

        private bool? isChecked;

        public bool? IsChecked { get => isChecked; set => SetProperty(ref isChecked, value); }

        private RelayCommand checkedEvent;
        public ICommand CheckedEvent => checkedEvent ??= new RelayCommand(PerformCheckedEvent);

        private void PerformCheckedEvent()
        {
            if (IsChecked == true) ToggleButtonStata = "IsChecked";
            else ToggleButtonStata = "UnChecked";
            //DisplayMessage("CheckedEvent");
        }

        private string toggleButtonStata;

        public string ToggleButtonStata { get => toggleButtonStata; set => SetProperty(ref toggleButtonStata, value); }

        private RelayCommand toggleUnchecked;
        public ICommand ToggleUnchecked => toggleUnchecked ??= new RelayCommand(PerformToggleUnchecked);

        private void PerformToggleUnchecked()
        {
            ToggleButtonStata = "UnChecked";
        }
    }
}