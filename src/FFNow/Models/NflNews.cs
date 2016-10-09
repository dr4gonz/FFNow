using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace FFNow.Models
{
    [Table("NflNews")]
    public class NflNews
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Opinion { get; set; }
        public string Team { get; set; }
        public NflNews() { }
        public NflNews(string title, string description, string opinion, string team, string link, DateTime date)
        {
            Title = title;
            Description = description;
            Link = link;
            Date = date;
            Opinion = opinion;
            Team = team;
        }
        public NflNews(string title, string description, string team, string link, DateTime date)
        {
            Title = title;
            Description = description;
            Link = link;
            Date = date;
            Team = team;
            Opinion = "";
        }
        public NflNews(string title, string description, string link, DateTime date)
        {
            Title = title;
            Description = description;
            Link = link;
            Date = date;
            Team = "";
            Opinion = "";
        }
        public static async Task<List<NflNews>> GetFeeds()
        {
            string rssUrl = "http://rss.footballguys.com/bloggerrss.xml";
            List<NflNews> news = new List<NflNews>();

            try
            {
                WebRequest request = WebRequest.Create(rssUrl);
                WebResponse response = await request.GetResponseAsync();
                XmlReader reader = XmlReader.Create(response.GetResponseStream());
                XDocument xDoc = XDocument.Load(reader);
                //XNamespace ns = "http://www.w3.org/2005/Atom";


                var items = from x in xDoc.Descendants("item")
                            select new
                            {
                                title = x.Element("title").Value,
                                link = x.Element("link").Value,
                                date = x.Element("pubDate").Value,
                                description = x.Element("description").Value
                            };
                if (items != null)
                {
                    foreach (var i in items)
                    {
                        var newDescription = i.description.Replace("&quot;", @"""");

                        var phrases = new List<String>();
                        var newsTeam = new List<String>();
                        var stringLength = newDescription.Length;
                        int start = 0;
                        int position = 0;
                        int teamPosition = 0;

                        //Find the team name.  Used to display an image
                        do
                        {
                            teamPosition = i.title.IndexOf('|', start);
                            if (teamPosition >= 0)
                            {
                                newsTeam.Add(i.title.Substring(start, teamPosition - 1).Trim());
                                teamPosition = -1;
                            }
                            else
                            {
                                newsTeam.Add("");
                            }
                        } while (teamPosition >= 0);

                        //split the description if there is a Footballguys take on the news.
                        do
                        {
                            position = newDescription.IndexOf("Footballguys", start);
                            if (position >= 0)
                            {
                                phrases.Add(newDescription.Substring(start, position - 1).Trim());
                                phrases.Add(newDescription.Substring(position).Trim());
                                position = -1;
                            }
                        } while (position > 0);

                        //check phrases array to see if the description was split.
                        if (phrases.Count < 1)
                        {
                            NflNews newNews = new NflNews(i.title, newDescription, newsTeam[0], i.link, Convert.ToDateTime(i.date));
                            news.Add(newNews);
                        }
                        else
                        {
                            NflNews newNews = new NflNews(i.title, phrases[0], phrases[1], newsTeam[0], i.link, Convert.ToDateTime(i.date));
                            news.Add(newNews);
                        }

                    }
                }

            }
            catch (Exception e)
            {
                throw;
            }

            return news;
        }
    }
}
