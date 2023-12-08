namespace DailyNeeds1.Repo
{
    public interface IRepo<T>
    {
        List<T> GetAll();
        bool Add(T item);
        bool Delete(int Id);
        bool Update(T item);
    }
}
