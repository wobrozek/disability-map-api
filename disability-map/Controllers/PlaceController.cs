using disability_map.Dtos;
using disability_map.Models;
using disability_map.Services.PlaceService;
using disability_map.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace disability_map.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;
        private readonly IUserService _userService;

        public PlaceController(IPlaceService placeService, IUserService userService)
        {
            _placeService = placeService;
            _userService = userService;
        }
 

        [HttpPost,Authorize]
        public async Task<ActionResult<Score>> CreatePlace(PostPlaceDto place)
        {
            int userId = _userService.GetUserId();
            return Ok(await _placeService.CreatePlace(place,userId));
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<ActionResult<Score>> DeletePlace(string id)
        {
            int userId = _userService.GetUserId();
            return Ok(await _placeService.DeletePlace(id, userId));
        }

        [HttpPut("{id}"), Authorize]
        public async Task<ActionResult<Score>> EditPlace(PostPlaceDto place,string id)
        {
            int userId = _userService.GetUserId();
            return Ok(await _placeService.EditPlace(place, userId ,id));
        }

        // GET: PlaceController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: PlaceController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: PlaceController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: PlaceController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: PlaceController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: PlaceController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: PlaceController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //private ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
