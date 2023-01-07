using Dapper;
using MeetDay.Dominio.Core.Dtos.Catolog;
using MeetDay.Dominio.Core.Dtos.Management;
using MeetDay.Dominio.Core.Entity;
using MeetDay.Dominio.Core.Interfaces;
using MeetDay.Dominio.Core.Interfaces.Repositories;
using MeetDay.Infraestructura.Output.Data.Postgresql.Contexts;
using MeetDay.Infraestructura.Output.Data.Postgresql.Queries;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace MeetDay.Infraestructura.Output.Data.Postgresql.Repositories
{
    public class ManagementRepository : IManagementRepository<Management, int>
    {
        private readonly MeetDayContext _db;
        private readonly string _connectionString;
        public ManagementRepository(MeetDayContext context, IGetConfiguration configuration)
        {
            _db = context;
            _connectionString = configuration.GetConnectionString();
        }
        public async Task<Management> AddAsync(Management entity)
        {
            await _db.Managements.AddAsync(entity);
            _db.SaveChanges();
            return entity;
        }

        public void Delete(Management entity)
        {
            _db.Managements.Remove(entity);
            _db.SaveChanges();
        }

        public int Edit(Management entity)
        {
            _db.Managements.Update(entity);
            return _db.SaveChanges();
        }

        public List<Management> FindAll()
        {
            return _db.Managements.ToList();
        }

        public async Task<Management> FindById(int id)
        {
            var management = _db.Managements.Find(id);
            IEnumerable<OptionDto> documentos;
            string query = ManagementQueries.DocumentsManagement;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var queryInput = new
                {
                    managementId = id
                };
                documentos = await connection.QueryAsync<OptionDto>(query, queryInput);
            }
            management.Documents = documentos.ToList();
            return management;
        }
    }
}