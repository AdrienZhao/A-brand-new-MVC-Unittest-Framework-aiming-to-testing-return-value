using EmitMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ResultModel About(bool IsInShortFormat)
        {
            object aboutInfo = null;

            var path = Utility.GetVirtualPathByRelativePath(".\\");

            if (IsInShortFormat)
            {
                var fullFormatAbout = AboutUsBusinessLogic.GetFullModelInfo();
                aboutInfo = ObjectMapperManager.DefaultInstance.GetMapper<FullAboutModel, CompleteAboutInfoDto>().Map(fullFormatAbout);
            }
            else
            {
                var shortFormatAbout = AboutUsBusinessLogic.GetShortModelInfo();
                aboutInfo = ObjectMapperManager.DefaultInstance.GetMapper<ShortAboutModel, ShortFormatAboutInfoDto>().Map(shortFormatAbout);
            }

            return aboutInfo != null ? ResultModel.GetSuccessInstance(aboutInfo)
                : ResultModel.GetFailedInstance();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    public class ResultModel
    {
        public object Data { get; set; }
        public bool success { get; set; }

        public static ResultModel GetSuccessInstance(object data)
        {
            return new ResultModel()
            {
                success = true,
                Data = data
            };
        }

        public static ResultModel GetFailedInstance()
        {
            return new ResultModel()
            {
                success = false,
            };
        }
    }
}