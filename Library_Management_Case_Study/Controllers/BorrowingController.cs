using AutoMapper;
using Library_Management_Case_Study.DTO.BookDTO;
using Library_Management_Case_Study.DTO.BorrowingDTO;
using Library_Management_Case_Study.Repo.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_Case_Study.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        public BorrowingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitofwork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreateBorrow(CreateBorrowingDTO dto)
        {
            var member = _unitofwork.MemberRepo.GetById(dto.MemberId);
            if(member == null) { return NotFound($"Member With Id {dto.MemberId} Not Found"); }
            var book = _unitofwork.Books.GetById(dto.BookId);
            if(book == null) { return NotFound($"Book With Id {dto.BookId} Not Found"); }
            if (!book.IsAvailable) { return BadRequest("The selected book is unavaible"); }
            book.IsAvailable = false;
            _unitofwork.Books.UpdateItem(book);
            var borrow = _unitofwork.Borrowings.CreateBorrowing(dto.BookId, dto.MemberId);
            _unitofwork.save();
            return Ok(new
            {
                borrowing = borrow.Id,
                booktitle = book.Title,
                membername = member.FullName,
            });
        }
        [HttpGet]
        public IActionResult GetAllBorrowing()
        {
            var borrowing = _unitofwork.Borrowings.GetAllBorrowing();
            return Ok(borrowing);
        }
        [HttpPut("{id}/return")]
        public IActionResult ReturnBorrowingDto(int id)
        {
            var borrowing = _unitofwork.Borrowings.ReturnBook(id);
            if (!borrowing) { return BadRequest(); }
            _unitofwork.save();
            return Ok();
        }
    }
}