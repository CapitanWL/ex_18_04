using System;
using System.Collections.Generic;

#nullable disable

namespace WpfApp1
{
    public partial class ClientAddre
    {
        public ClientAddre()
        {
            PizzaOrders = new HashSet<PizzaOrder>();
        }

        public int ClientAddresId { get; set; }
        public int ClientId { get; set; }
        public int AddresId { get; set; }

        public virtual Addre Addres { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<PizzaOrder> PizzaOrders { get; set; }
    }
}
