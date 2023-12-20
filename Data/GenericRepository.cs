using Microsoft.EntityFrameworkCore;

namespace StudentmManagement.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DataContext _dataContext;
        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<T?> GetById(int id)
        {
            return await _dataContext.Set<T>().FindAsync(id);
        }

        public async Task<IList<T>> GetAll()
        {
            return await _dataContext.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _dataContext.Set<T>().AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dataContext.Set<T>().Update(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await GetById(id);
            _dataContext.Set<T>().Remove(result);
        }
    }
}
