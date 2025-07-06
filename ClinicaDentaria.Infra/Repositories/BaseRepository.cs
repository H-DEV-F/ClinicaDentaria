using ClinicaDentaria.Infra.Sql;
using Microsoft.Extensions.Logging;
using ClinicaDentaria.Infra.Context;
using ClinicaDentaria.Domain.Contracts;
using Microsoft.Extensions.Configuration;

namespace ClinicaDentaria.Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly IConfiguration _config;
        protected readonly ILogger<BaseRepository<TEntity>> _logger;
        protected readonly ClinicaDentariaDbContext AdmCondominioContexto;

        public BaseRepository(ClinicaDentariaDbContext circlesPratasContexto, IConfiguration config, ILogger<BaseRepository<TEntity>> logger)
        {
            _config = config;
            _logger = logger;
            AdmCondominioContexto = circlesPratasContexto;
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            AdmCondominioContexto.Set<TEntity>().Add(entity);
            await AdmCondominioContexto.SaveChangesAsync();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            AdmCondominioContexto.Set<TEntity>().Update(entity);
            await AdmCondominioContexto.SaveChangesAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await Dapper<TEntity>.ObterPorId(_config, _logger, id);
            //return await AdmCondominioContexto.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await Dapper<TEntity>.ObterTodos(_config, _logger);
            //return await Task.FromResult(AdmCondominioContexto.Set<TEntity>().ToList());
        }

        public virtual async Task Remover(TEntity entity)
        {
            AdmCondominioContexto.Remove(entity);
            await AdmCondominioContexto.SaveChangesAsync();
        }

        public void Dispose()
        {
            AdmCondominioContexto.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
