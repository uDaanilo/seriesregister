using System;

namespace series
{
    public class Serie : BaseEntity
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }

        public Serie(int id, Genre genre, string title, string description, int year) {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string toReturn = "";

            toReturn += $"Genero: {this.Genre}" + Environment.NewLine;
            toReturn += $"Titulo: {this.Title}" + Environment.NewLine;
            toReturn += $"Descricao: {this.Description}" + Environment.NewLine;
            toReturn += $"Ano: {this.Year}" + Environment.NewLine;;
            toReturn += $"Excluido: {this.Deleted}";

            return toReturn;
        }

        public string getTitle() {
            return this.Title;
        }

        public int getId() {
            return this.Id;
        }

        public bool isDeleted() {
            return this.Deleted;
        }

        public void Delete() {
            this.Deleted = true;
        }
    }
}