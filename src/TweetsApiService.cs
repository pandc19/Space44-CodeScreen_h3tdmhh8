using System;
using System.Collections.Generic;

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
        public List<object> GetTweets(string userName) {
            //TODO Implement
            //Note that the type of the returned list should be something that better represents tweet data.
            throw new NotImplementedException();
        }

    }
}
