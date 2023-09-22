using ProjectTest.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.ApplicationCore.Interfaces
{
	public interface IStudyRoomRepository
	{
		IEnumerable<StudyRoom> GetAll();
	}
}
