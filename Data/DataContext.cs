namespace GoalHabitAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
            options.UseSqlServer("Server=127.0.0.1,1433;Database=habit_goal_db;User=sa;Password=980209Ck;TrustServerCertificate=True;");
        }

        public DbSet<Goal> Goals { get; set; }
    }
}
