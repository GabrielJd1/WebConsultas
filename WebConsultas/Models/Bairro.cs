﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebConsultas.Models
{
    public class Bairro
    {

        [Key]
        public int idBairro { get; set; }
        public string descricao { get; set; }
        [ForeignKey("Cidade")]
        public int idCidade { get; set; }
        public virtual Cidade cidade { get; set; }


    }

}