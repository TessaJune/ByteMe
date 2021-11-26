using System;

namespace Trainor.App.Entities
{
    public struct Resource
    {
        public Resource(string name, string link, IEnumerable<string> authors, string type, DateTime date) 
        {
            this.name = name;
            this.link = link;
            this.authors = authors;
            this.type = type;
            this.date = date;
        }
        public string Name { get; set; }
        public string Link { get; set; }
        public IEnumerable<string> Authors { get; set; }
        public string Type { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}