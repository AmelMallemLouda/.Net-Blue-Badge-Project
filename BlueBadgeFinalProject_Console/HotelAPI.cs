using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject_Console
{
    public class HotelAPI
    {
        private string AuthorizationKey ="";

        public HotelAPI(string authorizationKey)
        {
            AuthorizationKey = authorizationKey;
        }

        public (string responseContent, string errorMessage) GetAllHotels()
        {
            string responseContent = "";
            string errorMessage = "";
            try
            {
                var client = new RestClient("https://localhost:44396/api/Hotel");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", $"Bearer {AuthorizationKey}");
                IRestResponse response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception($"Error Occured: {response.ErrorMessage}");
                }

                responseContent = response.Content;

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return (responseContent, errorMessage);

            
        }
    }
}
