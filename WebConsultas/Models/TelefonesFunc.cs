﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebConsultas.Models
{
    [Table("TelefonesFunc")]
    public class TelefonesFunc
    {
        [Key]
        public int idTelefone { get; set; }
        [DisplayName("Número")]
        public string numero { get; set; }

        [ForeignKey("Funcionario")]
        public int Funcionario_idFuncionario { get; set; }

        public virtual Funcionario Funcionario { get; set; }
    }
}