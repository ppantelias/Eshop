using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Eshop.Database.Helpers
{
    public static class EntityEntryExtensions
    {
        public static bool HasChangedOwnedEntities(this EntityEntry @this) 
            => @this.References.Any(r =>
                r.TargetEntry != null &&
                r.TargetEntry.Metadata.IsOwned() &&
                (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
    }
}