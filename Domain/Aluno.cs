using System;

namespace Domain
{
    public class Aluno
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Sobrenome { get; set; }
        public String DataNascimento { get; set; }
        public String Email { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        NAO_ATIVO,
        ATIVO
    }
}
