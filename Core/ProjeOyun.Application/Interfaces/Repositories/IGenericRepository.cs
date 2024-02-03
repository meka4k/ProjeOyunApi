using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOyun.Application.Interfaces.Repositories
{
	public interface IGenericRepository<T> where T : class
	{
		Task<List<T>> GetAllAsync();
		Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);
		Task<T> GetAsync(Expression<Func<T, bool>> expression);
		Task<T> FindAsync(int id);
		Task AddAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task HardDelete(T entity);
	}
}
