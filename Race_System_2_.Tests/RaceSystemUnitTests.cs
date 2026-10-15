using Microsoft.EntityFrameworkCore;
using Race_System_2_.Data;
using Race_System_2_.Models;        
using Xunit;

namespace Race_System_2_.Tests
{
    public class RaceSystemUnitTests
    {
        private ApplicationDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task Organiser_Can_Create_And_Manage_Event()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            var newEvent = new Event
            {
                EventID = 101,
                EventName = "Durban City Marathon",
                Description = "Annual 10km run",
                EventDate = DateTime.Now.AddDays(10),
                EventLocation = "Durban Beachfront",
                Distance = 10,
                EventType = "Run",
                OrganizerName = "Organiser John"
            };

            // Act
            context.Events.Add(newEvent);
            await context.SaveChangesAsync();

            // Assert
            var eventFromDb = await context.Events.FindAsync(101);
            Assert.NotNull(eventFromDb);
            Assert.Equal("Durban City Marathon", eventFromDb.EventName);
            Assert.Equal(10, eventFromDb.Distance);
        }

        [Fact]
        public async Task Participant_Can_Enrol_In_Event_And_Category()
        {
            // Arrange
            using var context = GetInMemoryDbContext();

            var registration = new Registration
            {
                RegistrationID = 1,
                ParticipantID = 1,
                EventRaceID = 101,
                CategoryID = 5,
                BidNumber = 42,
                PaymentStatus = "Paid",
                Reg_Date = DateTime.Now
            };

            // Act
            context.Registrations.Add(registration);
            await context.SaveChangesAsync();

            // Assert
            var savedReg = await context.Registrations.FirstOrDefaultAsync(r => r.RegistrationID == 1);
            Assert.NotNull(savedReg);
            Assert.Equal(101, savedReg.EventRaceID);
            Assert.Equal(5, savedReg.CategoryID);
            Assert.Equal("Paid", savedReg.PaymentStatus);
        }
    }
}