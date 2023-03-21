using Microsoft.EntityFrameworkCore;

namespace syncfusion_blazor_app.Data
{
    public class AppointmentDataContext: DbContext
    {
        public AppointmentDataContext(DbContextOptions<AppointmentDataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentData>().HasData(
                new AppointmentData
                {
                    RecordID = 1,
                    Id = 1,
                    Subject = "Meeting",
                    StartTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 10, 0, 0),
                    EndTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 12, 0, 0),
                    Location = "Tamilnadu"
                }
            ); ;
        }
        public DbSet<AppointmentData> AppointmentDatas { get; set; }
    }
}
