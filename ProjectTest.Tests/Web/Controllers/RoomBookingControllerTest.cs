using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectTest.ApplicationCore.Interfaces;
using ProjectTest.ApplicationCore.Models;
using ProjectTest.ApplicationCore.Models.VM;
using ProjectTest.ApplicationCore.Services;
using ProjectTest.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.FunctionalTests.Web.Controllers
{
    [TestFixture]
    public class RoomBookingControllerTest
    {
        private Mock<IStudyRoomBookingService> _studyRoomBookingServiceMock;
        private RoomBookingController _roomBookingController;

        [SetUp]
        public void SetUp()
        {
            _studyRoomBookingServiceMock = new Mock<IStudyRoomBookingService>();
            _roomBookingController = new RoomBookingController(_studyRoomBookingServiceMock.Object);
        }

        [Test]
        public void IndexPage_CallRequest_VerifyAllInvoked()
        {
            _roomBookingController.Index();
            _studyRoomBookingServiceMock.Verify(x => x.GetAllBooking(), Times.Once);
        }

        [Test]
        public void RoomBookCheck_ModelStateInvalid_ReturnView()
        {
            _roomBookingController.ModelState.AddModelError("test", "test");
            var result = _roomBookingController.Book(new StudyRoomBooking());
            ViewResult viewResult = result as ViewResult;
            Assert.AreEqual("Book", viewResult.ViewName);
        }

        [Test]
        public void BookRoomCheck_NotSuccessfull_NoRoomCode()
        {
            _studyRoomBookingServiceMock.Setup(x => x.BookStudyRoom(It.IsAny<StudyRoomBooking>()))
              .Returns((StudyRoomBooking booking) => new StudyRoomBookingResult()
              {
                  //Code = StudyRoomBookingCode.Success,
                  //FirstName = booking.FirstName,
                  //LastName = booking.LastName,
                  //Date = booking.Date,
                  //Email = booking.Email
                  Code = StudyRoomBookingCode.NoRoomAvailable
              });

            var result = _roomBookingController.Book(new StudyRoomBooking());
            Assert.IsInstanceOf<ViewResult>(result);
            ViewResult viewResult = result as ViewResult;
            Assert.AreEqual("No Study Room available for selected date", viewResult.ViewData["Error"]);
        }

        [Test]
        public void BookRoomCheck_Successful_SuccessCodeAndRedirect()
        {
            _studyRoomBookingServiceMock.Setup(x => x.BookStudyRoom(It.IsAny<StudyRoomBooking>()))
                .Returns((StudyRoomBooking booking) => new StudyRoomBookingResult()
                {
                    Code = StudyRoomBookingCode.Success,
                    FirstName = booking.FirstName,
                    LastName = booking.LastName,
                    Date = booking.Date,
                    Email = booking.Email
                });
            //act
            var result = _roomBookingController.Book(new StudyRoomBooking()
            {
                Date = DateTime.Now,
                Email = "hello@dotnetmastery.com",
                FirstName = "Hello",
                LastName = "DotNetMastery",
                StudyRoomId = 1
            });

            //assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            RedirectToActionResult actionResult = result as RedirectToActionResult;
            Assert.AreEqual("Hello", actionResult.RouteValues["FirstName"]);
            Assert.AreEqual(StudyRoomBookingCode.Success, actionResult.RouteValues["Code"]);
        }
    }
}
