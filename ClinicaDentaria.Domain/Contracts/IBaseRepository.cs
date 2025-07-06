namespace ClinicaDentaria.Domain.Contracts
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task Adicionar(TEntity entity);
        Task Atualizar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<IEnumerable<TEntity>> ObterTodos();
        Task Remover(TEntity entity);
    }
}