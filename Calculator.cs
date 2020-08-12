using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FruitCalculator
{
    public class Calculator
    {
        public Calculator()
        {
            Fruits = new ObservableCollection<KeyValuePair<string, double>>();
            Promotions = new ObservableCollection<KeyValuePair<string, double>>();
            Basket = new ObservableCollection<KeyValuePair<string, int>>();
        }
        public ObservableCollection<KeyValuePair<string, double>> Fruits { get; set; }
        public ObservableCollection<KeyValuePair<string, double>> Promotions { get; set; }
        public ObservableCollection<KeyValuePair<string, int>> Basket { get; set; }
        public double TotalPrice
        {
            get
            {
                double totalPrice = 0.0;
                Basket.ToList().ForEach(item =>
                {
                    var fruit = Fruits.FirstOrDefault(f => f.Key == item.Key);
                    if (KeyValueNotNull(fruit))
                    {
                        double price = fruit.Value;
                        var promotion = Promotions.FirstOrDefault(f => f.Key == item.Key);
                        if (KeyValueNotNull(promotion))
                        {
                            price -= promotion.Value;
                        }
                        totalPrice += price * item.Value;
                    }
                });

                return totalPrice;
            }
        }

        private bool KeyValueNotNull(KeyValuePair<string, double> keyValuePair)
        {
            return !keyValuePair.Equals(default(KeyValuePair<string, double>));
        }
    }
}
