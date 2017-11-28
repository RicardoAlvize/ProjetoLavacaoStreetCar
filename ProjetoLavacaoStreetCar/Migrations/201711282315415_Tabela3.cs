namespace ProjetoLavacaoStreetCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabela3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Empresas", "Cnpj", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Empresas", "Cnpj", c => c.Int(nullable: false));
        }
    }
}
