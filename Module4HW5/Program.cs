using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Module4HW5.Helpers;

namespace Module4HW5
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                var sample = new Samples(context);
                var result1 = sample.JoinTables();
                var result2 = sample.DateDiff();

                GoTransaction goTransaction = new GoTransaction();
                await goTransaction.Start(() => sample.UpdateTooEntities(), args);
                await goTransaction.Start(() => sample.AddEmployeeWithTitle(), args);
                await goTransaction.Start(() => sample.RemoveEmployee(2), args);
                var result3 = sample.GroupEmployeeForTitle();
            }
        }
    }
}
