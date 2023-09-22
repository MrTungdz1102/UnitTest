using ProjectTest.ApplicationCore.Models;
using ProjectTest.ApplicationCore.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.ApplicationCore.Interfaces
{
    public interface IStudyRoomBookingService
    {
        StudyRoomBookingResult BookStudyRoom(StudyRoomBooking request);
        IEnumerable<StudyRoomBooking> GetAllBooking();
    }
}
