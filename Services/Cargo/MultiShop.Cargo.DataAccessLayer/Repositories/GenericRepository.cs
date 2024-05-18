using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrate;

namespace MultiShop.Cargo.DataAccessLayer.Repositories;

public class GenericRepository<T>(CargoContext context) : IGenericDal<T> where T : class
{
    private readonly CargoContext _context = context;
    
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var values = _context.Set<T>().Find(id);
        _context.Set<T>().Remove(values);
        _context.SaveChanges();
    }

    public T? GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public List<T> GetAll()
    {
        var values = _context.Set<T>().ToList();
        return values;
    }
}