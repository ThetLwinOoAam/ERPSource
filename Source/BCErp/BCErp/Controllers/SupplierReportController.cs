using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCErp.DTO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BCErp.Controllers
{
    public class SupplierReportController : Controller
    {
        // GET: SupplierReport
        public ActionResult SupplierListing()
        {
            return View();
        }

        public ActionResult SupplierListingView(SupplierListingFilterDTO filter)
        {
            List<SupplierDTO> list = new List<SupplierDTO>();
            list.Add(new SupplierDTO() { Name = "mdsmsf", Email = "sdf@gmail.com", RegisterDate = DateTime.Now });
            list.Add(new SupplierDTO() { Name = "mdsmxdfdfsf", Email = "fgsdf@gmail.com", RegisterDate = DateTime.Now });

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public void SupplierListingViewExportPdf(SupplierListingFilterDTO filter)
        {
            List<SupplierDTO> list = new List<SupplierDTO>();
            list.Add(new SupplierDTO() { Name = "mdsmsf", Email = "sdf@gmail.com", RegisterDate = DateTime.Now });
            list.Add(new SupplierDTO() { Name = "mdsmxdfdfsf", Email = "fgsdf@gmail.com", RegisterDate = DateTime.Now });

            Rectangle pagesize = new Rectangle(20, 20, PageSize.A4.Width, PageSize.A4.Height);
            Document doc = new Document(pagesize, 10, 10, 30, 10);
            MemoryStream ms = new MemoryStream();
            PdfWriter pw = PdfWriter.GetInstance(doc, ms);
            doc.Open();

            Paragraph p = new Paragraph();
            p.Font.SetColor(0, 0, 0);
            p.Add("Supplier Listing");
            doc.Add(p);

            float[] widths = { 10, 20,20 };
            PdfPTable tbl = new PdfPTable(widths);

            Phrase ph1 = new Phrase("No", new Font(Font.FontFamily.TIMES_ROMAN, 10, Font.BOLD));
            PdfPCell c1 = new PdfPCell(ph1);
            c1.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.AddCell(c1);

            Phrase ph2 = new Phrase("Code", new Font(Font.FontFamily.TIMES_ROMAN, 10, Font.BOLD));
            PdfPCell c2 = new PdfPCell(ph2);
            c2.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.AddCell(c2);

            Phrase ph3 = new Phrase("Name", new Font(Font.FontFamily.TIMES_ROMAN, 10, Font.BOLD));
            PdfPCell c3 = new PdfPCell(ph3);
            c3.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.AddCell(c3);

            for (int i = 0; i < list.Count; i++)
            {
                Phrase phl1 = new Phrase((i+1).ToString(), new Font(Font.FontFamily.TIMES_ROMAN, 10, Font.BOLD));
                PdfPCell cl1 = new PdfPCell(phl1);
                cl1.HorizontalAlignment = Element.ALIGN_CENTER;
                tbl.AddCell(cl1);

                Phrase phl2 = new Phrase(list[i].Code, new Font(Font.FontFamily.TIMES_ROMAN, 10, Font.BOLD));
                PdfPCell cl2 = new PdfPCell(phl2);
                cl2.HorizontalAlignment = Element.ALIGN_CENTER;
                tbl.AddCell(cl2);

                Phrase phl3 = new Phrase(list[i].Name, new Font(Font.FontFamily.TIMES_ROMAN, 10, Font.BOLD));
                PdfPCell cl3 = new PdfPCell(phl1);
                cl3.HorizontalAlignment = Element.ALIGN_CENTER;
                tbl.AddCell(cl3);
            }
            doc.Add(tbl);

            doc.Close();
            byte[] byteArray = ms.ToArray();
            ms.Flush();
            ms.Close();
            ms.Dispose();

            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=SupplierListing.pdf");
            Response.AddHeader("Content-Length", byteArray.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.BinaryWrite(byteArray);







        }
    }
}