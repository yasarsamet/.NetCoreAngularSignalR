using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRExampleAPI.Models
{

    public enum ECity
    {
        Istanbul = 1,
        Ankara = 2,
        Konya = 4,
        Antalya = 5,
        İzmir = 3,
    }
    public class Covid
    {
        public int Id { get; set; }
        public ECity City { get; set; }
        public int Count { get; set; }
        public DateTime CovidDate { get; set; }
    }
    public class CovidChart
    {
        public CovidChart()
        {
            Counts = new List<int>();
        }
        public string CovidDate { get; set; }
        public List<int> Counts { get; set; }

    }
}
