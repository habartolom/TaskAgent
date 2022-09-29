namespace TaskLog.Repositories
{
	public interface IBaseCRUDRepository<TEntity> where TEntity : class
	{
		Task<TEntity> CreateAsync(TEntity entity);
		Task DeleteAsync(TEntity entity);
		Task<TEntity> FindByIdAsync(object id);
		IQueryable<TEntity> GetAll();
		Task<TEntity> UpdateAsync(TEntity entity);
	}
}
