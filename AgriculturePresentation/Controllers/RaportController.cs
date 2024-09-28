using AgriculturePresentation.Models;
using ClosedXML.Excel;
using DataAccessLayer.Abstract;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AgriculturePresentation.Controllers
{
    public class RaportController : Controller
    {
        private readonly IProductDal _productDal;

        public RaportController(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<ProductModel> productModels()
        {
            List<ProductModel> models = new List<ProductModel>();
            using (var context = new AgricultureContext())
            {
                models = context.Products.Select(x => new ProductModel
                {
                    ProductIdm = x.ProductId,
                    ProductName = x.Name,
                    ProductValue = x.Value
                }).ToList();
            }
            return models;
        }

        public IActionResult ProductRaport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Product List");
                workSheet.Cell(1, 1).Value = "Product Id";
                workSheet.Cell(1, 2).Value = "Product Name";
                workSheet.Cell(1, 3).Value = "Product Value";

                int contactRowCount = 2;
                foreach (var contact in productModels())
                {
                    workSheet.Cell(contactRowCount, 1).Value = contact.ProductIdm;
                    workSheet.Cell(contactRowCount, 2).Value = contact.ProductName;
                    workSheet.Cell(contactRowCount, 3).Value = contact.ProductValue;
                    contactRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray(); 
                    Guid id = Guid.NewGuid();
                    string fileName = id.ToString() + ".xlsx";
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                }
            }
        }

        public List<ContactModel> contactModels()
        {
            List<ContactModel> models = new List<ContactModel>();
            using (var context = new AgricultureContext())
            {
                models = context.Contacts.Select(x => new ContactModel
                {
                    ContactId = x.ContactId,
                    ContactName = x.Name,
                    ContactMail = x.Mail,
                    ContactMessage = x.Message,
                    ContactDate = x.Date
                }).ToList();
            }
            return models;
        }

        public IActionResult MessageRaport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Message List");
                workSheet.Cell(1, 1).Value = "Message Id";
                workSheet.Cell(1, 2).Value = "Message Sender";
                workSheet.Cell(1, 3).Value = "Mail Address";
                workSheet.Cell(1, 4).Value = "Message Content";
                workSheet.Cell(1, 5).Value = "Message Date";

                int contactRowCount = 2;
                foreach (var contact in contactModels())
                {
                    workSheet.Cell(contactRowCount, 1).Value = contact.ContactId;
                    workSheet.Cell(contactRowCount, 2).Value = contact.ContactName;
                    workSheet.Cell(contactRowCount, 3).Value = contact.ContactMail;
                    workSheet.Cell(contactRowCount, 4).Value = contact.ContactMessage;
                    workSheet.Cell(contactRowCount, 5).Value = contact.ContactDate;
                    contactRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    Guid id = Guid.NewGuid();
                    string fileName = id.ToString() + ".xlsx";
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                }
            }
        }

        public List<AnnouncementModel> announcemenModels()
        {
            List<AnnouncementModel> models = new List<AnnouncementModel>();
            using (var context = new AgricultureContext())
            {
                models = context.Announcements.Select(x => new AnnouncementModel
                {
                    AnnouncementIdm = x.AnnouncementId,
                    AnnouncementTitle = x.Title,
                    AnnouncementContent = x.Description,
                    AnnouncementDate = x.Date,
                    AnnouncementStatus = x.Status,
                    AnnouncementImage = x.Image
                }).ToList();
            }
            return models;
        }

        public IActionResult AnnouncementRaport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Announcement List");
                workSheet.Cell(1, 1).Value = "Announcement Id";
                workSheet.Cell(1, 2).Value = "Announcement Title";
                workSheet.Cell(1, 3).Value = "Announcement Content";
                workSheet.Cell(1, 4).Value = "Announcement Date";
                workSheet.Cell(1, 5).Value = "Announcement Status";
                workSheet.Cell(1, 6).Value = "Announcement Image";

                int contactRowCount = 2;
                foreach (var contact in announcemenModels())
                {
                    workSheet.Cell(contactRowCount, 1).Value = contact.AnnouncementIdm;
                    workSheet.Cell(contactRowCount, 2).Value = contact.AnnouncementTitle;
                    workSheet.Cell(contactRowCount, 3).Value = contact.AnnouncementContent;
                    workSheet.Cell(contactRowCount, 4).Value = contact.AnnouncementDate;
                    workSheet.Cell(contactRowCount, 5).Value = contact.AnnouncementStatus;
                    workSheet.Cell(contactRowCount, 6).Value = contact.AnnouncementImage;
                    contactRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    Guid id = Guid.NewGuid();
                    string fileName = id.ToString() + ".xlsx";
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                }
            }
        }

        //public IActionResult ProductRaport()
        //{
        //    ExcelPackage package = new ExcelPackage();
        //    var workBook = package.Workbook.Worksheets.Add("File1");

        //    workBook.Cells[1,1].Value = "Product Name";
        //    workBook.Cells[1,2].Value = "Product Stock";

        //    workBook.Cells[2, 1].Value = "Wheat";
        //    workBook.Cells[2, 2].Value = "5643 Kg";

        //    workBook.Cells[3, 1].Value = "Lentil";
        //    workBook.Cells[3, 2].Value = "9123 Kg";

        //    workBook.Cells[4, 1].Value = "Barley";
        //    workBook.Cells[4, 2].Value = "2308 Kg";

        //    workBook.Cells[5, 1].Value = "Rice";
        //    workBook.Cells[5, 2].Value = "7887 Kg";

        //    workBook.Cells[6, 1].Value = "Tomatoes";
        //    workBook.Cells[6, 2].Value = "8587 Kg";

        //    workBook.Cells[7, 1].Value = "Apple";
        //    workBook.Cells[7, 2].Value = "1342 Kg";

        //    var bytes = package.GetAsByteArray();

        //    return File(bytes,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","ProductRaport.xlsx");
        //}
    }
}
