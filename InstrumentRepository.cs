using System.Collections.Generic;
using Instrumentos.App.Models;
using SQLite;
using System.Linq;

namespace Instrumentos.App
{
    public class InstrumentRepository
    {
        private readonly SQLiteConnection _sqlConnection;

        public InstrumentRepository()
        {
            _sqlConnection = new SQLiteConnection(FileHelper.GetLocalFilePath());
            _sqlConnection.CreateTable<Instrument>();
        }

        public List<Instrument> Get()
        {
            return _sqlConnection.Table<Instrument>().ToList();
        }

        public Instrument Get(int id)
        {
            return _sqlConnection.Table<Instrument>().FirstOrDefault(w => w.Id == id);
        }

        public void Add(Instrument entity)
        {
            _sqlConnection.Insert(entity);
        }

        public void AddDefaultInstrument()
        {
            _sqlConnection.InsertAll(DefaultListInstrument());
        }

        public void Delete(Instrument entity)
        {
            _sqlConnection.Delete(entity);
        }

        public void Update(Instrument entity)
        {
            _sqlConnection.Update(entity);
        }

        private List<Instrument> DefaultListInstrument()
        {
            return new List<Instrument>()
            {
                new Instrument() { Name = "Acordeon", Category = "Aerofone", Default = true, Image = "acordeon", Count = 0 },
                new Instrument() { Name = "Clarineta", Category = "Madeira", Default = true, Image = "clarineta", Count = 0 },
                new Instrument() { Name = "Clarone", Category = "Madeira", Default = true, Image = "clarone_alto", Count = 0 },
                new Instrument() { Name = "Corne Inglês", Category = "Madeira", Default = true, Image = "corne_ingles", Count = 0 },
                new Instrument() { Name = "Eufônio", Category = "Metal", Default = true, Image = "eufonio", Count = 0 },
                new Instrument() { Name = "Fagote", Category = "Madeira", Default = true, Image = "fagote", Count = 0 },
                new Instrument() { Name = "Flauta", Category = "Madeira", Default = true, Image = "flauta", Count = 0 },
                new Instrument() { Name = "Flugelhorn", Category = "Metal", Default = true, Image = "flugelhorn", Count = 0 },
                new Instrument() { Name = "Melofone", Category = "Metal", Default = true, Image = "melofone", Count = 0 },
                new Instrument() { Name = "Oboé", Category = "Madeira", Default = true, Image = "oboe", Count = 0 },
                new Instrument() { Name = "Orgão", Category = "Teclas", Default = true, Image = "orgao", Count = 0 },
                new Instrument() { Name = "Pocket", Category = "Metal", Default = true, Image = "pocket", Count = 0 },
                new Instrument() { Name = "Saxofone Alto", Category = "Metal", Default = true, Image = "saxofone_alto", Count = 0 },
                new Instrument() { Name = "Saxofone Baixo", Category = "Metal", Default = true, Image = "saxofone_baixo", Count = 0 },
                new Instrument() { Name = "Saxofone Barítono", Category = "Metal", Default = true, Image = "saxofone_baritono", Count = 0 },
                new Instrument() { Name = "Saxofone Genis (Horn)", Category = "Metal", Default = true, Image = "saxhorn", Count = 0 },
                new Instrument() { Name = "Saxofone Tenor", Category = "Metal", Default = true, Image = "saxofone_tenor", Count = 0 },
                new Instrument() { Name = "Saxofone Soprano Curvo", Category = "Metal", Default = true, Image = "saxofone_soprano_curvo", Count = 0 },
                new Instrument() { Name = "Saxofone Soprano Reto", Category = "Metal", Default = true, Image = "saxofone_soprano_reto", Count = 0 },
                new Instrument() { Name = "Trombone", Category = "Metal", Default = true, Image = "trombone", Count = 0 },
                new Instrument() { Name = "Trombonito", Category = "Metal", Default = true, Image = "trombonito", Count = 0 },
                new Instrument() { Name = "Trompa", Category = "Metal", Default = true, Image = "trompa", Count = 0 },
                new Instrument() { Name = "Trompete", Category = "Metal", Default = true, Image = "trompete", Count = 0 },
                new Instrument() { Name = "Tuba", Category = "Metal", Default = true, Image = "tuba", Count = 0 },
                new Instrument() { Name = "Viola", Category = "Cordas", Default = true, Image = "viola", Count = 0 },
                new Instrument() { Name = "Violino", Category = "Cordas", Default = true, Image = "violino", Count = 0 },
                new Instrument() { Name = "Violoncelo", Category = "Cordas", Default = true, Image = "violoncelo", Count = 0 },

                new Instrument() { Name = "Ancião", Category = "Ministério", Default = true, Image = "pessoa", Count = 0 },
                new Instrument() { Name = "Diácono", Category = "Ministério", Default = true, Image = "pessoa", Count = 0 },
                new Instrument() { Name = "Cooperador Oficial", Category = "Ministério", Default = true, Image = "pessoa", Count = 0 },
                new Instrument() { Name = "Cooperador Jovem", Category = "Ministério", Default = true, Image = "pessoa", Count = 0 },
                new Instrument() { Name = "Encarregado Regional", Category = "Ministério", Default = true, Image = "pessoa", Count = 0 },
                new Instrument() { Name = "Encarregado Local", Category = "Ministério", Default = true, Image = "pessoa", Count = 0 },
                new Instrument() { Name = "Instrutor", Category = "Ministério", Default = true, Image = "pessoa", Count = 0 },
                new Instrument() { Name = "Secretário", Category = "Ministério", Default = true, Image = "pessoa", Count = 0 }
            };
        }
    }
}
