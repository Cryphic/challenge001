using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using BikeData;

namespace Föli
{
    class Program
    {
        static void Main(string[] args)
        {
            string user_input;
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8; //UTF8 Muoto ääkkösille
            string json = client.DownloadString("http://data.foli.fi/citybike");       
            var result = JsonConvert.DeserializeObject<Bike>(json); //deserialize luokkaan
            foreach (var item in result.Racks.Values)
            {
              
                if (item.SlotsAvail >= 0)
                {
                    Console.WriteLine(item.Name);
                }
             

            }

            Console.WriteLine("Syötä paikan nimi:");
            user_input = Console.ReadLine();

            foreach (var item in result.Racks.Values)
            {
                if (item.Name == user_input)
                {
                    Console.WriteLine("tilaa saatavilla: {0}", item.SlotsAvail);
                }
                else { Console.Clear();  Console.WriteLine("Pysäkkiä ei löydy"); break; }

            }


            Console.ReadKey();
        }
    }
}
