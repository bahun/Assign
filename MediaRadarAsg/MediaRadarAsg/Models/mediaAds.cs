using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediaRadarAsg.MediaRadarAdService;

namespace MediaRadarAsg.Models
{
    public class mediaAds
    {
        public int AdID { get; set; }
        public mediaBrand brand { get; set; }
        public decimal NumPages { get; set; }
        public string Position { get; set; }


        public List<mediaAds> getAds(int Selection, DateTime strtDate, DateTime endDate)
        {
            List<mediaAds> mediaList = new List<mediaAds>();
            var mdList = new MediaRadarAdService.AdDataServiceClient().GetAdDataByDateRange(strtDate, endDate);
            foreach(var v in mdList)
            {
                mediaAds ad = new mediaAds();
                ad.AdID = v.AdId;
                ad.brand = new mediaBrand();
                ad.brand.BrandId = v.Brand.BrandId;
                ad.brand.BrandName = v.Brand.BrandName;
                ad.NumPages = v.NumPages;
                ad.Position = v.Position;
                mediaList.Add(ad);

            }
            if (Selection == 1)
            {
                return mediaList;
            }
            else if (Selection == 2)
            {
                mediaList.OrderBy(x => x.brand.BrandName).ToList();
                return mediaList;
            }
            else if (Selection == 3)
            {
                mediaList.OrderByDescending(p => p.NumPages).GroupBy(x => x.brand.BrandId).Select(grp => grp.First()).OrderBy(p=>p.brand.BrandName).Take(5);
                return mediaList;
            }
            else
            {
                mediaList.OrderByDescending(p => p.NumPages).ThenBy(x => x.brand.BrandName).Take(5);
                return mediaList;
            }
        }

    }


}