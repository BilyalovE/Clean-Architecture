using System;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Interfaces.DataAccess;

public interface IDbContext
{
    DbSet<Order> Orders { get; }
    DbSet<Product> Products { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}