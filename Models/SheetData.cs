using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpreadSheet.Models
{
    [JsonConverter(typeof(SheetDataConverter))]
    public class SheetData
    {
        [Key]
        [Column(Order = 1)]
        public int Row { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Column { get; set; }
        [Key]
        [Column(Order = 3)]
        public int Sheet { get; set; }

        public string Value { get; set; }
        public string Style { get; set; }
        
    }

    [JsonConverter(typeof(SheetStyleConverter))]
    public class SheetStyle
    {
        [Key]
        [Column(Order = 1)]
        public string Name { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Sheet { get; set; }

        public string Text { get; set; }        
    }

    [JsonConverter(typeof(SheetSpanConverter))]
    public class SheetSpan
    {
        [Key]
        [Column(Order = 1)]
        public int Row { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Column { get; set; }
        [Key]
        [Column(Order = 3)]
        public int Sheet { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }        
    }

    [JsonConverter(typeof(SheetSizeConverter))]
    public class SheetSize
    {
        [Key]
        [Column(Order = 1)]
        public int Row { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Column { get; set; }
        [Key]
        [Column(Order = 3)]
        public int Sheet { get; set; }

        public int Size { get; set; }
    }
}