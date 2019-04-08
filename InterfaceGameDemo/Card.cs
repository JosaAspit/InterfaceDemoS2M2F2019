using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceGameDemo
{
    class Card
    {
        public Card(string color, int value, string name)
        {
            Color = color;
            Value = value;
            Name = name;
        }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Value { get; set; }
    }
}
