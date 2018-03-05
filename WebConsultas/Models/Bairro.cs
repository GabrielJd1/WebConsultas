using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebConsultas.Models
{
    [Table("Bairro")]
    public class Bairro
    {
        //editei
        [Key]
        public int idBairro { get; set; }
        public string descricao { get; set; }
        [ForeignKey("Cidade")]
        public int idCidade { get; set; }
        public virtual Cidade cidade { get; set; }


    }

}