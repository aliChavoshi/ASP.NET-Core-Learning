using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aspLearning.Context;
using aspLearning.Entities;
using aspLearning.Interfaces;

namespace aspLearning.Controllers;

public class CoursesController(IUnitOfWork uow, MyContext context) : Controller
{
    // GET: Courses
    public IActionResult Index()
    {
        var courses = uow.Context.Set<Course>()
            .Include(x => x.Author)
            .ToList();
        return View(courses);
    }

    // GET: Courses/Details/5
    public IActionResult Details(int? id)
    {
        if (id == null) return NotFound(); //404

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
        return RedirectToAction(nameof(Index));
    }

    // GET: Courses/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var course = await context.Courses.FindAsync(id);
        if (course == null)
        {
            return NotFound();
        }

        ViewData["AuthorId"] = new SelectList(context.Author, "Id", "Id", course.AuthorId);
        return View(course);
    }

    // POST: Courses/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,AuthorId,Level,FullPrice")] Course course)
    {
        if (id != course.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                context.Update(course);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(course.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        ViewData["AuthorId"] = new SelectList(context.Author, "Id", "Id", course.AuthorId);
        return View(course);
    }

    // GET: Courses/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var course = await context.Courses
            .Include(c => c.Author)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (course == null)
        {
            return NotFound();
        }

        return View(course);
    }

    // POST: Courses/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var course = await context.Courses.FindAsync(id);
        if (course != null)
        {
            context.Courses.Remove(course);
        }

        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CourseExists(int id)
    {
        return context.Courses.Any(e => e.Id == id);
    }
}