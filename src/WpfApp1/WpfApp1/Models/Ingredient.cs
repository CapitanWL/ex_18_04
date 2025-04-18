using System;
using System.Collections.Generic;

#nullable disable

namespace WpfApp1
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            PizzaIngredients = new HashSet<PizzaIngredient>();
        }

        public int IngredientId { get; set; }
        public string IngredientName { get; set; }

        public virtual ICollection<PizzaIngredient> PizzaIngredients { get; set; }
    }
}
