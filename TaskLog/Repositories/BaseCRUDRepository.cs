using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TaskLog.Repositories
{
	public class BaseCRUDRepository<TEntity> : IBaseCRUDRepository<TEntity> where TEntity : class
	{
		protected DbContext _dbContext;
		protected DbSet<TEntity> _table;
		public BaseCRUDRepository(DbContext dbContext)
		{
			_dbContext = dbContext;
			_table = _dbContext.Set<TEntity>();
		}

		public async Task<TEntity> CreateAsync(TEntity entity)
		{
			await _table.AddAsync(entity);
			await _dbContext.SaveChangesAsync();

			return entity;
		}

		public async Task DeleteAsync(TEntity entity)
		{
			_table.Remove(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<TEntity> FindByIdAsync(object id)
		{
			object newId = CastPrimaryKey(id);
			return await _table.FindAsync(newId);
		}

		public IQueryable<TEntity> GetAll()
		{
			return _table;
		}


		public async Task<TEntity> UpdateAsync(TEntity entity)
		{
			TEntity oldItem = await FindByIdAsync(GetValuePrimaryKey(entity));
			_dbContext.Entry(oldItem).CurrentValues.SetValues(entity);
			await _dbContext.SaveChangesAsync();

			return entity;
		}

		protected object GetValuePrimaryKey(TEntity entity)
		{
			string primaryKeyName = GetPrimaryKeyName();
			return typeof(TEntity).GetProperty(primaryKeyName)!.GetValue(entity);
		}

		protected string GetPrimaryKeyName()
		{
			IEnumerable<string> source = _dbContext.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties.Select((IProperty x) => x.Name);
			string text = source.FirstOrDefault();
			if (source.Count() > 1)
			{
				throw new ApplicationException("El objeto tiene mas de 1 llave primaria. Lo cual no permite la automatización de BaseModel en el Update");
			}

			if (text == null)
			{
				throw new ApplicationException("El objeto no tiene llave primaria. Lo cual no permite la automatización de BaseModel en el Update");
			}

			return text;
		}

		protected object CastPrimaryKey(object id)
		{
			string primaryKeyName = GetPrimaryKeyName();
			Type propertyType = typeof(TEntity).GetProperty(primaryKeyName)!.PropertyType;
			return Convert.ChangeType(id, propertyType);
		}
	}
}
