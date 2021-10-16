using System;

namespace series
{
    class Program
    {
        static SerieRepository seriesRepository = new SerieRepository();
        static void Main(string[] args)
        {
            string userOption = getUserOption();

            while (userOption != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        ShowSerieDetails();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = getUserOption();               
            }

            Console.WriteLine("Obrigado por usar nossos servicos");
        }

        public static void ListSeries() {
            Console.WriteLine("Lista de series");

            var seriesList = seriesRepository.List();

            if(seriesList.Count == 0) {
                Console.WriteLine("Nenhuma serie cadastrada");
                return;
            }

            foreach (var serie in seriesList)
            {
                bool isDeleted = serie.isDeleted();

                Console.WriteLine("#ID {0}: {1} {2}", serie.getId(), serie.getTitle(), (isDeleted ? "*Excluido*" : ""));
            }
        }

        public static void InsertSerie() {
            Console.WriteLine("Inserir nova serie");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }

            Console.WriteLine("Digite o genero de acordo com as opcoes acima: ");
            int genre = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da serie: ");
            string title = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da serie: ");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descricao da serie: ");
            string description = Console.ReadLine();

            Serie newSerie = new Serie(id: seriesRepository.nextId(), genre: (Genre)genre, title, description, year);

            seriesRepository.Insert(newSerie);
        }

        public static void UpdateSerie() {
            Console.WriteLine("Digite o id da serie: ");

            int id = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }

            Console.WriteLine("Digite o genero de acordo com as opcoes acima: ");
            int genre = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da serie: ");
            string title = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da serie: ");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descricao da serie: ");
            string description = Console.ReadLine();

            Serie updatedSerie = new Serie(id, genre: (Genre)genre, title, description, year);

            seriesRepository.Update(id, updatedSerie);
        }

        public static void DeleteSerie() {
            Console.WriteLine("Digite o id da serie: ");

            int id = int.Parse(Console.ReadLine());

            seriesRepository
                .getById(id)
                .Delete();
        }

        public static void ShowSerieDetails() {
            Console.WriteLine("Digite o id da serie: ");

            int id = int.Parse(Console.ReadLine());

            var serie = seriesRepository
                .getById(id)
                .ToString();
            
            Console.WriteLine(serie);
        }

        public static string getUserOption() {
            Console.WriteLine();
            Console.WriteLine("Dio Series a seu Dispor");
            Console.WriteLine("Informe a opcoa desejada:");
            Console.WriteLine("1 - Listar series");
            Console.WriteLine("2 - Inserir uma nova serie");
            Console.WriteLine("3 - Atualizar serie");
            Console.WriteLine("4 - Deletar serie");
            Console.WriteLine("5 - Visualizar serie");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();

            Console.WriteLine();

            return userOption;
        }
    }
}
