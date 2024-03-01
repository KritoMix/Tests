using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Clients.Model
{
    public class Client : BaseModelClient
    {
        public string ClientName { get; set; }
        public ICollection<ClientContact> Contacts { get; set; }
    }
}
