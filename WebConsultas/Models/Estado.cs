using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebConsultas.Models
{
    [Table("Estado")]
    public class Estado
    {
        public Estado()
        {
            Cidades = new List<Cidade>();
        }
        [Key]
        public int idEstado { get; set; }
        [DisplayName("Estado")]
        public string descricao { get; set; }
        public virtual IEnumerable<Cidade> Cidades { get; set; }
    }
}