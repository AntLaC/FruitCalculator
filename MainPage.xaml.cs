using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FruitCalculator
{
    public sealed partial class MainPage : Page
    {
        public Calculator Calculator { get; set; }
        public MainPage()
        {
            Calculator = new Calculator();
            this.InitializeComponent();
        }

        private void AddFruit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double.TryParse(NewFruitPrice.Text, out double price);
                Calculator.Fruits.Add(new KeyValuePair<string, double>(NewFruit.Text, price));
                NewFruitPrice.Text = "";
                NewFruit.Text = "";
            }
            catch
            {
            }
        }
        private void AddPromotion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double.TryParse(NewPromotionPrice.Text, out double price);
                Calculator.Promotions.Add(new KeyValuePair<string, double>(NewPromotion.SelectedValue.ToString(), price));
                NewPromotionPrice.Text = "";
                NewPromotion.SelectedIndex = -1;
            }
            catch
            {
            }
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int.TryParse(NewItemAmount.Text, out int amount);
                Calculator.Basket.Add(new KeyValuePair<string, int>(NewItem.SelectedValue.ToString(), amount));
                NewItemAmount.Text = "";
                NewItem.SelectedIndex = -1;
                Calculate();
            }
            catch
            {
            }
        }

        private void Calculate()
        {
            TotalPrice.Text = $"Total Sale Price: {Calculator.TotalPrice:c}";
        }
    }
}