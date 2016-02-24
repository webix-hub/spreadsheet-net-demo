namespace SpreadSheet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SheetDatas",
                c => new
                    {
                        Row = c.Int(nullable: false),
                        Column = c.Int(nullable: false),
                        Sheet = c.Int(nullable: false),
                        Value = c.String(),
                        Style = c.String(),
                    })
                .PrimaryKey(t => new { t.Row, t.Column, t.Sheet });
            
            CreateTable(
                "dbo.SheetSizes",
                c => new
                    {
                        Row = c.Int(nullable: false),
                        Column = c.Int(nullable: false),
                        Sheet = c.Int(nullable: false),
                        Size = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Row, t.Column, t.Sheet });
            
            CreateTable(
                "dbo.SheetSpans",
                c => new
                    {
                        Row = c.Int(nullable: false),
                        Column = c.Int(nullable: false),
                        Sheet = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Row, t.Column, t.Sheet });
            
            CreateTable(
                "dbo.SheetStyles",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Sheet = c.Int(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => new { t.Name, t.Sheet });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SheetStyles");
            DropTable("dbo.SheetSpans");
            DropTable("dbo.SheetSizes");
            DropTable("dbo.SheetDatas");
        }
    }
}
