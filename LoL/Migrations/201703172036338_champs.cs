namespace LoL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class champs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Champions",
                c => new
                    {
                        ChampionId = c.Int(nullable: false, identity: true),
                        id = c.Int(nullable: false),
                        title = c.String(),
                        key = c.String(),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.ChampionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Champions");
        }
    }
}
