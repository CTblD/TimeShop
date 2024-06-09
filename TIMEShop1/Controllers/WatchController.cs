using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TIMEShop1.Data;
using TIMEShop1.Interfaces;
using TIMEShop1.Models;
using TIMEShop1.ViewModels;

namespace TIMEShop1.Controllers
{
    public class WatchController : Controller
    {
        private readonly IWatchRepository _watchRepository;

        public readonly IPhotoService _photoService;

        public WatchController(IWatchRepository watchRepository, IPhotoService photoService)
        {
            _watchRepository = watchRepository;
            _photoService = photoService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Watch> watch = await _watchRepository.GetAll();
            return View(watch);
        }

        public async Task<IActionResult> Details(int id)
        {
            Watch watch = await _watchRepository.GetByIdAsync(id);
            return View(watch);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateWatchViewModel watchVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(watchVM.ImageUrl);
                var watch = new Watch
                {
                    Brand = watchVM.Brand,
                    Model = watchVM.Model,
                    Description = watchVM.Description,
                    Price = watchVM.Price,
                    ImageUrl = result.Url.ToString()
                };
                _watchRepository.Add(watch);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Фото не загузилось");
            }
            return View(watchVM);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var watch = await _watchRepository.GetByIdAsync(id);
            if (watch == null) return View("Error");
            var watchVM = new EditWatchViewModel
            {
                Brand = watch.Brand,
                Model = watch.Model,
                Description = watch.Description,
                Price = watch.Price,
                URL = watch.ImageUrl,
            };
            return View(watchVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditWatchViewModel watchVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Не получилось изменить часы");
                return View("Edit", watchVM);
            }
            var userWatch = await _watchRepository.GetByIdAsyncNoTracking(id);

            if (userWatch != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userWatch.ImageUrl);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Не получилось удалить фото");
                    return View(watchVM);
                }

                var photoResult = await _photoService.AddPhotoAsync(watchVM.ImageUrl);
                var watch = new Watch
                {
                    Id = id,
                    Brand = watchVM.Brand,
                    Model = watchVM.Model,
                    Description = watchVM.Description,
                    ImageUrl = photoResult.Url.ToString(),
                    Price = watchVM.Price
                };
                _watchRepository.Update(watch);

                return RedirectToAction("Index");
            }
            else
            {
                return View(watchVM);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            var watchDetails = await _watchRepository.GetByIdAsync(id);
            if (watchDetails == null) return View("Error");
            return View(watchDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteWatch(int id)
        {
            var watchDetails = await _watchRepository.GetByIdAsync(id);

            if (watchDetails == null)
            {
                return View("Error");
            }

            if (!string.IsNullOrEmpty(watchDetails.ImageUrl))
            {
                _ = _photoService.DeletePhotoAsync(watchDetails.ImageUrl);
            }

            _watchRepository.Delete(watchDetails);
            return RedirectToAction("Index");
        }
    }

}
