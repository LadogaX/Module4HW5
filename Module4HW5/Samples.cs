using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module4HW5.Entities;

namespace Module4HW5
{
    public class Samples
    {
        private readonly ApplicationDbContext _context;

        public Samples(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeEntity>> JoinTables()
        {
            var joinTables = await _context.Employees
                             .Include(e => e.Office)
                             .ThenInclude(e => e.Title)
                             .ToListAsync();

            return joinTables;
        }

        public async Task<string> DateDiff()
        {
            var data = await _context.Employees
                             .AsNoTracking()
                             .Select(s => s.HiredDate)
                             .ToListAsync();

            var result = data.Select(res => (DateTime.UtcNow - res));

            return result.ToString();
        }

        // public async Task LoadOnlyProducts()
        // {
        //   // IQueryable<TimeSpan> empl = await _context.Employees.Select(s => new { delta = (DateTime.UtcNow - s.HiredDate)} ).ToListAsync();
        //   // var result = await _context.Employees.Where(t => SqlFunctions.DateDiff(DateTime.UtcNow, t.HiredDate) < 120);
        // }
        public async Task UpdateTooEntities()
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == 8);
            if (employee != null)
            {
                employee.FirstName = "New Name";
            }

            var title = await _context.Title.FirstOrDefaultAsync(x => x.TitleId == 1);
            if (title != null)
            {
                title.Name = "New Name Title";
            }

            await _context.SaveChangesAsync();
        }

        public async Task AddEmployeeWithTitle()
        {
            var employee = new EmployeeEntity
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                DateOfBirth = new DateTime(1985, 1, 1),
                OfficeId = 1,
                TitleId = 3
            };

            await _context.Employees.AddAsync(employee);
        }

        public async Task RemoveEmployee(int id_employee)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id_employee);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<string>> GroupEmployeeForTitle()
        {
            var result = await _context.Employees
            .AsNoTracking()
            .Include(e => e.Title)
             .GroupBy(x => x.Title.Name)
             .Select(g => g.Key)
             .Where(s => s.Contains('a'))
             .ToListAsync();

            return result;
        }
    }
}
