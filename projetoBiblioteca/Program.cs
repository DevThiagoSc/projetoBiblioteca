using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace projetoBiblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassBooks cb = new ClassBooks();

            int escolha;
            string search;

            do
            {
                Console.WriteLine("1 - Cadastrar livro \n" +
                              "2 - Exibir livros \n" +
                              "3 - Pesquisar livro \n" +
                              "4 - atualizar livro \n" +
                              "5 - Excluir livro \n" +
                              "6 - Encerrar programa \n");
                escolha = int.Parse(Console.ReadLine());

                if (escolha == 1)
                {
                    Console.Write("Nome do Livro: \n");
                    cb.NomeLivro = Console.ReadLine();

                    Console.Write("Autor do Livro: \n");
                    cb.NomeAutor = Console.ReadLine();

                    Console.Write("Gênero do Livro: \n");
                    cb.Genero = Console.ReadLine();

                    Console.Write("Ano de lançamento: \n");
                    cb.AnoLancamento = Console.ReadLine();

                    cb.RegistrarLivro();
                }
                else if (escolha == 2)
                {
                    cb.ExibirLivros();
                }
                else if (escolha == 3)
                {
                    Console.Write("Digite o nome do livro: ");
                    search = Console.ReadLine();

                    cb.PesquisarLivros(search);
                }
                else if (escolha == 4)
                {
                    Console.Write("Digite o nome do livro: ");
                    search = Console.ReadLine();

                    Console.Write("Nome do Livro: \n");
                    cb.NomeLivro = Console.ReadLine();

                    Console.Write("Autor do Livro: \n");
                    cb.NomeAutor = Console.ReadLine();

                    Console.Write("Gênero do Livro: \n");
                    cb.Genero = Console.ReadLine();

                    Console.Write("Ano de lançamento: \n");
                    cb.AnoLancamento = Console.ReadLine();

                    cb.AtualizarLivro(search);
                }
                else if(escolha == 5)
                {
                    Console.Write("Digite o nome do livro que deseja excluir: ");
                    search = Console.ReadLine();

                    cb.ExcluirLivro(search);
                }
            } while (escolha != 6);
        }
    }
}
