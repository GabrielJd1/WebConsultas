using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("Nome Funcionário")]
        [Required(ErrorMessage = "Digite o nome do funcionário.")]
        public string nome { get; set; }
        [DisplayName("Salário")]
        [Required(ErrorMessage = "Digite o salário do funcionário.")]
        public double salario { get; set; }
        [DisplayName("Data Demissão")]
        public DateTime? dataDemi { get; set; }

      
        [ForeignKey("Cargo")]
        [DisplayName("Cargo")]
        public int Cargo_idCargo { get; set; }

        [ForeignKey("Endereco")]
        [DisplayName("Endereco")]
        public int Endereco_idEndereco { get; set; }

        public virtual Cargo Cargo { get; set; }
        public virtual Endereco Endereco { get; set; }

        public virtual IEnumerable<TelefonesFunc> telefones { get; set; }


    }
}