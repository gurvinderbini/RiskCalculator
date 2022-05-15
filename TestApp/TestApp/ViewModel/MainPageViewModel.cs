using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TestApp.DB;
using TestApp.Models;
using TestApp.View;
using Xamarin.Forms;

namespace TestApp.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {

        #region CTOR
        public MainPageViewModel()
        {
            SelectedDate = DateTime.Now;
        }

        #endregion

        #region Propeties
        public ObservableCollection<CalculationModel> CalculationList { get; set; }

        public List<CalculationModel> CalculationListComplete { get; set; }

        public DateTime SelectedDate { get; set; }
        #endregion

        #region Commands
        public ICommand PrevCommand => new Command(() =>
       {
           SelectedDate = SelectedDate.AddDays(-1);
       });

        public ICommand NextCommand => new Command(() =>
        {
            SelectedDate = SelectedDate.AddDays(1);

        });

        public ICommand DateSelectedCommand => new Command<DateChangedEventArgs>((s) =>
        {
            SortByDate();
        });

        public ICommand OnAppearingCommand => new Command<EventArgs>((s) =>
        {
            Initilize();
        });

        public ICommand EditCommand => new Command<CalculationModel>((s) =>
        {
            App.Current.MainPage.Navigation.PushAsync(new CalculatorPage(s));
        });
        public ICommand AddCommand => new Command(() =>
        {
            App.Current.MainPage.Navigation.PushAsync(new CalculatorPage(null));
        });
        #endregion

        #region Methods
        private async void Initilize()
        {
            try
            {
                CalculationDatabase database = await CalculationDatabase.Instance;
                var calculations = await database.GetItemsAsync();
                if (calculations != null)
                {
                    CalculationListComplete = calculations;
                    SortByDate();
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void SortByDate()
        {
            try
            {
                if (CalculationListComplete != null)
                {
                    CalculationList = new ObservableCollection<CalculationModel>(CalculationListComplete.Where(s => s.Date.Date == SelectedDate.Date));
                }
            }
            catch (Exception ex)
            {

            }


        } 
        #endregion

    }
}
