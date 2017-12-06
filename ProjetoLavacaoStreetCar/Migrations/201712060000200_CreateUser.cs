namespace ProjetoLavacaoStreetCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3f8552ec-b465-472d-84ed-a95d5a422297', N'ricardo.alvize@gmail.com', 0, N'AHW+4qCzO+z68vxZqhWZPistsMH4iSmzt7JrMwYGRcWvOeDaKG/1py408aPxqonDPw==', N'c270c525-226d-4746-9b4a-3be9995b2e22', NULL, 0, 0, NULL, 1, 0, N'ricardo.alvize@gmail.com')
                
                

                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'28515ddc-fc54-4a47-9c10-9b987dd2ec12', N'CanManageCustomers')



       ");

        }
        
        public override void Down()
        {
        }
    }
}
