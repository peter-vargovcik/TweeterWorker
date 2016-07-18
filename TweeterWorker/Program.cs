using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace TweeterWorker
{
    class Program
    {
        static void Main(string[] args)
        {

            // Set up your credentials (https://apps.twitter.com)
           Auth.SetUserCredentials("clBKxzx5k7pD89CNy4ILH7Ij2", "ad1ntnD3LwcN2Dtj71aOA4wnj3D3gNCwEO2KBgRN7apJaq7GCz", "754808247891193856-34M7S92LqESkiXvxJwq1rxwHMQGdbGM", "jMMgKZfa1Gccla7AOECRW29Fxy6QqiyWTgAieTmqV5E9E");

            // Get a AuthenticatedUser from a specific set of credentials
            var userCredentials = Auth.CreateCredentials("clBKxzx5k7pD89CNy4ILH7Ij2", "ad1ntnD3LwcN2Dtj71aOA4wnj3D3gNCwEO2KBgRN7apJaq7GCz", "754808247891193856-34M7S92LqESkiXvxJwq1rxwHMQGdbGM", "jMMgKZfa1Gccla7AOECRW29Fxy6QqiyWTgAieTmqV5E9E");
            var authenticatedUser = User.GetAuthenticatedUser(userCredentials);
            

            var userIdentifier = new UserIdentifier("aaroadwatch");
            var users = Search.SearchUsers("aaroadwatch");

            var aaUser = users.First();



            // Simple Search source : https://github.com/linvi/tweetinvi/wiki/Searches
            var matchingTweets = Search.SearchTweets("from:aaroadwatch near:'West Meath, Ireland' within:15mi");


            var relevantTweets = matchingTweets.Where(x => x.FullText.Contains("Ballinrobe Rd (R334)"));
            

            var id = userIdentifier.Id;
        }
    }
}
