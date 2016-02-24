namespace SpreadSheet.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SpreadSheet.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SpreadSheet.Models.SpreadSheetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SpreadSheet.Models.SpreadSheetContext context)
        {
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [SheetDatas]");
            context.SheetDatas.AddOrUpdate(x => new { x.Row, x.Column, x.Sheet },
                new SheetData() { Row = 1, Column = 1, Value = "Webix Spreadsheet", Style = "", Sheet = 1 },
                new SheetData() { Row = 1, Column = 1, Value = "Second Page", Style = "", Sheet = 2 }
            );
        }
    }
}
