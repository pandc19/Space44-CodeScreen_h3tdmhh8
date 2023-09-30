using System.Collections.Generic;
using System.Linq;

/**
 * Generates various statistics about the tweets data set returned by the given TweetsApiService instance.
 */
namespace CodeScreen.Assessments.TweetsApi
{
    class TweetDataStatsGenerator
    {
        private readonly TweetsApiService TweetsApiService;

        public TweetDataStatsGenerator(TweetsApiService tweetsApiService)
        {
            TweetsApiService = tweetsApiService;
        }

        /**
         * Retrieves the highest number of tweets that were created on any given day by the given user.
         *
         * A day's time period here is defined from 00:00:00 to 23:59:59
         * If there are no tweets for the given user, this method should return 0.
         *
         * @param userName the name of the user
         * @return the highest number of tweets that were created on a any given day by the given user
        */
        public int GetMostTweetsForAnyDay(string userName)
        {
            var tweets = TweetsApiService.GetTweets(userName);

            if (!tweets.Any()) return 0;

            tweets.ForEach(tweet => tweet.CreatedAtDay = tweet.CreatedAt.Date);

            var higestNumberTweets = tweets.GroupBy(tweet => tweet.CreatedAtDay)
                .OrderByDescending(grp => grp.Count())
                .First().Count();

            return higestNumberTweets;
        }

        /**
         * Finds the ID of longest tweet for the given user.
         *
         * You can assume there will only be one tweet that is the longest.
         * If there are no tweets for the given user, this method should return null.
         *
         * @param userName the name of the user
         * @return the ID of longest tweet for the given user
        */
        public string GetLongestTweet(string userName)
        {
            var tweets = TweetsApiService.GetTweets(userName);

            if (!tweets.Any()) return null;

            tweets = tweets.OrderByDescending(tweet => tweet.Text.Length).ToList();

            var id = tweets.First().Id;

            return id;
        }

        /**
         * Retrieves the most number of days between tweets by the given user, wrapped as an OptionalInt.
         *
         * This should always be rounded down to the complete number of days, i.e. if the time is 12 days & 3 hours, this
         * method should return 12.
         * If there are no tweets for the given user, this method should return 0.
         *
         * @param userName the name of the user
         * @return the most number of days between tweets by the given user
        */
        public int FindMostDaysBetweenTweets(string userName)
        {
            var tweets = TweetsApiService.GetTweets(userName);

            if (!tweets.Any()) return 0;

            tweets = tweets.OrderBy(tweet => tweet.CreatedAt.Date).ToList();

            for (int i = 0; i < tweets.Count; i++)
            {
                if (i < tweets.Count - 1)
                    tweets[i].DaysDiference = tweets[i + 1].CreatedAt.Subtract(tweets[i].CreatedAt).Days;
                else
                    tweets[i].DaysDiference = 0;
            }

            return tweets.Max(tweet => tweet.DaysDiference);
        }

        /**
         * Retrieves the most popular hash tag tweeted by the given user.
         *
         * Note that the string returned by this method should include the hashtag itself.
         * For example, if the most popular hash tag is "#Java", this method should return "#Java".
         * If there are no tweets for the given user, this method should return null.
         *
         * @param userName the name of the user
         * @return the most popular hash tag tweeted by the given user.
        */
        public string GetMostPopularHashTag(string userName)
        {
            var tweets = TweetsApiService.GetTweets(userName);
            List<string> hashtagList = new List<string>();

            if (!tweets.Any()) return null;

            var messageWithHashtagsList = tweets.Where(tweet => tweet.Text.Contains('#')).ToList();
            messageWithHashtagsList.ForEach(message =>
            {
                var stringArr = message.Text.Split(' ');
                foreach (var item in stringArr)
                {
                    if (item.Contains('#'))
                        hashtagList.Add(item);
                }
            });

            var repeatedHashatag = hashtagList.GroupBy(hashtag => hashtag)
                .OrderByDescending(grp => grp.Count())
                .First().First();

            return repeatedHashatag;
        }

    }
}
