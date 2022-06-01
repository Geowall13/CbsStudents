#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CbsStudents.Models.Entities;
using CbsStudents.Data;

namespace CbsStudents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostApiController : ControllerBase
    {
        private readonly CbsStudentsContext _context;

        public PostApiController(CbsStudentsContext context)
        {
            _context = context;
        }

        // GET: api/PostApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetPost()
        {
            return await _context.Post
                .Select(x => PostDTO(x))
                .ToListAsync();
        }

        // GET: api/PostApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDTO>> GetPost(int id)
        {
            var post = await _context.Post.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return PostDTO(post);
        }

        // PUT: api/PostApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, PostDTO postDTO)
        {
            if (id != postDTO.PostId)
            {
                return BadRequest();
            }

            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            post.Title = postDTO.Title;
            post.Text = postDTO.Text;
            post.Status = postDTO.Status;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PostApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostDTO>> PostPost(PostDTO postDTO)
        {
            var post = new Post{
                Title = postDTO.Title,
                Text = postDTO.Text,
                Created = DateTime.Now,
                Status = postDTO.Status,
                UserId = postDTO.UserId //Obviously we need some identityuser stuff here
            };

            _context.Post.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.PostId }, PostDTO(post));
        }

        // DELETE: api/PostApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Post.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostExists(int id)
        {
            return _context.Post.Any(e => e.PostId == id);
        }

        private static PostDTO PostDTO(Post post){
            return new PostDTO{
                PostId = post.PostId,
                Title = post.Title,
                Text = post.Text,
                Created = post.Created,
                Status = post.Status,
                UserId = post.UserId
            };
        }
    }
}
