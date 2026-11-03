using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace counter.Models
{
    internal class Counter
    {
        public string filename { get; set; }
        public DateTime date { get; set; }
        public string title { get; set; }
        public int baseSetNumber { get; set; }
        public int currentNumber { get; set; }
        public char addButtonCharacter => '+';
        public char subtractButtonCharacter => '-';
        public string resetButtonText => "Reset";
        public string deleteButtonText => "Delete";
    }
}
