using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.ApplicationCore.Models.VM
{
	public class StudyRoomBookingResult : StudyRoomBookingBase
	{
		public StudyRoomBookingCode Code { get; set; }
		public int BookingId { get; set; }
	}
}
