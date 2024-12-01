using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventify.Models;
using Microsoft.EntityFrameworkCore;

namespace EventifyAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Event> Events { get; set; }
    }
}