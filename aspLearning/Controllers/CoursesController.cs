using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aspLearning.Entities;
using aspLearning.Interfaces;
using aspLearning.Attributes;
using aspLearning.Context;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Caching.Memory;

namespace aspLearning.Controllers;

public class CoursesController(IUnitOfWork uow, IMemoryCache memoryCache) : Controller
{
    // GET: Courses
    // [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client, VaryByHeader = "User-Agent",
    //     VaryByQueryKeys = new[] { "id", "name" })]
    [OutputCache(Duration = 60, PolicyName = "", VaryByQueryKeys = new[] { "productId" })]   //web api
    public IActionResult Index()
    {
        if (memoryCache.TryGetValue("Course", out List<Course>? result))
        {
            return View(result);
        }

        var courses = uow.Context.Set<Course>()
            .Include(x => x.Author)
            .ToList();
        memoryCache.Set("Course", courses, TimeSpan.FromHours(1));
        return View(courses);
    }

    // GET: Courses/Details/5
    // [MyException]
    public IActionResult Details(int? id)
    {
        // var num = int.Parse(id.ToString());
        if (id == null) return NotFound();

        var course = uow.Context.Set<Course>()
            .Include(x => x.Author)
            .FirstOrDefault(x => x.Id == id);
        if (course == null) return NotFound();

        return View(course);
    }

    // GET: Courses/Create
    [HttpGet]
    public IActionResult Create()
    {
        var authors = uow.Rep<Author>().GetAll();
        ViewData["AuthorId"] = new SelectList(authors, "Id", "Name");
        return View();
    }

    [HttpPost]
    public IActionResult Create(Course course)
    {
        //if (!ModelState.IsValid) return View(course);
        //validation
        if (uow.Rep<Course>().Any(x => x.Title == course.Title.Trim()))
        {
            var authors = uow.Rep<Author>().GetAll();
            ViewData["AuthorId"] = new SelectList(authors, "Id", "Name");
            ModelState.AddModelError(nameof(course.Title), "title is used by another user");
            return View(course);
        }

        uow.Rep<Course>().Add(course);
        uow.Complete();
        memoryCache.Remove("Course");
        return RedirectToAction(nameof(Index));
    }

    // GET: Courses/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null) return NotFound();

        var course = uow.Rep<Course>().GetById(id.Value);
        if (course == null) return NotFound();

        //4,5,6,7,8
        //5 => selected
        ViewData["AuthorId"] = new SelectList(uow.Rep<Author>().GetAll(), "Id", "Name", course.AuthorId);
        return View(course);
    }

    [HttpPost]
    public IActionResult Edit(int id, Course course)
    {
        if (id != course.Id) return NotFound();

        var entity = uow.Rep<Course>().GetById(course.Id);
        if (entity.Title != course.Title)
            if (uow.Rep<Course>().Any(x => x.Title == course.Title.Trim()))
            {
                ViewData["AuthorId"] = new SelectList(uow.Rep<Author>().GetAll(),
                    "Id", "Name", course.AuthorId);
                ModelState.AddModelError("Title", "title is used by another user");
                return View(course);
            }

        uow.Rep<Course>().Update(course);
        uow.Complete();
        return RedirectToAction("Index");
    }

    // GET: Courses/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null) return NotFound();

        var course = uow.Context.Set<Course>()
            .Include(x => x.Author)
            .FirstOrDefault(x => x.Id == id);

        if (course == null) return NotFound();

        return View(course);
    }

    // POST: Courses/Delete/5
    [HttpPost]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var course = uow.Rep<Course>().GetById(id);
        if (course == null) return RedirectToAction(nameof(Index));

        uow.Rep<Course>().Delete(course);
        uow.Complete();

        return RedirectToAction(nameof(Index));
    }
}