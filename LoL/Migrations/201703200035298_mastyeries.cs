namespace LoL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mastyeries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Masteries",
                c => new
                    {
                        MasteryId = c.Int(nullable: false, identity: true),
                        id = c.Int(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.MasteryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Masteries");
        }
    }
}
