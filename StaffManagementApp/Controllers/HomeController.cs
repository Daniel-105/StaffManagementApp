using Microsoft.AspNetCore.Mvc;
using StaffManagementApp.Data.Repository.IRepository;
using StaffManagementApp.Models;
using StaffManagementApp.ViewModel;
using System.Diagnostics;

namespace StaffManagementApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        // injecting this built in function of .net core.
        private readonly IWebHostEnvironment _webHostEnviroment;


        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _webHostEnviroment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Staff> staffList = _unitOfWork.Staff.GetAll();
            return View(staffList);
        }

        public IActionResult UpdateUser(int id)
        {
            // Retrieve the user from the database based on the id
            var user = _unitOfWork.Staff.Get(x => x.Id == id);

            if (user == null)
            {
                // Handle the case where the user with the specified id was not found
                return NotFound();
            }

            // Retrieve a list of team names directly using the Repository
            var teamNames = _unitOfWork.Teams.GetAll().Select(t => t.Name).ToList();


            // Create a ViewModel instance and populate it with the user and team names
            var viewModel = new UpdateUserVM
            {
                Staff = user,
                TeamNames = teamNames
            };

            // Pass the ViewModel to the view
            return View(viewModel);
        }

        [HttpPost] // Defining that this action is of the type POST
        public IActionResult UpdateUser(Staff staff, IFormFile? file)
        {
            // associating the path for the wwwroot (/) with the variable wwwRootPath
            string wwwRootPath = _webHostEnviroment.WebRootPath;
            if (file != null)
            {
                //Creating a new Guid and conserting it to a string 
                // Then concatnate that with the extention of the file (.jpeg, .pdf, etc...)
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string staffPath = Path.Combine(wwwRootPath, @"images\staff");

                // Check if there is an image loaded
                if (!string.IsNullOrEmpty(staff.ImageURL))
                {
                    //Delete the old image
                    var oldImagePath = Path.Combine(wwwRootPath, staff.ImageURL.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(staffPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                staff.ImageURL = @"\images\staff\" + fileName;
            }
            _unitOfWork.Staff.Update(staff);

            // Push the post to the database
            _unitOfWork.Save();
            TempData["success"] = "Category Updated Successfully";
            return RedirectToAction("Index");
            //return View(staff);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}