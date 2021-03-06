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
        private string AuthorizationKey = "US_IF1PtkRGFmYYAuwNq - rNmwPKV - 3PSxLs55KKkZex4exxmxTrGQfqbON56gS_nm0PaPrhmhjrpDZw5VEmMlJzUXAlqAJn8J5oiqNKskdxSiF9Tjzhoy0KPl3ITGgSMEwzSicm26XWpkpDmPdnuIeJINczgktbgEm2XgdQZapfvA3XrM_U_fm1zSSlK-Q_XsQUNsZjRJACuMpaqH498VqzB-HIv_aNyXHwLWI4CwOn9HqgRZZUNJn7OJeI-LNYuHmC5q6uHHbI2Vfbtp9xJRc_k4K3-PonVKitoKnzh5iImnbHqWfgJlP704qhi54xkY3Yk3ztPHFRpnY8L7q4qweIwJkhQFbeDw4xpYVv5nNo_R9Px0uP0K0Ak-H3fm-We4OMY7wYuM0U-wJBnKV3Rwp9CjkFjiLTT5rtAWrnIKGZJW5py3STHbin20g8fuxUDWJgbeX8bLpMoPIJ_4WLaWXnGeld8uIWYgprB4HnBMoNfw3McursjUkgQD216e-Q_";
            //"BBd5b1VSaHiZDZ4Hhb31NdG5xzOQdvbPeZQn0ac_cGgezIlnKjDkcVvjfWSV8BS46huq218OjP9OUgumywtVMgV27tSXVeYaIE7yyWWKdcaTyQ-xuzX29w3-b353jQ1Icz34BSgnoMu76iEFe6xKulSwwHmziFx-AcNXUHwqIe9FeR6uuWrX7H0ihuImgCEk9QQ-GHWycUxHe_n0ocKbtHjDGf4i4J9ENuoeXwllOOX5IG0VmX8WH81XanzACAV8kaGtVTodixlIHOwskDZfxcqtwrfCuWGZaCiKgQ64r-z3MbUdZ6qebMNAFgSh6dnVB53ZeBLJBM9DEEuNFD-AjrIPwTvowSWlb__YX9D2H6zU0dHp4MctcOmQorJKCk_p2gUD3hrxqMw68pOEGo3Pq5tgADnnz5gFiZctQI5q_9ZUsSAd9Tqm9HdKvog1AJzkeWrNS75XkVAtFhrwBc45qLP3QgYti7cSc9L1XVyktdu58kfMP6gfpdp1iKtw_0LV";

        public HotelAPI(string authorizationKey)
        {
            AuthorizationKey = authorizationKey;
        }

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
        
        public string DeleteHotel(int stockId)
        {
            string errorMessage = "";

            try
            {
                var client = new RestClient($"https://localhost:44396/api/hotel/{stockId}");
                var request = new RestRequest(Method.DELETE);
                request.AddHeader("Authorization", $"Bearer {AuthorizationKey}");
                IRestResponse response = client.Execute(request);

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
