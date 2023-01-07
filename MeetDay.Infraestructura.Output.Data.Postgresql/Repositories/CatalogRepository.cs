using Dapper;
using MeetDay.Dominio.Core.Dtos.Catolog;
using MeetDay.Dominio.Core.Interfaces;
using MeetDay.Dominio.Core.Interfaces.Repositories;
using MeetDay.Infraestructura.Output.Data.Postgresql.Queries;
using Npgsql;

namespace MeetDay.Infraestructura.Output.Data.Postgresql.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly string _connectionString;
        public CatalogRepository(IGetConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString();
        }
        public async Task<List<OptionDto>> getAllCatalogDocument()
        {
            IEnumerable<OptionDto> options;
            string query = CatalogQueries.CatalogDocument;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                options = await connection.QueryAsync<OptionDto>(query);
            }
            return options.ToList();
        }
    }
}