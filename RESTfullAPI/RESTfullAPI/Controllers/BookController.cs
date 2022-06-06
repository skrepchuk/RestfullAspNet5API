using Microsoft.AspNetCore.Mvc;
using RESTfullAPI.Model;
using RESTfullAPI.Business;

namespace RESTfullAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private IBookBusiness _bookBusiness;
        public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness)
        {
            _logger = logger;
            _bookBusiness = bookBusiness;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return  Ok(await _bookBusiness.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var book = await _bookBusiness.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            return Ok(await _bookBusiness.Create(book));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            var updatedBook = await _bookBusiness.Update(book);
            return Ok(updatedBook != null ? updatedBook : NotFound());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}
