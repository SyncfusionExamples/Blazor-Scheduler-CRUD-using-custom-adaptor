using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.Blazor;
using Microsoft.EntityFrameworkCore;

namespace syncfusion_blazor_app.Data
{
    public class AppointmentDataService
    {
        private readonly AppointmentDataContext _appointmentDataContext;

        public AppointmentDataService(AppointmentDataContext appDBContext)
        {
            _appointmentDataContext = appDBContext;
        }

        public async Task<List<AppointmentData>> Get()
        {
            return await _appointmentDataContext.AppointmentDatas.ToListAsync();
        }

        public async Task Insert(AppointmentData appointment)
        {
            var app = new AppointmentData();
            app.Id = appointment.Id;
            app.UserID = appointment.UserID;
            app.Subject = appointment.Subject;
            app.StartTime = appointment.StartTime;
            app.EndTime = appointment.EndTime;
            app.IsAllDay = appointment.IsAllDay;
            app.Location = appointment.Location;
            app.Description = appointment.Description;
            app.RecurrenceRule = appointment.RecurrenceRule;
            app.RecurrenceID = appointment.RecurrenceID;
            app.RecurrenceException = appointment.RecurrenceException;
            app.StartTimezone = appointment.StartTimezone;
            app.EndTimezone = appointment.EndTimezone;
            app.IsReadOnly = appointment.IsReadOnly;
            await _appointmentDataContext.AppointmentDatas.AddAsync(app);
            await _appointmentDataContext.SaveChangesAsync();
        }

        public async Task<AppointmentData> GetByID(int Id)
        {
            var app = await _appointmentDataContext.AppointmentDatas.FirstAsync(c => c.Id == Id);
            return app;
        }

        public async Task Update(AppointmentData appointment)
        {
            var app = await _appointmentDataContext.AppointmentDatas.FirstAsync(c => c.Id == appointment.Id);

            if (app != null)
            {
                app.UserID = appointment.UserID;
                app.Subject = appointment.Subject;
                app.StartTime = appointment.StartTime;
                app.EndTime = appointment.EndTime;
                app.IsAllDay = appointment.IsAllDay;
                app.Location = appointment.Location;
                app.Description = appointment.Description;
                app.RecurrenceRule = appointment.RecurrenceRule;
                app.RecurrenceID = appointment.RecurrenceID;
                app.RecurrenceException = appointment.RecurrenceException;
                app.StartTimezone = appointment.StartTimezone;
                app.EndTimezone = appointment.EndTimezone;
                app.IsReadOnly = appointment.IsReadOnly;

                _appointmentDataContext.AppointmentDatas?.Update(app);
                await _appointmentDataContext.SaveChangesAsync();
            }
        }

        public async Task Delete(AppointmentData appointment)
        {
            var app = await _appointmentDataContext.AppointmentDatas.FirstAsync(c => c.Id == appointment.Id);

            if (app != null)
            {
                _appointmentDataContext.AppointmentDatas?.Remove(app);
                await _appointmentDataContext.SaveChangesAsync();
            }
        }
    }
}
