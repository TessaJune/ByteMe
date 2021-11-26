using System;

namespace Trainor.App.Entities
{
    public struct Resource
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}