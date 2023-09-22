using ProjectTest.ApplicationCore.Interfaces;
using ProjectTest.ApplicationCore.Models;
using ProjectTest.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Infrastructure.Repository
{
	public class StudyRoomRepository : IStudyRoomRepository
	{
		private readonly ApplicationDbContext _db;
		public StudyRoomRepository(ApplicationDbContext db)
		{
			_db = db;
		}
		public IEnumerable<StudyRoom> GetAll()
		{
			return _db.StudyRooms.ToList();
		}
	}
}
