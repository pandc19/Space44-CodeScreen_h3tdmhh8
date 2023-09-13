using CodeScreen.Assessments.TweetsApi.src.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

using System.Net.Http;

namespace CodeScreen.Assessments.TweetsApi
{
    /**
    * Service that retrieves data from the CodeScreen Tweets API.
    */
    class TweetsApiService
    {
        private static readonly string TweetsEndpointURL = "https://app.codescreen.com/api/assessments/tweets";

        //Your API token. Needed to successfully authenticate when calling the tweets endpoint.
        //This needs to be included in the Authorization header (using the Bearer authentication scheme) in the request you send to the tweets endpoint.
        private static readonly string ApiToken = "8c5996d5-fb89-46c9-8821-7063cfbc18b1";


        /**
         * Retrieves the data for all tweets, for the given user,
         * by calling the https://app.codescreen.com/api/assessments/tweets endpoint.
         *
         * The userName should be passed in the request as a query parameter called userName.
         *
         * @param userName the name of the user
         * @return a list containing the data for all tweets for the given user
        */
        public List<Tweet> GetTweets(string userName)
        {
            //Note that the type of the returned list should be something that better represents tweet data.
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + ApiToken);
                var response = httpClient.GetAsync($"{TweetsEndpointURL}?userName={userName}").GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    var responseBody = responseContent.ReadAsStringAsync().GetAwaiter().GetResult();
                    var list = JsonConvert.DeserializeObject<List<Tweet>>(responseBody);
                    return list;
                }
                return new List<Tweet>();
            }

        }

    }
}
