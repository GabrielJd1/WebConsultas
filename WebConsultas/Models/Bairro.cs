using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Bairro")]
        public string descricao { get; set; }

        [ForeignKey("Cidade")]
        public int Cidade_idCidade { get; set; }

        public virtual Cidade Cidade { get; set; }


    }

}