namespace Trabalho_2_webForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INicial_2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pagamento", "IdFormaPagamento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pagamento", "IdFormaPagamento", c => c.Long(nullable: false));
        }
    }
}
