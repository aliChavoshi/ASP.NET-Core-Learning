using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aspLearning.Entities;
using aspLearning.Interfaces;
using aspLearning.Attributes;
using aspLearning.Context;
using aspLearning.Extensions;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using aspLearning.Binders;
using aspLearning.Filters;

namespace aspLearning.Controllers;

[TypeFilter(typeof(CourseIndexActionFilter), Arguments = ["order", "controller", 2])]
public class CoursesController(IUnitOfWork uow, IDistributedCache cache, ICourseRepository courseRepository)
    : Controller
{
    public const string CacheName = "Courses";

    [TypeFilter(typeof(CourseIndexActionFilter), Arguments = ["order", "action", 1])]
    //[TypeFilter(typeof(HandleExceptionFilter))]
    [FilterClassName]         //simple
    [ServiceFilter(typeof(MyServiceFilter))]
    public async Task<IActionResult> Index(string filter)
    {
        //throw new Exception("this is test");
        // ViewData["filter"] = filter;
        var result = await courseRepository.GetAllAsyncCourses(filter);
        return View(result);
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
    public IActionResult Create(
        [Bind(nameof(Course.AuthorId), nameof(Course.Level), nameof(Course.Title))]
        Course course)
    {
        if (uow.Rep<Course>().Any(x => x.Title == course.Title.Trim()))
        {
            var authors = uow.Rep<Author>().GetAll();
            ViewData["AuthorId"] = new SelectList(authors, "Id", "Name");
            ModelState.AddModelError("Title", "title is used by another user");
            return View(course);
        }

        // if (!ModelState.IsValid)
        // {
        //     //Please insert value
        //     //min length is 10
        //     var errors = string.Join("\n", ModelState.Values.SelectMany(v => v.Errors).Select(err => err.ErrorMessage));
        //     return BadRequest(errors);
        // }

        uow.Rep<Course>().Add(course);
        uow.Complete();
        cache.Remove(CacheName);
        return new RedirectToActionResult("Index", "Courses", new { name = "Ali" });
        // return new LocalRedirectResult($"Courses/Index/");
        // return LocalRedirect("Index");
        // return RedirectToAction("Index", new { name = "Ali" });
        // return Redirect("");
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
    public IActionResult Edit(Course course, int id)
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