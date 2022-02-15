namespace Escola.Core.Data
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
