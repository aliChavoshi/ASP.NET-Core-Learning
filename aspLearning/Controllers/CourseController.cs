using aspLearning.Entities;
using aspLearning.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace aspLearning.Controllers;

public class CourseController(IUnitOfWork uow) : Controller
{
    //CRUD
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Course course)
    {
        //Add New Course
        //Add in to the DB
        return View();
    }
}