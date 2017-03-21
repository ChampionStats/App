namespace LoL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class runes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Runes",
                c => new
                    {
                        RunesId = c.Int(nullable: false, identity: true),
                        description = c.String(),
                        id = c.Int(nullable: false),
                        name = c.String(),
                        tier = c.String(),
                        type = c.String(),
                        isRune = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RunesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Runes");
        }
    }
}
