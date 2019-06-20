using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GrokTalk.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Thread> Threads { get; set; }

    }
}
