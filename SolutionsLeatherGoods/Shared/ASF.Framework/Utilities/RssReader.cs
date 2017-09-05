using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;

namespace ASF.Framework.Utilities
{
    public class RssReader
    {
        public List<RssItem> GetRssFeed(string url)
        {
            var req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";
            req.UserAgent = "Fiddler";

            var rep = req.GetResponse();
            var reader = XmlReader.Create(input: rep.GetResponseStream());
            var doc = XDocument.Load(reader, LoadOptions.None);

            return (doc.Descendants("channel").Elements("item").Select(i => new RssItem
            {

                Title = i.Element("title") != null ? i.Element("title").Value : null,
                Link = i.Element("link") != null ? i.Element("link").Value : null,
                Description = i.Element("description") != null ? i.Element("description").Value : null
            })).ToList();
        }
    }

    [Serializable]
    public class RssItem
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
    }
}
