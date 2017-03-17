namespace LoL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class players : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        playerOrTeamId = c.String(),
                        playerOrTeamName = c.String(),
                    })
                .PrimaryKey(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Players");
        }
    }
}
