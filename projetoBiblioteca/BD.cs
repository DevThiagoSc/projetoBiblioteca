using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace projetoBiblioteca
{
    class BD
    {
        string coneccao = "server=localhost; port=3306; user id=root; password=; database=biblioteca;";
        //variável para receber o endereço do bd

        private MySqlConnection AbreBanco()
        {
            try
            {
                MySqlConnection con = new MySqlConnection();// usada para conectar com o bd
                con.ConnectionString = this.coneccao;//atribui a váriavel com o endereço do bd para a variável q conecta ao banco
                con.Open();//comando para abrir o banco
                return con;
            }
            catch
            {
                Console.WriteLine("Não conectado");
                return null;
            }
        }

        private void FechaBanco(MySqlConnection con)
        {
            if (con.State == ConnectionState.Open)//verifica se o bd está aberto
            {
                con.Close();//comando para fechar bd
            }
        }

        public MySqlDataReader RetornaDataSet(string strQuery)//função para retornar um obj do bd
        {
            MySqlConnection con = new MySqlConnection();
            try
            {
                con = AbreBanco();
                MySqlCommand cmdComando = new MySqlCommand();//declara uma string de comando
                cmdComando.CommandText = strQuery;//variavel strQuery possui um comando sql
                cmdComando.CommandType = CommandType.Text;//define o comando como um texto
                cmdComando.Connection = con;
                return cmdComando.ExecuteReader();//retorna os resultados do bd para strQuery
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public void ExecutaComando(string sqlcmd) // função q executa comando no banco sem gerar retorno
        {
            MySqlConnection con = new MySqlConnection();
            try
            {
                con = AbreBanco();
                MySqlCommand cmdComando = new MySqlCommand();
                cmdComando.CommandText = sqlcmd;
                cmdComando.CommandType = CommandType.Text;
                cmdComando.Connection = con;
                cmdComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
