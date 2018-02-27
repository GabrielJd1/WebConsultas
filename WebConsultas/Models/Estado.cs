using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebConsultas.Models
{
    public class Estado
    {
        public Estado()
        {
            cidades = new List<Cidade>();
        }
        [Key]
        public int idEstado { get; set; }
        public string descricao { get; set; }
        public virtual IEnumerable<Cidade> cidades { get; set; }
    }
}