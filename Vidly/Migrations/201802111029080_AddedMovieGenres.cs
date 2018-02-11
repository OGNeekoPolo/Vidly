namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMovieGenres : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieGenres",
                c => new
                    {
                        MovieGenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.MovieGenreId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MovieGenres");
        }
    }
}
