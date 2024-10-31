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
        byte arpha = 0;
        DispatcherTimer timer = new DispatcherTimer();


        SolidColorBrush colorBrush;
        private string testText = "this is a test text";

        public string TestText { get => testText; set => SetProperty(ref testText, value); }

        private RelayCommand testBT;
        public ICommand TestBT => testBT ??= new RelayCommand(PerformTestBT);
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
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(50);
            //AcountLists = [new AcountList() {  }, new AcountList() { name = "qian" ,id="2"}];
            AcountLists = new ObservableCollection<AcountList>();
        }
        byte tick;
        private void Timer_Tick(object? sender, EventArgs e)
        {
            arpha++;
            if (arpha >= 255) arpha = 0;
            var a = new Color { A = arpha, R = 100, G = 0, B = 100 };
            colorBrush = new SolidColorBrush(a);
            tick++;
            TestText = tick.ToString();
            var random = new Random().Next(0, 100);
            AcountLists.Add(new AcountList() { name = "xianfei", id = random, time = DateTime.Now.Millisecond });
            //Thread.Sleep(20);
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
                    byte x = 0;
                    while (true)
                    {
                        x++;
                        ProgressValue = x;
                         TestText = x.ToString();
                        if (x >= 100) x = 0;

                        Brush = colorBrush;
                        Thread.Sleep(40);
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

        private bool? isChecked = false;

        public bool? IsChecked { get => isChecked; set => SetProperty(ref isChecked, value); }

        private RelayCommand checkedEvent;
        public ICommand CheckedEvent => checkedEvent ??= new RelayCommand(PerformCheckedEvent);

        private void PerformCheckedEvent()
        {
            ToggleButtonStata = "IsChecked";
            //if (IsChecked == true) ToggleButtonStata = "IsChecked";
            //else ToggleButtonStata = "UnChecked";
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

        private double progressValue;

        public double ProgressValue { get => progressValue; set => SetProperty(ref progressValue, value); }

        private Brush brush;

        public Brush Brush { get => brush; set => SetProperty(ref brush, value); }

        private RelayCommand startTimer;
        public ICommand StartTimer => startTimer ??= new RelayCommand(PerformStartTimer);
        private bool Started;
        private void PerformStartTimer()
        {
            if (!Started)
            {
                Started = true;
                timer.Start();
                TimeStata = "STOP";
            }
            else
            {
                Started = false;
                timer.Stop();
                TimeStata = "START";

            }
        }

        private object timeStata = "START";

        public object TimeStata { get => timeStata; set => SetProperty(ref timeStata, value); }

        private RelayCommand clear;
        public ICommand Clear => clear ??= new RelayCommand(PerformClear);

        private void PerformClear()
        {
            AcountLists.Clear();
        }

        private RelayCommand paste;
        public ICommand Paste => paste ??= new RelayCommand(PerformPaste);

        private void PerformPaste()
        {
            DisplayMessage("test");
        }

        private RelayCommand play;
        public ICommand Play => play ??= new RelayCommand(PerformPlay);

        private void PerformPlay()
        {

        }
    }
}