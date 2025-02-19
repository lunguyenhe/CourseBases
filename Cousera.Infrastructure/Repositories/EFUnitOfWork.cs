using Cousera.Domain.Abstraction;
using Cousera.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cousera.Infrastructure.Repositories;

public class EFUnitOfWork : IUnitOfWork
{
    private readonly ApplicationDBContext _context;
    public DbContext GetDbContext()
 => _context;
    public EFUnitOfWork(ApplicationDBContext context)
    {
        _context = context;
    }



    async ValueTask IAsyncDisposable.DisposeAsync()
=> await _context.DisposeAsync();
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
 => await _context.SaveChangesAsync();


}

