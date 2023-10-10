using ABTest.Dto;
using ABTest.IRepositories;
using ABTest.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ABTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : Controller
    {
        private readonly IExperimentRepository experimentRepository;
        private readonly IDeviceRepository deviceRepository;

        public StatisticsController(IExperimentRepository experimentRepository, IDeviceRepository deviceRepository)
        {
            this.experimentRepository = experimentRepository;
            this.deviceRepository = deviceRepository;
        }

        [HttpGet]
        public IActionResult GetStatistics()
        {
            try
            {
                var experiments = experimentRepository.GetExperiments(); // Получаем список экспериментов
                var deviceCount = deviceRepository.GetDeviceCount(); // Получаем список всех девайсов 
                var statistics = new StatisticsDto   // Создаем dto и записываем туда нужные ззначения
                {
                    Experiments = experiments.Select(e => new ExperimentStatisticsDto 
                    {
                        ExperimentName = e.Name,
                        OptionsDistribution = e.Options.ToDictionary(o => o.OptionValue, 
                        o => e.DeviceExperiments.Count(de => de.OptionId == o.Id)),
                        TotalDevices = e.DeviceExperiments.Where(de => de.ExperimentId == e.Id).Count()
                    }).ToList(),

                    TotalDeviceCount = deviceCount
                };
                

                if (!ModelState.IsValid) 
                {
                    return BadRequest(ModelState); // Возвращаем BadRequest если модель не прошла валидацию 
                }

       

                return Ok(statistics); // Возвращаем json со статистикой
            }
            catch
            {
                return StatusCode(500, "Error while getting result"); // Возращаем 500 ошибку в случае если что-то пошло не так
            }
        }
    }
}
