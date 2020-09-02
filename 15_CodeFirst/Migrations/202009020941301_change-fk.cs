namespace _15_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changefk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "Developer_Id", "dbo.Developers");
            DropForeignKey("dbo.Games", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Games", new[] { "Developer_Id" });
            DropIndex("dbo.Games", new[] { "Genre_Id" });
            RenameColumn(table: "dbo.Games", name: "Developer_Id", newName: "DeveloperId");
            RenameColumn(table: "dbo.Games", name: "Genre_Id", newName: "GenreId");
            AlterColumn("dbo.Games", "DeveloperId", c => c.Int(nullable: false));
            AlterColumn("dbo.Games", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Games", "GenreId");
            CreateIndex("dbo.Games", "DeveloperId");
            AddForeignKey("dbo.Games", "DeveloperId", "dbo.Developers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Games", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Games", "DeveloperId", "dbo.Developers");
            DropIndex("dbo.Games", new[] { "DeveloperId" });
            DropIndex("dbo.Games", new[] { "GenreId" });
            AlterColumn("dbo.Games", "GenreId", c => c.Int());
            AlterColumn("dbo.Games", "DeveloperId", c => c.Int());
            RenameColumn(table: "dbo.Games", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.Games", name: "DeveloperId", newName: "Developer_Id");
            CreateIndex("dbo.Games", "Genre_Id");
            CreateIndex("dbo.Games", "Developer_Id");
            AddForeignKey("dbo.Games", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Games", "Developer_Id", "dbo.Developers", "Id");
        }
    }
}
