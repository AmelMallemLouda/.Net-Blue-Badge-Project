﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject_Console
{
   public class CustomerAPI
    {
        private string AuthorizationKey = "";
        public CustomerAPI(string authorizationKey)
        {
            AuthorizationKey = authorizationKey;
        }

        public (string responseContent, string errorMessage) GetAllCustomers()
        {
            string responseContent = "";
            string errorMessage = "";

            try
            {
                var client = new RestClient("https://localhost:44396/api/Customer");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", $"Bearer {AuthorizationKey}");
                IRestResponse response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception($"Error Occured: {response.ErrorMessage}");
                }
                responseContent = response.Content;

            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
            }
            return (responseContent, errorMessage);
        }
    }
}
