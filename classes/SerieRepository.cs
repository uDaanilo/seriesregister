using series.Interfaces;
using System.Collections.Generic;

namespace series
{
    public class SerieRepository : IRepository<Serie> {
        private List<Serie> seriesList = new List<Serie>();

        public List<Serie> List() {
            return seriesList;
        }

        public void Update(int id, Serie entity) {
            seriesList[id] = entity;
        }

        public void Delete(int id) {
            seriesList[id].Delete();
        }

        public void Insert(Serie entity) {
            seriesList.Add(entity);
        }

        public int nextId() {
            return seriesList.Count;
        }

        public Serie getById(int id) {
            return seriesList[id];
        }
    }
}