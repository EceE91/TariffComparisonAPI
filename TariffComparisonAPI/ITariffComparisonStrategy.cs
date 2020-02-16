using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TariffComparisonAPI
{
    public interface ITariffComparisonStrategy
    {
        IList<IProduct> ListTariffComparison(double consumption);
    }
}
