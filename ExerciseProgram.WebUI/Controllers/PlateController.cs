using ExerciseProgram.Domain.Concrete;
using ExerciseProgram.Domain.DAL;
using System.Web.Mvc;

namespace ExerciseProgram.WebUI.Controllers
{
    public class PlateController : Controller
    {
        // GET: Plate
        public ActionResult Index(int? id)
        {
            var plate = new Plate();

            return View(plate);
        }
    }
}