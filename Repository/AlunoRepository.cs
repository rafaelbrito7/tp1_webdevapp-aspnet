using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Repository
{
    public class AlunoRepository
    {
        private static List<Aluno> Alunos { get; set; } = new List<Aluno>();

        private string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PessoaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Aluno> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                return connection.Query<Aluno>("SELECT * FROM ALUNO").ToList();
            }
        }

        public Aluno GetAlunoById(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                return connection.QueryFirstOrDefault<Aluno>("SELECT * FROM ALUNO WHERE ID = @P1", new { P1 = id });
            }
        }

        public void Save(Aluno aluno)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Execute(@"INSERTO INTO ALUNO(ID, NOME, SOBRENOME, DATANASCIMENTO, EMAIL) 
                                VALUES(@P1,@P2,@P3,@P4,@P5)", new
                {
                    P1 = aluno.Id,
                    P2 = aluno.Nome,
                    P3 = aluno.Sobrenome,
                    P4 = aluno.DataNascimento,
                    P5 = aluno.Email
                });
            }
        }

        public Aluno GetAlunoByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                return connection.QueryFirstOrDefault<Aluno>("SELECT * FROM ALUNO WHERE EMAIL = @P1", new { P1 = email });
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Execute("DELETE FROM ALUNO WHERE ID = @P1", new { P1 = id });
            }
        }
    }
}
