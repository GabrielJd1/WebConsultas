using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebConsultas.Models
{
    [Table("Funcionario")]
    public class Funcionario
    {
        public Funcionario()
        {
            telefones = new List<TelefonesFunc>();
        }
        [Key]
        public int idFuncionario { get; set; }

        public string nome { get; set; }
        public decimal salario { get; set; }
        public DateTime? dataDemi { get; set; }

        [ForeignKey("Cargo")]
        public int Cargo_idCargo { get; set; }
        [ForeignKey("Endereco")]
        public int Endereco_idEndereco { get; set; }

        public virtual Cargo Cargo { get; set; }
        public virtual Endereco Endereco { get; set; }

        public virtual IEnumerable<TelefonesFunc> telefones { get; set; }


    }
}