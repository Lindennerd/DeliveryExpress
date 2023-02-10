using System.Data;
using DeliveryExpress.Domain.SeedWork;
using DeliveryExpress.Infrastructure.Client;
using DeliveryExpress.Infrastructure.Product;
using DeliveryExpress.Infrastructure.Stablishment;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DeliveryExpress.Infrastructure.DeliveryRequest
{
    public class DeliveryExpressContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "DeliveryRequest";
        public DbSet<Domain.DeliveryRequestAggregator.DeliveryRequest> DeliveryRequests { get; set; } = null!;
        public DbSet<Domain.ClientAggregator.Client> Clients { get; set; } = null!;
        public DbSet<Domain.DeliveryRequestAggregator.DeliveryItem> DeliveryItems { get; set; } = null!;
        public DbSet<Domain.ProductAggregator.Product> Products { get; set; } = null!;
        public DbSet<Domain.StablishmentAggregator.Stablishment> Stablishments { get; set; } = null!;
        public DbSet<Domain.StablishmentAggregator.Contact> Contacts { get; set; } = null!;

        private readonly IMediator _mediator;
        private IDbContextTransaction _currentTransaction;

        public DeliveryExpressContext(DbContextOptions<DeliveryExpressContext> options,
                                      IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DeliveryRequestConfiguration());
            modelBuilder.ApplyConfiguration(new DeliveryItemConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new StablishmentConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
        }

        public async Task<int> SaveChangesAsync<T>(CancellationToken cancellationToken = default) where T : Entity
        {
            await _mediator.DispatchDomainEventsAsync<T>(this);
            await SaveChangesAsync(cancellationToken);
            return 0;
        }

        public async Task<bool> SaveEntitiesAsync<T>(CancellationToken cancellationToken = default) where T : Entity
        {
            await _mediator.DispatchDomainEventsAsync<T>(this);
            await SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}