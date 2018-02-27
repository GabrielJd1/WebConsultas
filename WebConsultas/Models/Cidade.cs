using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebConsultas.Models
{
    [Table("Cidade")]
    public class Cidade
    {
        public Cidade()
        {
            bairros = new List<Bairro>();
        }
        [Key]
        public int idCidade { get; set; }
        public string descricao { get; set; }

        [ForeignKey("Estado")]
        public int idEstado { get; set; }

        public virtual Estado estado { get; set; }
        public virtual IEnumerable<Bairro> bairros { get; set; }

    }
}