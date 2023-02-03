using System.Linq.Expressions;
using DeliveryExpress.Domain.SeedWork;
using DeliveryExpress.Infrastructure.DeliveryRequest;
using Microsoft.EntityFrameworkCore;

namespace DeliveryExpress.Infrastructure
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        private readonly DeliveryExpressContext _context = null!;
        public IUnitOfWork UnitOfWork => _context;

        protected GenericRepository(DeliveryExpressContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            return (await _context.Set<T>().AddAsync(entity, cancellationToken)).Entity;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            T? entity = await _context.Set<T>().FindAsync(id);
            return entity ?? default!;
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _ = _context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAsync(GenericFilterSpecification filter)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .Where(filter.Filter ?? "Id")
                .OrderBy(filter.OrderBy ?? "Id", filter.OrderByDirection ?? "ASC")
                .Skip((filter.Page ?? 1 - 1) * (filter.PageSize ?? 10))
                .Take(filter.PageSize ?? 10)
                .ToListAsync();
        }
    }

    public class GenericFilterSpecification
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string? OrderBy { get; set; }
        public string? OrderByDirection { get; set; }
        public string? Filter { get; set; }
    }

    public static class GenericFilterSpecificationExtensions
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string orderBy, string orderByDirection)
        {
            Type type = typeof(T);
            System.Reflection.PropertyInfo? property = type.GetProperty(orderBy);
            ParameterExpression parameter = Expression.Parameter(type, "p");
            MemberExpression propertyAccess = Expression.MakeMemberAccess(parameter, property!);
            LambdaExpression orderByExpression = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExpression = Expression.Call(typeof(Queryable), orderByDirection == "ASC" ? "OrderBy" : "OrderByDescending", new Type[]
            {
                type,
                property.PropertyType
            }, query.Expression, Expression.Quote(orderByExpression));
            return query.Provider.CreateQuery<T>(resultExpression);
        }

        public static IQueryable<T> Where<T>(this IQueryable<T> query, string filter)
        {
            Type type = typeof(T);
            ParameterExpression parameter = Expression.Parameter(type, "p");
            MemberExpression propertyAccess = Expression.MakeMemberAccess(parameter, type.GetProperty(filter));
            LambdaExpression filterExpression = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExpression = Expression.Call(typeof(Queryable), "Where", new Type[]
            {
                type
            }, query.Expression, Expression.Quote(filterExpression));
            return query.Provider.CreateQuery<T>(resultExpression);
        }
    }
}