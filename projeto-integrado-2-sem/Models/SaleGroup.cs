using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem.Models
{
    public class SaleGroup<Key>
    {
        public Key groupKey;

        public int totalQuantity;
        public Decimal totalValue;

        [System.ComponentModel.Browsable(false)]
        public Key GroupingKey { get { return groupKey; } }

        [System.ComponentModel.DisplayName("Quantidade Vendida")]
        public int TotalQuantity { get { return totalQuantity; } }

        [System.ComponentModel.DisplayName("Valor Total")]
        public Decimal TotalValue { get { return totalValue; } }

        public SaleGroup(Key key, int qt, Decimal Total)
        {
            groupKey = key;
            totalQuantity = qt;
            totalValue = Total;
        }

        public SaleGroup(Key key, IEnumerable<Sale> grouping)
        {
            this.groupKey = key;
            this.totalQuantity = grouping.Sum(s => s.Quantity.Value);
            this.totalValue = grouping.Sum(s => s.TotalValue.Value);
        }

        public SaleGroup<TConvert> ConvertTo<TConvert>(Func<Key, TConvert> convertFunc)
        {
            return new SaleGroup<TConvert>(convertFunc(groupKey), totalQuantity, totalValue);
        }
    }
}
