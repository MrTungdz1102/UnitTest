using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ProjectTest.ApplicationCore.Models;
using ProjectTest.Infrastructure.Data;
using ProjectTest.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.IntegrationTests.Repositories
{
    [TestFixture]
    public class StudyRoomRepositoryTest
    {
        private StudyRoomBooking studyRoomBooking1;
        private StudyRoomBooking studyRoomBooking2;
        private DbContextOptions<ApplicationDbContext> option;
        public StudyRoomRepositoryTest()
        {
            studyRoomBooking1 = new StudyRoomBooking()
            {
                FirstName = "Ben1",
                LastName = "Spark1",
                Date = new DateTime(2023, 1, 1),
                Email = "ben1@gmail.coom",
                BookingId = 1,
                StudyRoomId = 1
            };
            studyRoomBooking2 = new()
            {
                FirstName = "Ben2",
                LastName = "Spark2",
                Date = new DateTime(2023, 2, 2),
                Email = "ben2@gmail.coom",
                BookingId = 22,
                StudyRoomId = 2
            };
        }

        [SetUp]
        public void SetUp()
        {
            option = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "temp_database").Options;
        }

        [Test]
        [Order(1)]
        public void AddBooking_Booking_CheckValueFromDb()
        {
            using (var context = new ApplicationDbContext(option))
            {
                var repository = new StudyRoomBookingRepository(context);
                repository.Book(studyRoomBooking1);
            }

            using (var context = new ApplicationDbContext(option))
            {
                var bookingFromDb = context.StudyRoomBookings.FirstOrDefault(x => x.StudyRoomId == 1);
               //    Assert.That(bookingFromDb.FirstName, Is.EqualTo(studyRoomBooking1.FirstName));
                studyRoomBooking1.Should().BeEquivalentTo(bookingFromDb, option => option.Excluding(x => x.BookingId));
            }
        }

        [Test]
        [Order(2)]
        public void GetAllBooking_CheckValueFromDb()
        {
            var expectedResult = new List<StudyRoomBooking> { studyRoomBooking1, studyRoomBooking2 };

            using (var context = new ApplicationDbContext(option))
            {
                context.Database.EnsureDeleted();
                var repository = new StudyRoomBookingRepository(context);
                repository.Book(studyRoomBooking1);
                repository.Book(studyRoomBooking2);
            }

            List<StudyRoomBooking> actualList;
            using (var context = new ApplicationDbContext(option))
            {
                var repository = new StudyRoomBookingRepository(context);
                actualList = repository.GetAll(null).ToList();
            }

            CollectionAssert.AreEqual(expectedResult, actualList, new ObjectCompare());
        }
    }
}
