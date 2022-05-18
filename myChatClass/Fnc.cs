using System.Collections.ObjectModel;

namespace myChatClass
{
    class Fnc
    {
        public Fnc()
        {
            this.Workers = new ObservableCollection<FncWorker>();
        }
        public string Name { get; set; }
        public ObservableCollection<FncWorker> Workers { get; set; }

    }

    public class FncDept
    {
        public string dept { get; set; }
    }

    public class FncWorker
    {
        public string name { get; set; }
        public string title { get; set; }
        public string dept { get; set; }
        public int seq { get; set; }

    }
}

