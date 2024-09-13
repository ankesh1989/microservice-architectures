using BCommerce.KeyCloak.API.Infrastructure.Context;
using BCommerce.KeyCloak.API.Infrastructure.Entities;
using System.Linq.Expressions;

namespace BCommerce.KeyCloak.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;
        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Clients entity)
        {
            try
            {
                _context.Clients.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Clients entity)
        {
            _context.Clients.Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<Clients> FindAll()
        {
            return _context.Clients.AsQueryable();
        }

        public IQueryable<Clients> FindByCondition(Expression<Func<Clients, bool>> expression)
        {
            return _context.Clients.Where(expression).AsQueryable();
        }

        public void Update(Clients entity)
        {
            _context.Clients.Update(entity);
            _context.SaveChanges();
        }
    }
}
