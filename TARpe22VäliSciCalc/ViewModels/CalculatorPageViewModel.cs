using CommunityToolkit.Mvvm.Input;

namespace ViewModels
{
    internal partial class CalculatorPageViewModel
    {
        [INotifyPropertyChanged]

        internal partial class Calculator
        {
            [ObservableProperty]
            private string inputText = string.Empty;

            [ObservableProperty]
            private string calculatedResult = "0";

            private bool isSciOpWaiting = false;

            [RelayCommand]
            private void Reset()
            {
                CalculatedResult = "0";
                inputText = string.Empty;
                isSciOpWaiting = false;
            }

            [RelayCommand]
            private void Calculate()
            {
                if (InputText.Length == 0)
                {
                    return;
                }

                if (isSciOpWaiting)
                {
                    InputText += ")";
                    isSciOpWaiting = false;
                }

                try
                {
                    var inputString = NormalizeInputString();
                    var expression = new NCalc.Expression(inputString);
                    var result = expression.Evaluate();

                    CalculatedResult = result.ToString();
                }
                catch (Exception ex)
                {
                    Calculatedresult = "NaN";
                }
            }

            private string NormalizeInputString()
            {
                Dictionary<string, string> _opMapper = new()
                {

                };
            }
        }
    }
}
