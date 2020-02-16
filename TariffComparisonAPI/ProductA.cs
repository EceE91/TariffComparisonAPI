using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TariffComparisonAPI
{
    public class ProductA : IProduct
    {
        public ProductType Type => ProductType.ProductA;

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

        // The readonly modifier ensures the field can only be given a value 
        // during its initialization or in class constructor.
        private readonly double _baseCostPerMonth = 5.0;
        private readonly double _baseConsumptionCost = 22.0;

        public double CalculateAnnualCost(double consumption)
        {
            _annualCost = (_baseCostPerMonth * 12) + ((consumption * _baseConsumptionCost) / 100);
            return _annualCost;
        }
    }
}
