using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

#nullable disable

namespace WpfApp1
{
    public partial class Client
    {
        public Client()
        {
            ClientAddres = new HashSet<ClientAddre>();
        }

        public int ClientId { get; set; }
        public string ClientLname { get; set; }
        public string ClientFname { get; set; }
        public string ClientPatronumic { get; set; }
        public string ClientPhone { get; set; }

        public virtual ICollection<ClientAddre> ClientAddres { get; set; }

        [NotMapped]
        public string FIO { get; set; }

        [NotMapped]
        public string OrderPizzaAndCount { get; set; }
        
        [NotMapped]

        public string Coast { get; set; }

        public void Init()
        {
            var clients = App.PizzaDb.Clients.ToList();

            Client client = clients.Where(c => c.ClientId == ClientId).First();

            FIO = $"{client.ClientFname} {client.ClientLname} {client.ClientPatronumic}";

            decimal coast = 0;

            var adderes = App.PizzaDb.ClientAddres.Where(c => c.ClientId == ClientId);

            List<string> orderspizza = new List<string>();
            List<PizzaOrder> orders = new List<PizzaOrder>();
            List<PizzaAssortiment> asort = new List<PizzaAssortiment>();

            foreach (var adr in adderes)
            {
               var ord = App.PizzaDb.PizzaOrders.Where(c => c.ClientAddresId == adr.ClientAddresId).FirstOrDefault();

                if (ord != null)
                {
                    orders.Add(ord);
                }
            }

            foreach (var o in orders)
            {
                var orpizza = App.PizzaDb.PizzaAssortiments.Where(c => c.PizzaAssortimentId == o.PizzaAssortimentId).FirstOrDefault();

                if (orpizza != null)
                {
                    asort.Add(orpizza);
                }
            }

            var discount = 0;

            List<Pizza> pizzas = new List<Pizza>();

            foreach (var asr in asort)
            {
                var p = App.PizzaDb.Pizzas.Where(p => p.PizzaId == asr.PizzaId).FirstOrDefault();

                if (p != null)
                {
                    pizzas.Add(p);
                }
            }

            foreach (var ord in orders)
            {
                var asso = asort.Where(ar => ar.PizzaAssortimentId == ord.PizzaAssortimentId).First();
                var pizza = pizzas.Where(p => p.PizzaId == asso.PizzaId).First();


                string str = ord.OrderDate + " , Кол-во пицц: " + ord.PizzaCount + ", Название пиццы: " + pizza.PizzaName + ", Стоимость заказа: " + coast;
            }
                    }
    }
}
