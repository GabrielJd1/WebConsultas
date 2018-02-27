using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebConsultas.Models
{
    public class Funcionario
    {
        public Funcionario()
        {
            telefones = new List<Telefone>();
        }
        [Key]
        public int idFuncionario { get; set; }

        public string nome { get; set; }
        public decimal salario { get; set; }
        public DateTime dataDemi { get; set; }

        [ForeignKey("Cargo")]
        public int idCargo { get; set; }
        [ForeignKey("Endereco")]
        public int idEndereco { get; set; }

        public virtual Cargo cargo { get; set; }
        public virtual Endereco endereco { get; set; }

        public virtual IEnumerable<Telefone> telefones { get; set; }


    }
}