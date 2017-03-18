namespace LoL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matchlist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matchlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        region = c.String(),
                        platformId = c.String(),
                        champion = c.Int(nullable: false),
                        queue = c.String(),
                        season = c.String(),
                        lane = c.String(),
                        role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Matchlists");
        }
    }
}
