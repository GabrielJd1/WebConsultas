namespace WebConsultas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bairro",
                c => new
                    {
                        idBairro = c.Int(nullable: false, identity: true),
                        descricao = c.String(),
                        Cidade_idCidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idBairro)
                .ForeignKey("dbo.Cidade", t => t.Cidade_idCidade, cascadeDelete: true)
                .Index(t => t.Cidade_idCidade);
            
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        idCidade = c.Int(nullable: false, identity: true),
                        descricao = c.String(),
                        Estado_idEstado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCidade)
                .ForeignKey("dbo.Estado", t => t.Estado_idEstado, cascadeDelete: true)
                .Index(t => t.Estado_idEstado);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        idEstado = c.Int(nullable: false, identity: true),
                        descricao = c.String(),
                    })
                .PrimaryKey(t => t.idEstado);
            
            CreateTable(
                "dbo.Cargo",
                c => new
                    {
                        idCargo = c.Int(nullable: false, identity: true),
                        descricao = c.String(),
                    })
                .PrimaryKey(t => t.idCargo);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        idEndereco = c.Int(nullable: false, identity: true),
                        rua = c.String(),
                        numero = c.Int(nullable: false),
                        complemento = c.String(),
                        obs = c.String(),
                        Estado_idEstado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idEndereco)
                .ForeignKey("dbo.Estado", t => t.Estado_idEstado, cascadeDelete: true)
                .Index(t => t.Estado_idEstado);
            
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        idFuncionario = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        salario = c.Decimal(precision: 18, scale: 2),
                        dataDemi = c.DateTime(),
                        Cargo_idCargo = c.Int(nullable: false),
                        Endereco_idEndereco = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idFuncionario)
                .ForeignKey("dbo.Cargo", t => t.Cargo_idCargo, cascadeDelete: true)
                .ForeignKey("dbo.Endereco", t => t.Endereco_idEndereco, cascadeDelete: true)
                .Index(t => t.Cargo_idCargo)
                .Index(t => t.Endereco_idEndereco);
            
            CreateTable(
                "dbo.TelefonesFunc",
                c => new
                    {
                        idTelefone = c.Int(nullable: false, identity: true),
                        numero = c.String(),
                        Funcionario_idFuncionario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idTelefone)
                .ForeignKey("dbo.Funcionario", t => t.Funcionario_idFuncionario, cascadeDelete: true)
                .Index(t => t.Funcionario_idFuncionario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TelefonesFunc", "Funcionario_idFuncionario", "dbo.Funcionario");
            DropForeignKey("dbo.Funcionario", "Endereco_idEndereco", "dbo.Endereco");
            DropForeignKey("dbo.Funcionario", "Cargo_idCargo", "dbo.Cargo");
            DropForeignKey("dbo.Endereco", "Estado_idEstado", "dbo.Estado");
            DropForeignKey("dbo.Bairro", "Cidade_idCidade", "dbo.Cidade");
            DropForeignKey("dbo.Cidade", "Estado_idEstado", "dbo.Estado");
            DropIndex("dbo.TelefonesFunc", new[] { "Funcionario_idFuncionario" });
            DropIndex("dbo.Funcionario", new[] { "Endereco_idEndereco" });
            DropIndex("dbo.Funcionario", new[] { "Cargo_idCargo" });
            DropIndex("dbo.Endereco", new[] { "Estado_idEstado" });
            DropIndex("dbo.Cidade", new[] { "Estado_idEstado" });
            DropIndex("dbo.Bairro", new[] { "Cidade_idCidade" });
            DropTable("dbo.TelefonesFunc");
            DropTable("dbo.Funcionario");
            DropTable("dbo.Endereco");
            DropTable("dbo.Cargo");
            DropTable("dbo.Estado");
            DropTable("dbo.Cidade");
            DropTable("dbo.Bairro");
        }
    }
}
