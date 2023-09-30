using System;

namespace CodeScreen.Assessments.TweetsApi.Model
{
    public class Tweet
    {
        public string Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTime CreatedAtDay { get; set; }

        public string Text { get; set; }

        public User User { get; set; }

        public int DaysDiference { get; set; }
    }


}
