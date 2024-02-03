using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ProjeOyun.Application.Interfaces.Repositories;
using ProjeOyun.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOyun.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
	internal AppDbContext _context;
	internal DbSet<T> _dbSet;
	public GenericRepository(AppDbContext context)
	{
		_context = context;
		_dbSet = _context.Set<T>();
	}


	public async Task AddAsync(T entity)
	{
		await _dbSet.AddAsync(entity);
	}

	public async Task<T> FindAsync(int id)
	{
		return await _dbSet.FindAsync(id);
	}

	public async Task<List<T>> GetAllAsync()
	{
		return await _dbSet.ToListAsync();
	}

	public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
	{

		IQueryable<T> query = _dbSet;

		if (expression != null)
			query = query.Where(expression);

		if (include != null)
			query = include(query);

		return await query.ToListAsync();
	}

	public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
	{
		return await _dbSet.FirstOrDefaultAsync(expression);
	}

	public async Task HardDelete(T entity)
	{
		await Task.Run(() => _context.Remove(entity));
	}

	public async Task<T> UpdateAsync(T entity)
	{
		await Task.Run(()=> _context.Update(entity));
		return entity;
	}
	public async Task<int> SaveAsync()
	{
		return await _context.SaveChangesAsync();
	}

}
