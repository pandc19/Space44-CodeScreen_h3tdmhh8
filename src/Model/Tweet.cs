using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeScreen.Assessments.TweetsApi.src.Model
{
    public class Tweet
    {
        public string Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTime CreatedAtDay { get; set; }

        public string Text { get; set; }

        public User User { get; set; }
    }


}
