﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebConsultas.Models
{
    [Table("Cargo")]
    public class Cargo
    {
        [Key]
        public int idCargo { get; set; }
        [DisplayName("Cargo")]
        public string descricao { get; set; }
    }
}