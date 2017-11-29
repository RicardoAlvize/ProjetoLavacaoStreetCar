namespace ProjetoLavacaoStreetCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabela4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carroes", "Marca", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Carroes", "Modelo", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Carroes", "Placa", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Clientes", "Nome", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Clientes", "Cpf", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Clientes", "Telefone", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Empresas", "Nome", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Empresas", "Endereco", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Empresas", "Cnpj", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Funcionarios", "Nome", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Funcionarios", "Matricula", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Funcionarios", "Matricula", c => c.Int(nullable: false));
            AlterColumn("dbo.Funcionarios", "Nome", c => c.String());
            AlterColumn("dbo.Empresas", "Cnpj", c => c.String());
            AlterColumn("dbo.Empresas", "Endereco", c => c.String());
            AlterColumn("dbo.Empresas", "Nome", c => c.String());
            AlterColumn("dbo.Clientes", "Telefone", c => c.Int(nullable: false));
            AlterColumn("dbo.Clientes", "Cpf", c => c.Int(nullable: false));
            AlterColumn("dbo.Clientes", "Nome", c => c.String());
            AlterColumn("dbo.Carroes", "Placa", c => c.String());
            AlterColumn("dbo.Carroes", "Modelo", c => c.String());
            AlterColumn("dbo.Carroes", "Marca", c => c.String());
        }
    }
}
