using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SpreadSheet.Models
{
    public class SpreadSheetContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SpreadSheetContext() : base("name=SpreadSheetContext")
        {
        }

        public System.Data.Entity.DbSet<SpreadSheet.Models.SheetData> SheetDatas { get; set; }
        public System.Data.Entity.DbSet<SpreadSheet.Models.SheetStyle> SheetStyles { get; set; }
        public System.Data.Entity.DbSet<SpreadSheet.Models.SheetSize> SheetSizes { get; set; }
        public System.Data.Entity.DbSet<SpreadSheet.Models.SheetSpan> SheetSpans { get; set; }
    }
}
