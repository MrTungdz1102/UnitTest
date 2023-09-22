using ProjectTest.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.ApplicationCore.Interfaces
{
	public interface IStudyRoomBookingRepository
	{
		void Book(StudyRoomBooking booking);
		IEnumerable<StudyRoomBooking> GetAll(DateTime? dateTime);

	}
}
