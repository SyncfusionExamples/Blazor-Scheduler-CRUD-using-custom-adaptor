using System.ComponentModel.DataAnnotations;

namespace syncfusion_blazor_app.Data
{
    public class AppointmentData
    {
        [Key]
        public int RecordID { get; set; }
        public int Id { get; set; }
        public string? UserID { get; set; }
        public string? EventCategory { get; set; }
        public string? CategoryColor { get; set; }
        public string? EventType { get; set; }
        public string? OwnerType { get; set; }
        public string? OwnerId { get; set; }
        public string? Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? StartTimezone { get; set; }
        public string? EndTimezone { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public bool IsAllDay { get; set; } = false;
        public int? RecurrenceID { get; set; }
        public string? RecurrenceRule { get; set; }
        public string? RecurrenceException { get; set; }
        public bool? IsReadOnly { get; set; }
        public bool? IsBlock { get; set; }
        public string? CssClass { get; set; }
    }
}
