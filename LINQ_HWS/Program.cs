using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LINQ_HWS
{
    public class Program
    {
        static void Main(string[] args)
        {
            //EXR 4

            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 }.ToList();

            List<string> listOfTwoVars = numbers.Select(x => x.ToString()).ToList(); //method syntax
            listOfTwoVars.ForEach(x => Console.WriteLine(x));
            var queryway = (from ints in listOfTwoVars
                            select ints.ToString()).ToList(); //query syntax


            //EXR 5

            List<string> nums = new List<string>() { "One", "Two ", "Three", "Four", "Five" }.ToList();
            List<string> numSize = nums.Where(x => x.Length > 4).ToList(); //method syntax
            numSize.ForEach(x => Console.WriteLine(x));
            var numsQuery = (from num in numSize
                               where num.Length > 4
                               select num.ToString()).ToList(); //query syntax


            //EXR 6

            List<int> orderNums = numbers.OrderBy(x => x.ToString()).ToList();
            List<int> orderNums2 = numbers.OrderByDescending(x => x.ToString()).ToList(); //method syntax
            orderNums.ForEach(x => Console.WriteLine(x));
           
            orderNums2.ForEach(x => Console.WriteLine(x));
            
            var orderNumsQuery = (from ord in orderNums
                                       orderby ord descending
                                       select ord).ToList(); //query syntax

            List<string> orderByNums = nums.OrderBy(x => x.Length).ToList();
            List<string> orderByNums2 = nums.OrderByDescending(x => x.Length).ToList();
            orderByNums.ForEach(x => Console.WriteLine(x));
            var orderByNumsQuery = (from obp in orderByNums
                                      orderby obp
                                      select obp).ToList(); //query syntax

            orderByNums2.ForEach(x => Console.WriteLine(x));


            //EXR 7


            List<int> num1 = new List<int>() { 5, 187, 75, 10, 26 }.ToList();
            List<int> num2 = new List<int>() { 10, 94, 22, 5, 16 }.ToList();
            List<int> sameNumbers = num1.Intersect(num2).ToList();
            List<int> notSameNumbers = num1.Except(num2).ToList();

            var numbersQuery = (from nbrs in sameNumbers
                                select nbrs.ToString()).ToList(); //query syntax

            Console.WriteLine("same nums");
            Console.WriteLine();
            sameNumbers.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
            Console.WriteLine("not same nums");
            Console.WriteLine();
            notSameNumbers.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();


            List<int> concatTwoLists = num1.Except(num2).Concat(num2.Except(num1)).OrderBy(x => x).ToList();
            concatTwoLists.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            List<int> concat = num1.Concat(num2).OrderBy(x => x).ToList();
            var firstNum = concat.FirstOrDefault(std => std > 12);
            Console.WriteLine("first num above 12 :");
            Console.WriteLine(firstNum);
            Console.WriteLine();

            Console.WriteLine("highest num of two lists :");
            Console.WriteLine(num1.Concat(num2).Max());


            //EXR 8
           
            List<Agent> agents = new List<Agent>();
            agents.Add(new Agent(67, "A_agents"));
            agents.Add(new Agent(56, "B_agents"));
            agents.Add(new Agent(6, "C_agents"));
            agents.Add(new Agent(9, "D_agents"));

            List<Client> clients = new List<Client>();
            clients.Add(new Client(67, "A_clients"));
            clients.Add(new Client(56, "B_clients"));
            clients.Add(new Client(6, "C_clients"));
            clients.Add(new Client(44, "D_clients"));
            MatchAgentWithClientById(clients, agents);

        }
        static void MatchAgentWithClientById(List<Client> clientsId, List<Agent> agentsId)
        {
            var matchagentwithclientbyid = clientsId.Join(agentsId, client => client.ClientId, agent => agent.AgentId, //method syntax
                                         (client, agent) => new
                                         {
                                             Clientname = client.ClientName,
                                             Agentname = agent.AgentName,
                                         }).ToList();
            
            var res = from client in clientsId //query syntax
                         join agent in agentsId
                         on client.ClientId equals agent.AgentId
                         select new
                         {
                             Clientname = client.ClientName,
                             Agentname = agent.AgentName,
                         };

            matchagentwithclientbyid.ForEach(agentsWithClients =>
            {
                Console.WriteLine($"Client Name: {agentsWithClients.Clientname + "\nAgent Name:" + agentsWithClients.Agentname}.");
            });
        }
    }
}