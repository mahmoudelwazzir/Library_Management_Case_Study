namespace Library_Management_Case_Study.Repo.Interface
{
    public interface IGenaricRepo<T> where T : class
    {
        ICollection<T> GetAll();
        T GetById(int id);
        void AddItem(T item);
        void UpdateItem(T item);
        void DeleteItem(int id);
    }
}
