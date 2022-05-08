using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LINQ_HWS
{
    internal class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }

        public Client(int clientId, string clientName)
        {
            ClientId = clientId;
            ClientName = clientName;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}