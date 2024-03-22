namespace MyRealState.Models.Repository
{
    public interface IRepository
    {
        public IEnumerable<Properties> GetProperties();
    }
}
