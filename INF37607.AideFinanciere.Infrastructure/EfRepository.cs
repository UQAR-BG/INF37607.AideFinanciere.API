using System;
using System.Collections.Generic;
using System.Text;
using EAISolutionFrontEnd.SharedKernel.Interfaces;
using EAISolutionFrontEnd.SharedKernel;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EAISolutionFrontEnd.Infrastructure
{
    public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity, IAggregateRoot
    {
        protected readonly EAISolutionFrontEndContext _EAISolutionFrontEndContext;

        public EfRepository(EAISolutionFrontEndContext eAISolutionFrontEndContext)
        {
            _EAISolutionFrontEndContext = eAISolutionFrontEndContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _EAISolutionFrontEndContext.Set<T>().AddAsync(entity);
            await _EAISolutionFrontEndContext.SaveChangesAsync();
            return entity;

        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _EAISolutionFrontEndContext.Set<T>().Remove(entity);
            await _EAISolutionFrontEndContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _EAISolutionFrontEndContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _EAISolutionFrontEndContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _EAISolutionFrontEndContext.Entry(entity).State = EntityState.Modified;
            await _EAISolutionFrontEndContext.SaveChangesAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_EAISolutionFrontEndContext.Set<T>().AsQueryable(), spec);
        }
     
    }
}

