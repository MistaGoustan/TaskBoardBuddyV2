﻿using Microsoft.EntityFrameworkCore;

namespace WebApi.Context
{
    public class TaskItemDbContext : DbContext
    {
        public DbSet<TaskItemModel> TaskItems { get; set; }

        public TaskItemDbContext(DbContextOptions options) : base(options)
        { /* intentionally left blank */ }
    }
}