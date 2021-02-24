using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VacDestinationConsoleApp
{
   public class ConsumeHotelSync
    {
        public void GetAllHotelsData()
        {
            using( var client=new WebClient())// WebClient
            {
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("https://localhost:44396/api/Hotel");//URI
                Console.WriteLine(Environment.NewLine + result);
            }
        }
    }
}
