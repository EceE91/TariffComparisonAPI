using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TariffComparisonAPI
{
    public class ProductB : IProduct
    {
        public ProductType Type => ProductType.ProductB;

        private string _tariffName;
        public string TariffName  // read-write instance property
        {
            get => _tariffName;
            set => _tariffName = value;
        }

        private double _annualCost;
        public double AnnualCost  // read-write instance property
        {
            get => _annualCost;
            set => _annualCost = value;
        }

        private readonly double _standardPrice = 800;

        public double CalculateAnnualCost(double consumption)
        {
            if (consumption <= 4000)
            {
                _annualCost = _standardPrice;                
            }
            else
            {
                var diff = (consumption - 4000);
                _annualCost = _standardPrice + ((diff * 30) / 100);
            }
            return _annualCost;
        }
    }
}
