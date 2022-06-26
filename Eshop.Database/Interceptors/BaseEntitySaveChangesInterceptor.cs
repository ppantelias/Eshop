using Eshop.Database.Helpers;
using Eshop.Database.Services.Interfaces;
using Eshop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Eshop.Database.Interceptors
{
    public class BaseEntitySaveChangesInterceptor : SaveChangesInterceptor
    {
        private readonly IDateTimeService _dateTimeService;

        public BaseEntitySaveChangesInterceptor(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChanges(eventData, result);
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);

            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public void UpdateEntities(DbContext? context)
        {
            if (context == null) return;

            foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = _dateTimeService.Now;
                }

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.HasChangedOwnedEntities())
                {
                    entry.Entity.DateUpdated = _dateTimeService.Now;
                }

                if (entry.Entity.EntityState == Domain.Enums.EntityState.Deleted)
                {
                    entry.Entity.DateDeleted = _dateTimeService.Now;
                }
            }
        }
    }
}