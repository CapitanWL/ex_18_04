using System;
using System.Collections.Generic;

#nullable disable

namespace WpfApp1
{
    public partial class PizzaIngredient
    {
        public int PizzaIngredientId { get; set; }
        public int PizzaId { get; set; }
        public int IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
