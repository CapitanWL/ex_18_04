using System;
using System.Collections.Generic;

#nullable disable

namespace WpfApp1
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaAssortiments = new HashSet<PizzaAssortiment>();
            PizzaIngredients = new HashSet<PizzaIngredient>();
        }

        public int PizzaId { get; set; }
        public string PizzaName { get; set; }

        public virtual ICollection<PizzaAssortiment> PizzaAssortiments { get; set; }
        public virtual ICollection<PizzaIngredient> PizzaIngredients { get; set; }
    }
}
