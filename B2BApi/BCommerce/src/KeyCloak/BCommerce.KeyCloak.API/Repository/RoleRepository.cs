using BCommerce.KeyCloak.API.Infrastructure.Context;
using BCommerce.KeyCloak.API.Infrastructure.Entities;
using System.Linq.Expressions;

namespace BCommerce.KeyCloak.API.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;
        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Roles entity)
        {
            try
            {
                _context.Roles.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Roles entity)
        {
            _context.Roles.Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<Roles> FindAll()
        {
            return _context.Roles.AsQueryable();
        }

        public IQueryable<Roles> FindByCondition(Expression<Func<Roles, bool>> expression)
        {
            return _context.Roles.Where(expression);
        }

        public void Update(Roles entity)
        {
            try
                {
                _context.Roles.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
