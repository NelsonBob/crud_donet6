using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SearchCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly SchoolsApiContext _context;

        public CoursesController(SchoolsApiContext context)
        {
            _context = context;
        }
        [HttpGet("/list/courses")]
        public async Task<ActionResult<List<Course>>> Get()
        {
            return Ok(await _context.Courses.ToListAsync());
        }

        [HttpGet("/list/course/{id}")]
        public async Task<ActionResult<Course>> Get (int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
                return BadRequest("course not found");
            return Ok(course);
        }
        [HttpPost]
        public async Task<ActionResult<List<Course>>> AddCourse(Course course)
        {
            _context.Courses.Add(course);
             
            await _context.SaveChangesAsync();

            return Ok(await _context.Courses.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Course>>> UpdateCourse(Course request)
        {
            var course = await _context.Courses.FindAsync(request.Id);

            if (course == null)
                return BadRequest("course not found");
            course.Name = request.Name;
            course.Semestre = request.Semestre;

            await _context.SaveChangesAsync();

            return Ok(await _context.Courses.ToListAsync());

            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Course>>> Delete(int id)
        {
            var dbcourse = await _context.Courses.FindAsync(id);

            if (dbcourse == null)
                return BadRequest("course not found");

            _context.Courses.Remove(dbcourse);
            await  _context.SaveChangesAsync();
            return Ok(await _context.Courses.ToListAsync());
        }
    }
}
