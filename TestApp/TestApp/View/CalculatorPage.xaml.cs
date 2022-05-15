using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Models;
using TestApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalculatorPage : ContentPage
    {
        public CalculatorPage(CalculationModel calculationModel)
        {
            InitializeComponent(); 
            var vm = new CalculatorPageViewModel(calculationModel);
            BindingContext = vm;
        }
    }
}