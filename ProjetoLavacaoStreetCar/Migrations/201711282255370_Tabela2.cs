namespace ProjetoLavacaoStreetCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabela2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Funcionarios", "Horario", c => c.String());
            DropColumn("dbo.Funcionarios", "Empresa");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Funcionarios", "Empresa", c => c.String());
            DropColumn("dbo.Funcionarios", "Horario");
        }
    }
}
