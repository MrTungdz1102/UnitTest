using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTest.ApplicationCore.Interfaces;
using ProjectTest.ApplicationCore.Models;

namespace ProjectTest.ApplicationCore.Services
{
    public class StudyRoomService : IStudyRoomService
	{
		private readonly IStudyRoomRepository _studyRoomRepository;
		public StudyRoomService(IStudyRoomRepository studyRoomRepository)
		{
			_studyRoomRepository = studyRoomRepository;
		}


		public IEnumerable<StudyRoom> GetAll()
		{
			return _studyRoomRepository.GetAll();
		}
	}
}
