using AutoMapper;
using Library_Management_Case_Study.DTO.BookDTO;
using Library_Management_Case_Study.Models;
using Library_Management_Case_Study.Repo.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_Case_Study.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AddBook(CreateBookDTO bookdto)
        {
            if (bookdto == null)
                return NotFound();
            var book = _mapper.Map<Book>(bookdto);
            _unitOfWork.Books.AddItem(book);
            _unitOfWork.save();
            return Created();
        }
        [HttpGet("{Keyword}")]
        public IActionResult GetBook(string Keyword)
        {
            if(Keyword == null)
            {
                return Ok(_unitOfWork.Books.GetAll());
            }
            var book = _unitOfWork.Books.GetByTitle(Keyword);
            var bookdto = _mapper.Map<GetBookDTO>(book);
            return Ok(bookdto);
        }
        [HttpGet("highestPrice")]
        public IActionResult GethighestPrice()
        {
            var book = _unitOfWork.Books.highestPrice();
            var bookdto = _mapper.Map<GetBookDTO>(book);
            return Ok(bookdto);
        }

    }
}
