using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            IEnumerable<Staff> staff = _unitOfWork.Staff.GetAll(includeProperties: "Team").ToList();
            return View(staff);
        }

        public IActionResult UpdateUser(int id)
        {
            // Retrieve the user from the database based on the id
            //var user = _unitOfWork.Staff.Get(x => x.Id == id);

            //if (user == null)
            //{
            //    // Handle the case where the user with the specified id was not found
            //    return NotFound();
            //}

            // Retrieve a list of team names directly using the Repository
            //var teamNames = _unitOfWork.Teams.GetAll().Select(t => t.Name).ToList();

            //// Create a ViewModel instance and populate it with the user, team names, and selected TeamId
            //var viewModel = new UpdateUserVM
            //{
            //    Staff = user,
            //    TeamNames = teamNames,
            //    SelectedTeamId = user.TeamId
            //};
            UpdateUserVM updateUserVM = new()
            {
                TeamsListList = _unitOfWork.Teams.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Staff = new Staff(),

            };
            updateUserVM.Staff = _unitOfWork.Staff.Get(x => x.Id == id);
            // Pass the ViewModel to the view
            return View(updateUserVM);
        }

        [HttpPost]
        public IActionResult UpdateUser(UpdateUserVM viewModel, IFormFile? file)
        {
            // associating the path for the wwwroot (/) with the variable wwwRootPath
            string wwwRootPath = _webHostEnviroment.WebRootPath;
            if (file != null)
            {
                // Creating a new Guid and converting it to a string
                // Then concatenate that with the extension of the file (.jpeg, .pdf, etc...)
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string staffPath = Path.Combine(wwwRootPath, @"images\staff");

                // Check if there is an image loaded
                if (!string.IsNullOrEmpty(viewModel.Staff.ImageURL))
                {
                    // Delete the old image
                    var oldImagePath = Path.Combine(wwwRootPath, viewModel.Staff.ImageURL.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(staffPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                viewModel.Staff.ImageURL = @"\images\staff\" + fileName;
            }

            // Update the Staff object's TeamId with the selected TeamId
            viewModel.Staff.TeamId = viewModel.SelectedTeamId;

            // Update the Staff object in the database
            _unitOfWork.Staff.Update(viewModel.Staff);

            // Push the post to the database
            _unitOfWork.Save();
            TempData["success"] = "Category Updated Successfully";
            return RedirectToAction("Index");
            //return View(viewModel.Staff);
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