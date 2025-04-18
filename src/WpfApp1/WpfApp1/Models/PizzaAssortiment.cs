using System;
using System.Collections.Generic;

#nullable disable

namespace WpfApp1
{
    public partial class PizzaAssortiment
    {
        public PizzaAssortiment()
        {
            PizzaOrders = new HashSet<PizzaOrder>();
        }

        public int PizzaAssortimentId { get; set; }
        public int PizzaId { get; set; }
        public int PizzaSizeId { get; set; }
        public double PizzaWeight { get; set; }
        public decimal? Price { get; set; }

        public virtual Pizza Pizza { get; set; }
        public virtual Size PizzaSize { get; set; }
        public virtual ICollection<PizzaOrder> PizzaOrders { get; set; }
    }
}
