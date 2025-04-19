using Cumulative01.Models;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;

// Controller responsible for handling requests related to the Teacher page.
namespace Cumulative01.Controllers
{
    // Defines the route used to access this controller.
    public class TeacherPageController : Controller
    {

        // Private field to store the reference to the Teacher API controller.
        private readonly TeacherAPIController _api;


        //Constructor to initialize the API controller reference.
        public TeacherPageController(TeacherAPIController api)
        {
            _api = api;
        }

        // Handles requests to display a list of all teachers.
        public IActionResult List()
        {

            // Retrieves the list of teachers using the API.
            List<Teacher> Teach = _api.RetrieveTeacherList();
            // Returns the view displaying the teacher list.
            return View(Teach);
        }

        // Handles requests to show details of a specific teacher based on their ID.
        public IActionResult Show(int Id)
        {
            // Fetches teacher details from the API using the provided ID.
            Teacher teach1 = _api.SearchTeacher(Id);
            // Returns the view displaying the selected teacher’s details.
            return View(teach1);
        }

        // GET: TeacherPage/New
        // Shows the form to add a new teacher
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        // POST: TeacherPage/Create
        // Receives form data and adds a new teacher via API
        [HttpPost]
        public IActionResult Create(Teacher newTeacher)
        {
            int teacherId = _api.AddTeacher(newTeacher);
            return RedirectToAction("Show", new { id = teacherId });
        }

        // GET: TeacherPage/DeleteConfirm/{id}
        // Shows confirmation page before deleting a teacher
        [HttpGet]
        public IActionResult DeleteConfirm(int id)
        {
            var selectedTeacher = _api.SearchTeacher(id);
            return View(selectedTeacher);
        }

        // POST: TeacherPage/Delete/{id}
        // Deletes the teacher and redirects to the list
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _api.DeleteTeacher(id);
            return RedirectToAction("List");
        }
    }
}




