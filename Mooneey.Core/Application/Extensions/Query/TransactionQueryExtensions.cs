using Microsoft.EntityFrameworkCore;
using Mooneey.Domain;

namespace Mooneey;

public static class TransactionQueryExtensions
{
    public static IQueryable<Transaction> IncludeAll(this IQueryable<Transaction> query)
    {
        return query
            .Include(x => (x as Income)!.Account)
            .Include(x => (x as Expense)!.Account)
            .Include(x => (x as Transfer)!.SourceAccount)
            .Include(x => (x as Transfer)!.TargetAccount);
    }
}