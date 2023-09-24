using FluentAssertions;
using Moq;
using ProjectTest.ApplicationCore.Interfaces;
using ProjectTest.ApplicationCore.Models;
using ProjectTest.ApplicationCore.Models.VM;
using ProjectTest.ApplicationCore.Services;

namespace ProjectTest.CommonTests.Services
{
    [TestFixture]
    public class StudyRoomBookingServiceTest
    {
        private Mock<IStudyRoomBookingRepository> _studyRoomBookingRepoMock;
        private Mock<IStudyRoomRepository> _studyRoomRepoMock;
        private StudyRoomBookingService _bookingService;
        private StudyRoomBooking _request;
        private List<StudyRoom> _availableRoom;

        [SetUp]
        public void SetUp()
        {
            _request = new StudyRoomBooking()
            {
                FirstName = "Ben",
                LastName = "Spark",
                Email = "ben@gmail.com",
                Date = new DateTime(2024, 1, 1)
            };
            _availableRoom = new List<StudyRoom> {
                new StudyRoom{
                    Id=10,RoomName="Michigan", RoomNumber="A202"
                }
            };
            _studyRoomBookingRepoMock = new Mock<IStudyRoomBookingRepository>();
            _studyRoomRepoMock = new Mock<IStudyRoomRepository>();
            _studyRoomRepoMock.Setup(x => x.GetAll()).Returns(_availableRoom);
            _bookingService = new StudyRoomBookingService(_studyRoomBookingRepoMock.Object, _studyRoomRepoMock.Object);
        }

        [TestCase]
        public void GetAllBooking_InvokeMethod_CheckIfRepoIsCalled()
        {
            _bookingService.GetAllBooking();
            _studyRoomBookingRepoMock.Verify(x => x.GetAll(null), Times.Once);
        }

        [Test]
        public void BookingException_NullRequest_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _bookingService.BookStudyRoom(null));
            Assert.AreEqual("Value cannot be null. (Parameter 'request')", exception.Message);
            Assert.AreEqual("request", exception.ParamName);
        }

        [Test]
        public void StudyRoomBooking_SaveBookingWithAvailableRoom_ReturnResultWithAllValue()
        {
            StudyRoomBooking studyRoomSave = null;
            _studyRoomBookingRepoMock.Setup(x => x.Book(It.IsAny<StudyRoomBooking>())).Callback<StudyRoomBooking>(booking =>
            {
                studyRoomSave = booking;
            });

            _bookingService.BookStudyRoom(_request);

            _studyRoomBookingRepoMock.Verify(x => x.Book(It.IsAny<StudyRoomBooking>()), Times.Once);

            Assert.NotNull(studyRoomSave);
            studyRoomSave.Should().BeEquivalentTo(_request, option => option.Excluding(x => x.BookingId).Excluding(x => x.StudyRoomId));
        }

        [Test]
        public void StudyRoomBookingResultCheck_InputRequest_ValueMatchInResult()
        {
            StudyRoomBookingResult result = _bookingService.BookStudyRoom(_request);

            Assert.NotNull(result);
            result.Should().BeEquivalentTo(_request, option => option.Excluding(x => x.BookingId).Excluding(x => x.StudyRoomId));
        }

        [Test]
        [TestCase(true, ExpectedResult = StudyRoomBookingCode.Success)]
        [TestCase(false, ExpectedResult = StudyRoomBookingCode.NoRoomAvailable)]
        public StudyRoomBookingCode ResultCodeSuccess_RoomAvailability_ReturnSuccessResultCode(bool successCode)
        {
            // StudyRoomBookingResult result = _bookingService.BookStudyRoom(_request);
            //  Assert.AreEqual(StudyRoomBookingCode.Success, result.Code);

            if (!successCode)
            {
                _availableRoom.Clear();
            }
            return _bookingService.BookStudyRoom(_request).Code;
        }

        [TestCase(0, false)]
        [TestCase(55, true)]
        public void StudyRoomBooking_BookRoomWithAvailalbility_ReturnsBookingId(int expectedBookingId, bool roomAvailability)
        {
            if (!roomAvailability)
            {
                _availableRoom.Clear();
            }


            _studyRoomBookingRepoMock.Setup(x => x.Book(It.IsAny<StudyRoomBooking>()))
                .Callback<StudyRoomBooking>(booking =>
                {
                    booking.BookingId = 55;
                });

            var result = _bookingService.BookStudyRoom(_request);
            Assert.AreEqual(expectedBookingId, result.BookingId);
        }

        [Test]
        public void BookNotInvoked_SaveBookingWithoutAvailableRoom_BookMethodNotInvoked()
        {
            _availableRoom.Clear();
            var result = _bookingService.BookStudyRoom(_request);
            _studyRoomBookingRepoMock.Verify(x => x.Book(It.IsAny<StudyRoomBooking>()), Times.Never);

        }
    }
}
