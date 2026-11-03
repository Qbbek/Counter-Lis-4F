using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace counter.Models
{
    internal class CounterCreator
    {
        public string titleEntryPlaceholder => "Enter the title of your counter";
        public string baseNumberEntryPlaceholder => "Enter your starting number (empty = 0)";
        public string saveButtonText => "Save";
        public string cancelButtonText => "Cancel";
    }
}
