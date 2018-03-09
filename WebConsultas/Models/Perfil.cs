using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebConsultas.Models
{
    [Table("Perfil")]
    public class Perfil
    {
        [Key]
        public int idPerfil { get; set; }
        [DisplayName("Perfil")]
        public string descricao { get; set; }
    }   

}