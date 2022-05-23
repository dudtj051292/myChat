using System.Collections.ObjectModel;

namespace myChatClass
{
    public sealed class Fnc
    {
        private Fnc() { }

        private static Fnc _fncInstance = new Fnc();

        public static Fnc getFnc()
        {
            if(_fncInstance == null)
            {
                _fncInstance = new Fnc();
                return _fncInstance;
            }
            return _fncInstance;
        }

        public static ObservableCollection<FncWorker> Workers { get; set; }

    }

    public class FncDept
    {
        public string dept { get; set; }
    }

    public class FncWorker
    {
        public FncWorker(string name, string title, string dept, decimal seq) {
            this.name = name;
            this.title = title;
            this.dept = dept;
            this.seq = seq;
        }

        public string name { get; set; }
        public string title { get; set; }
        public string dept { get; set; }
        public decimal seq { get; set; }

    }
}

