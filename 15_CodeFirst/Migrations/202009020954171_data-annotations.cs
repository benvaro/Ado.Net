namespace _15_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataannotations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "DeveloperId", "dbo.Developers");
            DropForeignKey("dbo.Games", "GenreId", "dbo.Genres");
            DropIndex("dbo.Games", new[] { "GenreId" });
            DropIndex("dbo.Games", new[] { "DeveloperId" });
            AlterColumn("dbo.Developers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Games", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Games", "Price", c => c.Double());
            AlterColumn("dbo.Games", "Description", c => c.String(maxLength: 300));
            AlterColumn("dbo.Games", "GenreId", c => c.Int());
            AlterColumn("dbo.Games", "DeveloperId", c => c.Int());
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Games", "GenreId");
            CreateIndex("dbo.Games", "DeveloperId");
            AddForeignKey("dbo.Games", "DeveloperId", "dbo.Developers", "Id");
            AddForeignKey("dbo.Games", "GenreId", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Games", "DeveloperId", "dbo.Developers");
            DropIndex("dbo.Games", new[] { "DeveloperId" });
            DropIndex("dbo.Games", new[] { "GenreId" });
            AlterColumn("dbo.Genres", "Name", c => c.String());
            AlterColumn("dbo.Games", "DeveloperId", c => c.Int(nullable: false));
            AlterColumn("dbo.Games", "GenreId", c => c.Int(nullable: false));
            AlterColumn("dbo.Games", "Description", c => c.String());
            AlterColumn("dbo.Games", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Games", "Name", c => c.String());
            AlterColumn("dbo.Developers", "Name", c => c.String());
            CreateIndex("dbo.Games", "DeveloperId");
            CreateIndex("dbo.Games", "GenreId");
            AddForeignKey("dbo.Games", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Games", "DeveloperId", "dbo.Developers", "Id", cascadeDelete: true);
        }
    }
}
