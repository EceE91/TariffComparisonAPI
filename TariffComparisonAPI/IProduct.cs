using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TariffComparisonAPI
{
    public interface IProduct
    {
        ProductType Type { get; }
        public string TariffName
        {
            get;
            set;
        }
        public double AnnualCost
        {
            get;
            set;
        }
        double CalculateAnnualCost(double consumption);
    }
}
