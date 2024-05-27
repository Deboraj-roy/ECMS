﻿using ECMS.Domain;
using Microsoft.EntityFrameworkCore;

namespace ECMS.Infrastructure
{
    public abstract class UnitOfWork : IUnitOfWork, IDisposable, IAsyncDisposable
    {
        private readonly DbContext _dbContext; 

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Dispose() => _dbContext?.Dispose();
        public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();
        public void Save() => _dbContext?.SaveChanges();
        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();

    }
}
