using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace ClinicaDentaria.Infra.Sql
{
    public static class Dapper<TEntity>
    {
        public static async Task<TEntity?> ObterPorId(IConfiguration config, ILogger logger, Guid id)
        {
            using (var db = new SqlConnection(config.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    logger.LogInformation("Conectando ao banco de dados");

                    await db.OpenAsync();
                    return await db.QueryFirstOrDefaultAsync<TEntity>(Query(), new Params() { Filter = $" WHERE Id = '{id}'" });
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                    return default;
                }
            }
        }

        public static async Task<IEnumerable<TEntity>?> ObterTodos(IConfiguration config, ILogger logger)
        {
            using (var db = new SqlConnection(config.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    logger.LogInformation("Conectando ao banco de dados");

                    await db.OpenAsync();
                    return await db.QueryAsync<TEntity>(Query(), new Params() { Filter = "" });
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                    return default;
                }
            }
        }

        private static string Query()
        {
            switch (nameof(TEntity))
            {
                case "Paciente":
                    return "SELECT * FROM Paciente @filter";
                case "Contato":
                    return "SELECT * FROM Contato @filter";
                case "Dentista":
                    return "SELECT * FROM Dentista @filter";
                case "Endereco":
                    return "SELECT * FROM Endereco @filter";
                case "Sala":
                    return "SELECT * FROM Sala @filter";
                case "Agenda":
                    return "SELECT * FROM Agenda @filter";
                default:
                    return "SELECT 1";
            }
        }
    }
}
