using Microsoft.AspNetCore.Mvc;
using ProjectTest.ApplicationCore.Interfaces;

namespace ProjectTest.Controllers
{
    public class RoomsController : Controller
	{
		private readonly IStudyRoomService _studyRoomService;
		public RoomsController(IStudyRoomService studyRoomService)
		{
			_studyRoomService = studyRoomService;
		}
		public IActionResult Index()
		{
			return View(_studyRoomService.GetAll());
		}
	}
}
