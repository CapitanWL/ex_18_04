using System;
using System.Collections.Generic;

#nullable disable

namespace WpfApp1
{
    public partial class Size
    {
        public Size()
        {
            PizzaAssortiments = new HashSet<PizzaAssortiment>();
        }

        public int SizeId { get; set; }
        public string SizeName { get; set; }

        public virtual ICollection<PizzaAssortiment> PizzaAssortiments { get; set; }
    }
}
