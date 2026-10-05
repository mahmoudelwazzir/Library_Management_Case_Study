using AutoMapper;
using Library_Management_Case_Study.DTO.MemberDTO;
using Library_Management_Case_Study.Models;
using Library_Management_Case_Study.Repo.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_Case_Study.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MemberController(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreateMember(CreateMemberDTO memberDTO)
        {
            if (memberDTO == null)
            {
                return BadRequest();
            }
            var membersdto = _mapper.Map<Member>(memberDTO);
            _unitOfWork.Members.AddItem(membersdto);
            _unitOfWork.save();
            return Created();
        }
    }
}
