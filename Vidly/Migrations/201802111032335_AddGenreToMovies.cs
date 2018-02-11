namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreToMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MovieGenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "MovieGenreId");
            AddForeignKey("dbo.Movies", "MovieGenreId", "dbo.MovieGenres", "MovieGenreId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieGenreId", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "MovieGenreId" });
            DropColumn("dbo.Movies", "MovieGenreId");
        }
    }
}
