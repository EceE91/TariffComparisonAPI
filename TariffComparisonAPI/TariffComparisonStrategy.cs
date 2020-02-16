using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TariffComparisonAPI
{
    public class TariffComparisonStrategy : ITariffComparisonStrategy
    {
        private readonly IEnumerable<IProduct> _products;
        public IList<IProduct> TariffList { get; set; }
        public TariffComparisonStrategy(IEnumerable<IProduct> products)
        {
            _products = products;
            TariffList  = new List<IProduct>();
        }   

        public IList<IProduct> ListTariffComparison(double consumption)
        {
            foreach (var item in _products)
            {
                if (item.Type == ProductType.ProductA)
                {
                    item.TariffName = "basic electricity tariff";
                    item.CalculateAnnualCost(consumption);
                }
                else if (item.Type == ProductType.ProductB)
                {
                    item.TariffName = "Packaged tariff";
                    item.CalculateAnnualCost(consumption);
                }

                TariffList.Add(item);
            }

            return TariffList.OrderBy(o => o.AnnualCost).ToList(); // orderby asc by default
        }
    }
}
