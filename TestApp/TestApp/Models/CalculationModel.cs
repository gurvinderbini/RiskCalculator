using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TestApp.Models
{
    public class CalculationModel:INotifyPropertyChanged
    {
        public CalculationModel()
        {
            Date = DateTime.Now;
        }

        [PrimaryKey]
        [AutoIncrement]
        public int ID { get; set; }

        public DateTime Date { get; set; } 

        public string Name { get; set; }

        public double EntryPrice { get; set; }
        public double StopLoss { get; set; }
        public double Risk { get; set; }

        public double QTY { get; set; }
        public double LossPer { get; set; }
        public double ProfitPer { get; set; }
        public double TotalAmountToInvest { get; set; }

        public double TotalIfTargetHit { get; set; }
        public double TotalIfStopLossHit { get; set; }
        public double SingleStockProfit { get; set; }
        public double SingleStockLoss { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
