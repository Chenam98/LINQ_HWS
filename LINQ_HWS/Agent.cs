using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LINQ_HWS
{
    internal class Agent
    {
        public int AgentId { get; set; }
        public string AgentName { get; set; }

        public Agent(int agentId, string agentName)
        {
            AgentId = agentId;
            AgentName = agentName;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }


    }
}