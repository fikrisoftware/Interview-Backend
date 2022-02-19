using System;
using System.Collections.Generic;
namespace Moduit.Interview.Models
{
    public class InputOutputTwo
    {
        public int id { get; set; }
        public int category { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string footer { get; set; }
        public DateTime createdAt { get; set; }
        public List<string> tags { get; set; }

        public InputOutputTwo()
        {
            tags = new List<string>();
        }
    }
}
