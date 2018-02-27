using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebConsultas.Models
{
    [Table("Endereco")]
    public class Endereco
    {
        [Key]
        public int idEndereco { get; set; }
        public string rua { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public string obs { get; set; }

        [ForeignKey("Estado_idEstado")]
        public int Estado_idEstado { get; set; }

        public virtual Estado estado { get; set; }

    }
}