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
        public DbSet<TelefonesFunc> telefones { get; set; }
        public DbSet<Estado> estados { get; set; }
        public DbSet<Endereco> enderecos { get; set; }
        public DbSet<Cidade> cidades { get; set; }
        public DbSet<Cargo> cargos { get; set; }
        public DbSet<Bairro> bairros { get; set; }

        public System.Data.Entity.DbSet<WebConsultas.Models.Perfil> Perfils { get; set; }
    }
}