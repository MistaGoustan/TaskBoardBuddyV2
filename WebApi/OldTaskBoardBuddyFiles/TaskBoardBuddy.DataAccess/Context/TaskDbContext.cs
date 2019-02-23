using Microsoft.EntityFrameworkCore;
using TaskBoardBuddy.Models;

namespace TaskBoardBuddy.DataAccess.Context
{
    public class TaskDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        public TaskDbContext(DbContextOptions options) : base (options)
        { /* intentionally left blank */ }
    }
}