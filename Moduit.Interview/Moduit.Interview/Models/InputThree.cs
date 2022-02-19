using System;
using System.Collections.Generic;

namespace Moduit.Interview.Models
{
    public class InputThree
    {
        public int id { get; set; }
        public int category { get; set; }
        public List<Item> items { get; set; }
        public DateTime createdAt { get; set; }
        public List<string> tags { get; set; }

        public InputThree()
        {
            items = new List<Item>();
            tags = new List<string>();
        }
    }

    public class Item
    {
        public string title { get; set; }
        public string description { get; set; }
        public string footer { get; set; }
    }
}
