using System;
using System.Collections.Generic;

namespace Trainor.App.Entities
{
    public struct Resource
    {
        public Resource(string name, string link, IEnumerable<string> authors, string type, DateTime date)
        {
            Name = name;
            Link = link;
            Authors = authors;
            Type = type;
            Date = date;
        }
        public string Name { get; set; }
        public string Link { get; set; }
        public IEnumerable<string> Authors { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
    }

    public enum ResourceType
    {
        VIDEO,
        DOCUMENT,
        OTHER,
    }
}