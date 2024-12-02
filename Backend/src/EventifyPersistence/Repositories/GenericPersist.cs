using System.Threading.Tasks;
using EventifyPersistence.Contexts;
using EventifyPersistence.Contracts;

namespace EventifyPersistence
{
    public class GenericPersist : IGenericPersist
    {
        private readonly EventifyContext _context;

        public GenericPersist(EventifyContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
