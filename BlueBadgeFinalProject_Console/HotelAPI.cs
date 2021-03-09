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
        private string AuthorizationKey = "lMwac_8oKKNAw-Zvx2kZedrqqrd4BKtO6VMkn1Zs-Qoyao2AJ2ldjfHclOrru03hZTEzMMouWbzaQeqaXa3w_dAJ-59cEFZx-vFGLi8NabDIn_6_TJ3HV8reiDXKmzWidenqxKtfoSvLPRFcQOU88MeYwXwnyE8hrJFI4DhV34ghWg_SWN21uuyhTNpdcxSjtyq-ntaIKXxsDHTk8CJFKtgE8iCeprfZ0bNPlgY-b-cnlelbOF4HDFhuqha7kalQMP0IdOknE0jZjYOatGJKzsbY7TOL_W9cY0e_11SWVksl-g5Ng083vQqNubas21oPp-L8DzX6JA_u0dkeI5wvF9rg3VyMEdNI-SCKJSpeC1Dwy-_xK14HQbUJ73HJ2kGcRNynBruuxdCgEbvNwnTI3q6h1ejJaaYulmIYGYBNt5eWn9kgqmUA7ImG6VdOuDxXg_7WpJCUzpVv6yu-i3z5FCZKjaEtJOHvl1noZWtKzko";

        public HotelAPI(string authorizationKey)
        {
            AuthorizationKey = authorizationKey;
        }

        //Get all hotels
        public (string responseContent, string errorMessage) GetAllHotels()
        {
            string responseContent = "";
            string errorMessage = "";

            //  Block of code to try
            try
            { 
                var restClient = new RestClient("https://localhost:44396/api/Hotel");
                
                var request = new RestRequest(Method.GET);
               
                request.AddHeader("Authorization", $"Bearer {AuthorizationKey}");
                // Container for data sent back from API
                IRestResponse response = restClient.Execute(request);
                //if we don't get the 200 ok
                if (response.StatusCode != HttpStatusCode.OK)
                { 
                    //Transport errors generated while attempting the request.
                    throw new Exception($"Error Occured: {response.ErrorMessage}");
                }
                
                responseContent = response.Content;

            }

            //  Block of code to handle errors
            catch (Exception ex)
            {
               errorMessage = ex.Message;
            }
            return (responseContent, errorMessage);

            
        }

        //Delete a hotel
        
        public string DeleteHotel(int stockId)
        {
            string errorMessage = "";

            try
            {
                var client = new RestClient($"https://localhost:44396/api/hotel/{stockId}");
                var request = new RestRequest(Method.DELETE);
                request.AddHeader("Authorization", $"Bearer {AuthorizationKey}");
                IRestResponse response = client.Execute(request);

                //the client can continue with its request?
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception($"Error Occured: {response.ErrorMessage}");
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            return errorMessage;
        }
    }
}
