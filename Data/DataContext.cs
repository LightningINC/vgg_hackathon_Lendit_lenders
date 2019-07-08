using Microsoft.EntityFrameworkCore;
using lendit.Model;

namespace lendit.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Eligibility> Eligibilities { get; set; }
        public DbSet<LenderBorrowerTransaction> LenderBorrowerTransactions {get; set;} 
        public DbSet<LenderPool> LenderPools {get; set;} 
        public DbSet<Logger> Loggers { get; set; }  
        public DbSet<TransactionEntity> TransactionEntities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.Entity<Wallet>()
            //     .HasOne(w => w.User)
            //     .WithOne(us => us.Wallet)
            //     .HasForeignKey<User>(us => us.UserHash);

            // builder.Entity<TransactionEntity>()
            //     .HasKey(te => te.TransactionEntityId);

            builder.Entity<TransactionEntity>()
                .HasOne(te => te.User)
                .WithMany(us => us.TransactionEntity)
                .HasForeignKey(te => te.UserHash);

            // builder.Entity<Eligibility>()
            //     .HasOne(el => el.User)
            //     .WithOne(us => us.Eligibility)
            //     .HasForeignKey<User>(el => el.UserHash);

            builder.Entity<LenderPool>()
                .HasOne(lp => lp.Lender)
                .WithMany(us => us.LenderPool)
                .HasForeignKey(lp => lp.LenderHash);


            builder.Entity<LenderBorrowerTransaction>()
            .HasOne(lbt => lbt.Lender)
            .WithMany(us => us.LenderTransaction)
            .HasForeignKey(lbt => lbt.LenderHash);

            builder.Entity<LenderBorrowerTransaction>()
            .HasOne(lbt => lbt.Borrower)
            .WithMany(us => us.BorrowerTransaction)
            .HasForeignKey(lbt => lbt.BorrowHash);
            

        }
        
    }
}