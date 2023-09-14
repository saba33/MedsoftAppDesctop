using MedSoftAppRepo.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedSoftAppRepo.Reposotory
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly DataContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                var result = _dbSet.Include("Gender").ToList();
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return Enumerable.Empty<T>();
            }
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);

            if (_dbContext.Entry(entity).State != EntityState.Added)
            {
                Console.WriteLine("Entity is not in Added state after AddAsync call.");
            }
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            _dbContext.SaveChanges();
        }
        //dbset contextshi unda ikos da aq marto context unda gamoidzaxo ai context aq maqvs 
        public void Update(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<T>> Search(string value)
        {
            var patients = new List<Patient>();
            int patientId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string patientName = value;
            patients = _dbContext.Patients.Where(p => p.ID == patientId || p.FullName.Contains(patientName))
                             .OrderByDescending(p => p.ID)
                             .ToList();
            return (IEnumerable<T>)patients;
        }
    }
}
