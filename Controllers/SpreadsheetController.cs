using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpreadSheet.Models;
using System.Data.Entity;

namespace SpreadSheet.Controllers
{
    public class SpreadsheetController : ApiController
    {
        private SpreadSheetContext db = new SpreadSheetContext();

        public IHttpActionResult Get(int id)
        {
            return Ok(new
            {
                data = db.SheetDatas.Where(d => d.Sheet == id),
                sizes = db.SheetSizes.Where(d => d.Sheet == id),
                spans = db.SheetSpans.Where(d => d.Sheet == id),
                styles = db.SheetStyles.Where(d => d.Sheet == id)
            });
        }

        [HttpPost]
        [Route("api/spreadsheet/{id}/data")]
        public IHttpActionResult SaveData(int id, [FromBody] SheetData data)
        {
            data.Sheet = id;

            var oldData = db.SheetDatas.Find(data.Row, data.Column, data.Sheet);
            if (oldData != null)
            {
                oldData.Value = data.Value;
                oldData.Style = data.Style;
            } else
                db.SheetDatas.Add(data);

            db.SaveChanges();
            return Ok("ok");
        }

        [HttpPost]
        [Route("api/spreadsheet/{id}/styles")]
        public IHttpActionResult PostStyle(int id, [FromBody] SheetStyle data)
        {
            data.Sheet = id;

            var oldData = db.SheetStyles.Find(data.Name, data.Sheet);
            if (oldData != null)
                oldData.Text = data.Text;
            else
                db.SheetStyles.Add(data);

            db.SaveChanges();
            return Ok("ok");
        }

        [HttpPost]
        [Route("api/spreadsheet/{id}/sizes")]
        public IHttpActionResult PostSize(int id, [FromBody] SheetSize data)
        {
            data.Sheet = id;

            var oldData = db.SheetSizes.Find(data.Row, data.Column, id);
            if (oldData != null)
            {
                oldData.Size = data.Size;
            } else 
              db.SheetSizes.Add(data);

            db.SaveChanges();
            return Ok("ok");
        }

        [HttpPost]
        [Route("api/spreadsheet/{id}/spans")]
        public IHttpActionResult PostSpan(int id, [FromBody] SheetSpan data)
        {
            data.Sheet = id;

            var oldData = db.SheetSpans.Find(data.Row, data.Column, id);
            if (oldData != null)
            {
                oldData.Width = data.Width;
                oldData.Height = data.Height;
            } else
                db.SheetSpans.Add(data);

            db.SaveChanges();
            return Ok("ok");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
