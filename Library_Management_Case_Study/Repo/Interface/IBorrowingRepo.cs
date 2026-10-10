using Library_Management_Case_Study.DTO.BorrowingDTO;
using Library_Management_Case_Study.Models;

namespace Library_Management_Case_Study.Repo.Interface
{
    public interface IBorrowingRepo
    {
        Borrowing CreateBorrowing(int bookId, int memberId);
        ICollection<GetBorrowDTO> GetAllBorrowing();
        bool ReturnBook(int borrowingid);
    }
}
