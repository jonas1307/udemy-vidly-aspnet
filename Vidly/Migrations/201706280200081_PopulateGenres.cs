namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES (Name) VALUES ('Drama')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Comedy')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Adventure')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Documentary')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Family')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Action')");
        }
        
        public override void Down()
        {
        }
    }
}
