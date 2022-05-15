using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestApp.DB;
using TestApp.Models;
using Xamarin.Forms;

namespace TestApp.ViewModel
{
    public class CalculatorPageViewModel : BaseViewModel
    {



        public CalculatorPageViewModel(CalculationModel calculationModel)
        {
            if (calculationModel != null)
            {
                CalculationModel = calculationModel;
            }
            else
            {
                CalculationModel = new CalculationModel();
            }
        }


        public CalculationModel CalculationModel { get; set; }

        //public string Entry { get; set; }
        //public string StopLoss { get; set; }
        //public string Risk { get; set; }


        public ICommand EntryTextChangeCommand => new Command<TextChangedEventArgs>((s) =>
          {
              Calculate();
          });
        public ICommand StopLossTextChangeCommand => new Command<TextChangedEventArgs>((s) =>
        {
            Calculate();
        });
        public ICommand RiskTextChangeCommand => new Command<TextChangedEventArgs>((s) =>
        {
            Calculate();
        });

        

            public ICommand BackCommand => new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PopAsync();
            });
        public ICommand SaveCommand => new Command(async () =>
        {
            try
            {
                if (CalculationModel.EntryPrice != 0 && CalculationModel.StopLoss != 0 && CalculationModel.Risk != 0)
                {
                    CalculationDatabase database = await CalculationDatabase.Instance;

                    await database.SaveItemAsync(CalculationModel);

                    await App.Current.MainPage.Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
            }
        });


        private void Calculate()
        {
            try
            {
                if (CalculationModel.EntryPrice != 0 && CalculationModel.StopLoss != 0 && CalculationModel.Risk != 0)
                {
                    CalculationModel.SingleStockLoss = CalculationModel.EntryPrice - CalculationModel.StopLoss;
                    CalculationModel.SingleStockProfit = CalculationModel.SingleStockLoss * 2;

                    CalculationModel.QTY = Convert.ToInt32(CalculationModel.Risk / CalculationModel.SingleStockLoss);
                    CalculationModel.LossPer = Math.Round(CalculationModel.SingleStockLoss / CalculationModel.EntryPrice * 100, 2);
                    CalculationModel.ProfitPer = Math.Round(CalculationModel.SingleStockProfit / CalculationModel.EntryPrice * 100, 2);


                    CalculationModel.TotalAmountToInvest = CalculationModel.QTY * CalculationModel.EntryPrice;
                    CalculationModel.TotalIfTargetHit = (CalculationModel.EntryPrice + CalculationModel.SingleStockProfit) * CalculationModel.QTY;
                    CalculationModel.TotalIfStopLossHit = CalculationModel.QTY * CalculationModel.StopLoss;
                }
            }
            catch (Exception EX)
            {

            }


        }


    }
}
