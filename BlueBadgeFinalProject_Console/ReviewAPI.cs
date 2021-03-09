using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject_Console
{
    public class ReviewAPI
    {
        private string AuthorizationKey = "lMwac_8oKKNAw-Zvx2kZedrqqrd4BKtO6VMkn1Zs-Qoyao2AJ2ldjfHclOrru03hZTEzMMouWbzaQeqaXa3w_dAJ-59cEFZx-vFGLi8NabDIn_6_TJ3HV8reiDXKmzWidenqxKtfoSvLPRFcQOU88MeYwXwnyE8hrJFI4DhV34ghWg_SWN21uuyhTNpdcxSjtyq-ntaIKXxsDHTk8CJFKtgE8iCeprfZ0bNPlgY-b-cnlelbOF4HDFhuqha7kalQMP0IdOknE0jZjYOatGJKzsbY7TOL_W9cY0e_11SWVksl-g5Ng083vQqNubas21oPp-L8DzX6JA_u0dkeI5wvF9rg3VyMEdNI-SCKJSpeC1Dwy-_xK14HQbUJ73HJ2kGcRNynBruuxdCgEbvNwnTI3q6h1ejJaaYulmIYGYBNt5eWn9kgqmUA7ImG6VdOuDxXg_7WpJCUzpVv6yu-i3z5FCZKjaEtJOHvl1noZWtKzko";

        public ReviewAPI(string authorizationKey)
        {
            AuthorizationKey = authorizationKey;
        }

        public (string responseContent, string errorMessage) GetAllReviews()
        {
            string responseContent = "";
            string errorMessage = "";
            try
            {
                var restClient = new RestClient("https://localhost:44396/api/Review");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", $"Bearer {AuthorizationKey}");
                IRestResponse response = restClient.Execute(request);

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
