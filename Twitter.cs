using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    public class Twitter
    {
        private Dictionary<int, HashSet<int>> follows;
        private PriorityQueue<Tweet, DateTime> tweets;

        public Twitter()
        {
            follows = new Dictionary<int, HashSet<int>>();
            tweets = new PriorityQueue<Tweet, DateTime>(Comparer<DateTime>.Create((a, b) => b.CompareTo(a)));
        }

        public void PostTweet(int userId, int tweetId)
        {
            var tweet = new Tweet(tweetId, userId);
            tweets.Enqueue(tweet, tweet.created);
        }

        public List<int> GetNewsFeed(int userId)
        {
            var list = new List<int>();
            var stack = new Stack<Tweet>();
            while (list.Count < 10 && tweets.Count > 0) 
            {
                var tweet = tweets.Dequeue();
                stack.Push(tweet);

                if (tweet.userId == userId) list.Add(tweet.id);
                if (follows.ContainsKey(userId))
                {
                    var followees = follows[userId];
                    if (followees.Contains(tweet.userId)) list.Add(tweet.id);
                }
            }
            while (stack.Count > 0)
            {
                var tweet = stack.Pop();
                tweets.Enqueue(tweet, tweet.created);
            }
            return list;
        }

        public void Follow(int followerId, int followeeId)
        {
            if (followerId == followeeId) return;

            if (!follows.ContainsKey(followerId))
                follows.Add(followerId, new HashSet<int>() { followeeId });
            else follows[followerId].Add(followeeId);
        }

        public void Unfollow(int followerId, int followeeId)
        {
            if (follows.ContainsKey(followerId))
            {
                var followees = follows[followerId];
                followees.Remove(followeeId);
            }
        }

        class Tweet
        {
            public int id;
            public int userId;
            public DateTime created;

            public Tweet(int id, int userId )
            {
                this.id = id;
                this.userId = userId;
                created = DateTime.Now;
            }
        }

    }

}
