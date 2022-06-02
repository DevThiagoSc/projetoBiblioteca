using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace projetoBiblioteca
{
    class ClassBooks
    {
        BD bd = new BD();
        MySqlDataReader objDados;
        StringBuilder strQuery = new StringBuilder();
        string sqlcmd;
        string show;

        List<string> Livro = new List<string>();
        List<string> Autor = new List<string>();
        List<string> gen = new List<string>();
        List<string> ano = new List<string>();

        //atributos:
        String nomeLivro;
        String nomeAutor;
        String genero;
        String anoLancamento;

        public ClassBooks()
        {
        }

        //classe construtora:
        public ClassBooks(String id, string nomeLivro, string nomeAutor, string genero, string anoLancamento)
        {
            this.nomeLivro = nomeLivro;
            this.nomeAutor = nomeAutor;
            this.genero = genero;
            this.anoLancamento = anoLancamento;
        }

        //construtores:
        public string NomeLivro { get => nomeLivro; set => nomeLivro = value; }
        public string NomeAutor { get => nomeAutor; set => nomeAutor = value; }
        public string Genero { get => genero; set => genero = value; }
        public string AnoLancamento { get => anoLancamento; set => anoLancamento = value; }

        //metodos:
        public void RegistrarLivro() 
        {
            sqlcmd = "Insert into livros (nomeLivro, nomeAutor, genero, anoLancamento)" +
                "values(";
            sqlcmd += "'" + nomeLivro + "',";
            sqlcmd += "'" + nomeAutor + "',";
            sqlcmd += "'" + genero + "',";
            sqlcmd += "'" + anoLancamento + "')";

            bd.ExecutaComando(sqlcmd);
        }

        public void ExibirLivros() 
        {
            strQuery.Append("Select * from livros");
            objDados = bd.RetornaDataSet(strQuery.ToString());

            while (objDados.Read())
            {
                Livro.Add(objDados["nomeLivro"].ToString());
                Autor.Add(objDados["nomeAutor"].ToString());
                gen.Add(objDados["genero"].ToString());
                ano.Add(objDados["anoLancamento"].ToString());
            }
            if (!objDados.IsClosed) { objDados.Close(); strQuery.Remove(0, strQuery.Length); }

            for(int i = 0; i < Livro.Count; i++)
            {
                Console.WriteLine($"{Livro[i]} | autor: {Autor[i]} | gênero: {gen[i]} | Ano: {ano[i]}");
            }
        }

        public void PesquisarLivros(string search)
        {
            strQuery.Append("Select * from livros where nomeLivro = '" + search + "';");
            objDados = bd.RetornaDataSet(strQuery.ToString());
            
            while (objDados.Read()) 
            {
                 show = objDados["nomeLivro"].ToString() + "\n" +
                        objDados["nomeAutor"].ToString() + "\n" +
                        objDados["genero"].ToString() + "\n" +
                        objDados["anoLancamento"].ToString();
            }

            Console.WriteLine(show);
        }

        public void AtualizarLivro(string search)
        {
            sqlcmd = "Update livros set ";
            sqlcmd += "nomeLivro = '" + nomeLivro + "',";
            sqlcmd += "nomeAutor = '" + nomeAutor + "',";
            sqlcmd += "genero = '" + genero + "',";
            sqlcmd += "anoLancamento = '" + anoLancamento + "'";
            sqlcmd += " where nomeLivro = '" + search + "';";

            bd.ExecutaComando(sqlcmd);
        }

        public void ExcluirLivro(string search)
        {
            sqlcmd = "delete from livros where nomeLivro = '" + search + "';";
            bd.ExecutaComando(sqlcmd);
        }
    }
}