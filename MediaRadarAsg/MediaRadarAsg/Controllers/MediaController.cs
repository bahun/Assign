using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaRadarAsg.Controllers
{
    
    public class MediaController : Controller
    {
       /* [Route("GetAds")]
        public ActionResult Index()
        {
            MediaRadarAsg.Models.mediaAds md = new Models.mediaAds();
            List<Models.mediaAds> rptLst = md.getAds(1, DateTime.Now.AddDays(-5), DateTime.Now);
            if (rptLst.Count > 0)
                return View(rptLst);
            else
                return Json("No Record Found");
        }*/

        // GET: Home
        // [Route("GetAds/{id:Int?}/{dt:DateTime?}/{dt:DateTime?}")]
        public ActionResult Index(int? selType, DateTime? strtDate, DateTime? endDate)
        {
            int rptType;
            DateTime startDate;
            DateTime eDate;
            
                rptType = selType ?? default(int);
                startDate = strtDate??DateTime.Now.AddDays(-5);
                eDate = endDate??DateTime.Now;
            
            MediaRadarAsg.Models.mediaAds md = new Models.mediaAds();
            List<Models.mediaAds> rptLst = md.getAds(rptType, startDate, eDate);
            if (rptLst.Count > 0)
                return View(rptLst);
            else
                return Json("No Record Found");
        }
    }
}