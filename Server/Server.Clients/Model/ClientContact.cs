using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Clients.Model
{
    public class ClientContact : BaseModelClient
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public string ContactType { get; set; }
        public string ContactValue { get; set; }
        public Client Client { get; set; }
    }
}
