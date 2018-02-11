namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateMovieGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.MovieGenres (GenreName) VALUES ('Comedy')");
            Sql("INSERT INTO dbo.MovieGenres (GenreName) VALUES ('Action')");
            Sql("INSERT INTO dbo.MovieGenres (GenreName) VALUES ('Family')");
            Sql("INSERT INTO dbo.MovieGenres (GenreName) VALUES ('Romance')");
            Sql("INSERT INTO dbo.MovieGenres (GenreName) VALUES ('Horror')");
        }

        public override void Down()
        {
        }
    }
}
