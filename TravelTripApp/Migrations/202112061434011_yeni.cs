namespace TravelTripApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yeni : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "Baslik", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "Aciklama", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "BlogImage", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "BlogImage", c => c.String());
            AlterColumn("dbo.Blogs", "Aciklama", c => c.String());
            AlterColumn("dbo.Blogs", "Baslik", c => c.String());
        }
    }
}
