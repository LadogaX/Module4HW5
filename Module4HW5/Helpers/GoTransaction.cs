using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW5.Helpers
{
    public class GoTransaction
    {
        public async Task Start(Func<Task> func, string[] args)
        {
            await using (var transaction = await new SampleContextFactory().CreateDbContext(args).Database.BeginTransactionAsync())
            {
                try
                {
                    await func();
                    await transaction.CommitAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    await transaction.RollbackAsync();
                }
            }
        }
    }
}
