using Infrastructure.Repository;
using Core.Interfaces;

namespace Infrastructure.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly E2AppContext _context;
    private IRol _rols;
    private IUser _users;
    

    
    public UnitOfWork(E2AppContext context)
    {
        _context = context;
    }

    public IUser Users
    {
        get
        {
            _users ??= new UserRepository(_context);
            return _users;
        }
    }


   public IRol Rols
    {
        get
        {
            _rols ??= new RolRepository(_context);
            return _rols;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}