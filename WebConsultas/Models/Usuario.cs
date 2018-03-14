using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebConsultas.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }

        public string nick { get; set; }
        public string senha { get; set; }

        [ForeignKey("Funcionario")]
        public int Funcionario_idFuncionario { get; set; }

        public virtual Funcionario Funcionario { get; set; }

        
    }
}