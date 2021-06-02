using CaWorkshop.Application.Common.Interfaces;
using CaWorkshop.Domain.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Reflection;


namespace CaWorkshop.Infrastructure.Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        ////public DbSet<TodoItem> TodoItems { get; set; }

        ////public DbSet<TodoList> TodoLists { get; set; }

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        //public DbSet<TodoList> ToDoLists { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        //public DbSet<TodoItem> TodoItems { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine)
                .EnableDetailedErrors();
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
      
    }
}
