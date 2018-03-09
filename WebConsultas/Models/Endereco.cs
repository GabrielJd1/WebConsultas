using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Rua")]
        public string rua { get; set; }
        [DisplayName("Número")]
        public int numero { get; set; }
        [DisplayName("Complemento")]
        public string complemento { get; set; }
        [DisplayName("Observações")]
        public string obs { get; set; }

        [ForeignKey("Estado")]
        public int Estado_idEstado { get; set; }

        public virtual Estado Estado { get; set; }

    }
}