using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebConsultas.Models
{
    public class WebConsultasContext : DbContext
    {
        public WebConsultasContext() : base("WebConsultas")
        {
            Database.CreateIfNotExists();
        }
        public DbSet<Funcionario> funcionarios { get; set; }
    }
}