namespace ProjetoLavacaoStreetCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelasModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Marca = c.String(),
                        Modelo = c.String(),
                        Cor = c.String(),
                        Placa = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        Cpf = c.Int(nullable: false),
                        Endereco = c.String(),
                        Telefone = c.Int(nullable: false),
                        CarroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carroes", t => t.CarroId, cascadeDelete: true)
                .Index(t => t.CarroId);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Endereco = c.String(),
                        Cnpj = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        Matricula = c.Int(nullable: false),
                        Empresa = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "CarroId", "dbo.Carroes");
            DropIndex("dbo.Clientes", new[] { "CarroId" });
            DropTable("dbo.Funcionarios");
            DropTable("dbo.Empresas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Carroes");
        }
    }
}
