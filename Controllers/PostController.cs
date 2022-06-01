using Microsoft.AspNetCore.Mvc;
using CbsStudents.Models.Entities;
using CbsStudents.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace CbsStudents.Controllers;

[Authorize]
public class PostController : Controller
{

    private CbsStudentsContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public PostController(CbsStudentsContext context, UserManager<IdentityUser> userManager){
        _context = context;
        _userManager = userManager;
    }

    [AllowAnonymous]
    public IActionResult Index(string SearchString = ""){
        
        if (SearchString == null)
        {
            SearchString = "";
        }
        var posts = from p in _context.Post select p;

        posts = posts.Where(x => x.Title.Contains(SearchString) ||
            x.Text.Contains(SearchString)).Include(y => y.User);

        var vm = new PostIndexVm
        {
            Posts = posts.ToList(),
            SearchString = SearchString
        };

        return View(vm);
    }

    [AllowAnonymous]
    public IActionResult Details(int? id){

        if (id == null){
            return NotFound();
        }

        var post = _context.Post.Include(x => x.Comments).ThenInclude(x => x.User).First(x => x.PostId == id);
        if (post == null){
            return NotFound();
        }
        return View(post);

    }

    public IActionResult Create(){
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("Title","Text","Status")]Post post){
        
        if(ModelState.IsValid){
            IdentityUser user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            post.UserId = user.Id;
            post.Created = DateTime.Now;
            _context.Post.Add(post);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(post);
    }


    public async Task<IActionResult> Edit(int? id){
        if (id == null){
            return NotFound();
        }

        var post = _context.Post.Include(x => x.Comments).ThenInclude(x => x.User).First(x => x.PostId == id);
        if (post == null){
            return NotFound();
        }
        return View(post);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("PostId,Title,Text,Status,Created")] Post post){
        
        if (id != post.PostId){
            return NotFound();
        }

        if (ModelState.IsValid){
            IdentityUser user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            post.UserId = user.Id;
            _context.Update(post);
            await _context.SaveChangesAsync();            
            return RedirectToAction(nameof(Index));
        }
        return View(post);
    }

// GET: Comment/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var post = await _context.Post
            .Include(p => p.User)
            .FirstOrDefaultAsync(x => x.PostId == id);
        if (post == null)
        {
            return NotFound();
        }

        return View(post);
    }

    // POST: Comment/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var post = await _context.Post.FindAsync(id);
        _context.Post.Remove(post);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}