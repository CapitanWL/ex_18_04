using System;
using System.Collections.Generic;

#nullable disable

namespace WpfApp1
{
    public partial class Addre
    {
        public Addre()
        {
            ClientAddres = new HashSet<ClientAddre>();
        }

        public int AddresId { get; set; }
        public string Street { get; set; }
        public string HomeNumber { get; set; }
        public string FlatNumber { get; set; }

        public virtual ICollection<ClientAddre> ClientAddres { get; set; }
    }
}
