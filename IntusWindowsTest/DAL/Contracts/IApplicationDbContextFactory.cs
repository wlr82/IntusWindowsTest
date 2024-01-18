namespace DAL.Contracts
{
    public interface IApplicationDbContextFactory
    {
        ApplicationDBContext Create();
    }
}
