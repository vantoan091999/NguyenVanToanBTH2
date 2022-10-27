using NguyenVanToanBTH2.Models;
using Microsoft.EntityFrameworkCore;

namespace NguyenVanToanBTH2.Data {
     public class ApplicationDbcontext : DbContext
     {
        public ApplicationDbcontext (DbContextOptions<ApplicationDbcontext>opitons) : base(opitons)
        {
            if (opitons is null)
            {
                throw new ArgumentNullException(nameof(opitons));
            }
        }
        public DbSet<Student>Student{get;set;}
     }
}

