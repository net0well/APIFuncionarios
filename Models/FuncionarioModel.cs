using System.ComponentModel.DataAnnotations;
using APIFuncionarios.Enums;

namespace APIFuncionarios.Models
{
    public class FuncionarioModel
    {
        [Key] // indica que o id é uma primary key
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public DepartamentoEnum Departamento { get; set; } // enumerable

        public bool Ativo { get; set; }

        public TurnoEnum Turno { get; set; } // enumerable

        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime(); // define a data atual da criação
        public DateTime DateDeAlteracao { get; set; } = DateTime.Now.ToLocalTime(); // define a data atual de altaração

    }
}
