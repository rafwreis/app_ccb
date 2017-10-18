using SQLite;

namespace Instrumentos.App.Models
{
    public class Instrument
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Count { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string Occupation { get; set; }

        public string Address { get; set; }

        public string Image { get; set; }

        public bool Default { get; set; }
    }
}