using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace counter.Models
{
    internal class AllCounters
    {
        public ObservableCollection<Counter> Counters { get; set; } = new ObservableCollection<Counter>();
        public AllCounters() =>
            LoadCounters();

        public void LoadCounters()
        {
            Counters.Clear();

            string appDataPath = FileSystem.AppDataDirectory;

            IEnumerable<Counter> counters = Directory
                .EnumerateFiles(appDataPath, "*.counter.txt")
                .Select(fileName => new Counter()
                {
                    filename = fileName,
                    title = File.ReadAllLines(fileName)[0],
                    baseSetNumber = int.Parse(File.ReadAllLines(fileName)[1]),
                    currentNumber = int.Parse(File.ReadAllLines(fileName)[2]),
                    date = File.GetCreationTime(fileName)
                })
                .OrderBy(counter => counter.date);
            foreach (Counter counter in counters)
            {
                Counters.Add(counter);
            }
        }
    }
}
