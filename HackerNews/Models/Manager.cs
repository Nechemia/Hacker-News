using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HackerNews.Models
{
    public class Manager
    {

        public List<UpVote> GetUpvotes()
        {
            using (var context = new HackerNewsDatabaseDataContext(@"Data Source=.\sqlexpress;Initial Catalog=HackerNews;Integrated Security=True"))
            {
                return context.UpVotes.ToList(); 
            }
        }

        public IEnumerable<Link> GetAllLinks()
        {
            using (var context = new HackerNewsDatabaseDataContext(@"Data Source=.\sqlexpress;Initial Catalog=HackerNews;Integrated Security=True"))
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Link>(l => l.User);
                loadOptions.LoadWith<Link>(l => l.UpVotes);
                context.LoadOptions = loadOptions;

                return context.Links.ToList();
                
            }
        }
        public IEnumerable<Link> GetAllLinksByUser(int userId)
        {
            using (var context = new HackerNewsDatabaseDataContext(@"Data Source=.\sqlexpress;Initial Catalog=HackerNews;Integrated Security=True"))
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Link>(l => l.User);
                loadOptions.LoadWith<Link>(l => l.UpVotes);
                context.LoadOptions = loadOptions;

                return context.Links.Where(l => l.UserId == userId).ToList();

            }
        }
       

        public User GetUserId(string userName)
        {
            using (var context = new HackerNewsDatabaseDataContext(@"Data Source=.\sqlexpress;Initial Catalog=HackerNews;Integrated Security=True"))
            {
                User user = context.Users.FirstOrDefault(u => u.UserName == userName);
                return user;
            }
        }
        public int GetUpvoteAmount(int linkId)
        {
            using (var context = new HackerNewsDatabaseDataContext(@"Data Source=.\sqlexpress;Initial Catalog=HackerNews;Integrated Security=True"))
            {
                int amount = context.UpVotes.Count(u => u.LinkId == linkId);             
                return amount;
            }
        }


        public void AddLink(Link Link)
        {
            using (var context = new HackerNewsDatabaseDataContext(@"Data Source=.\sqlexpress;Initial Catalog=HackerNews;Integrated Security=True"))
            {
                context.Links.InsertOnSubmit(Link);
                context.SubmitChanges();

            }
        }
        public void AddUser(User User)
        {
            using (var context = new HackerNewsDatabaseDataContext(@"Data Source=.\sqlexpress;Initial Catalog=HackerNews;Integrated Security=True"))
            {
                context.Users.InsertOnSubmit(User);
                context.SubmitChanges();
            }
        }
        public void AddUpVote(UpVote Upvote)
        {
            using (var context = new HackerNewsDatabaseDataContext(@"Data Source=.\sqlexpress;Initial Catalog=HackerNews;Integrated Security=True"))
            {
                context.UpVotes.InsertOnSubmit(Upvote);
                context.SubmitChanges();
            }
        }


    }
}


//public void UpdateGame(VideoGame videoGame)
//    {
//        using (var context = new HackerNewsDatabaseDataContext(@"Data Source=.\sqlexpress;Initial Catalog=HackerNews;Integrated Security=True"))
//        {
//            context.VideoGames.Attach(videoGame);
//            context.Refresh(RefreshMode.KeepCurrentValues, videoGame);
//            context.SubmitChanges();
//        }
//    }

//    public void DeleteGame(int gameId)
//    {
//        using (var context = new HackerNewsDatabaseDataContext(@"Data Source=.\sqlexpress;Initial Catalog=HackerNews;Integrated Security=True"))
//        {
//            //var game = context.VideoGames.FirstOrDefault(g => g.Id == gameId);
//            //context.VideoGames.DeleteOnSubmit(game);
//            //context.SubmitChanges();
//            context.ExecuteCommand("DELETE FROM VideoGames WHERE Id = {0}", gameId);
//        }
//    }