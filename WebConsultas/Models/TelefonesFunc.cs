using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebConsultas.Models
{
    [Table("TelefonesFunc")]
    public class TelefonesFunc
    {
        [Key]
        public int idTelefone { get; set; }
        public string numero { get; set; }

        [ForeignKey("Funcionario")]
        public int idFuncionario { get; set; }

        public virtual Funcionario funcionario { get; set; }
    }
}