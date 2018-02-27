using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebConsultas.Models
{
    public class Cargo
    {
        [Key]
        public int idCargo { get; set; }
        public string descricao { get; set; }
    }
}