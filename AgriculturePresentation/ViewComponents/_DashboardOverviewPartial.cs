using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardOverviewPartial : ViewComponent
    {
        AgricultureContext c = new AgricultureContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.teamCount = c.Teams.Count();
            ViewBag.serviceCount = c.Services.Count();
            ViewBag.messageCount = c.Contacts.Count();
            ViewBag.currentMonthMessage = 3;

            ViewBag.announcementTrue = c.Announcements.Where(x => x.Status == true).Count();
            ViewBag.announcementFalse = c.Announcements.Where(x => x.Status == false).Count();

            ViewBag.productMarketing = c.Teams.Where(x => x.Title == "Product Marketing").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.pulsesManagement = c.Teams.Where(x => x.Title == "Pulses Management").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.milkProducer = c.Teams.Where(x => x.Title == "Milk Producer").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.fertilizerManagement = c.Teams.Where(x => x.Title == "Fertilizer Management").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.projectManager = c.Teams.Where(x => x.Title == "Project Manager").Select(y => y.PersonName).FirstOrDefault();
            return View();
        }
    }
}
