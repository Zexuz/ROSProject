using System.Web.Mvc;


namespace ROS.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            // The view being returned is calculated based on the name of the
            // controller (Home) and the name of the action method (Index).
            // So in this case, the view returned is /Views/Home/Index.cshtml.
            return View();
        }


    }
}