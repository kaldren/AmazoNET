namespace AmazoNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoriesTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Categories ON;");
            Sql("INSERT INTO Categories (Id, Name) VALUES (1, 'Laptops and Desktops')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (2, 'Books')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (3, 'Gaming')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (4, 'Toys')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Categories WHERE Id IN (1, 2, 3, 4)");
        }
    }
}
