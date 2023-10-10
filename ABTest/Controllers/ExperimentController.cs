using ABTest.IRepositories;
using ABTest.IServices;
using ABTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace ABTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperimentController : Controller
    {
        private readonly IDeviceRepository deviceRepository;
        private readonly IExperimentRepository experimentRepository;
        private readonly IOptionRepository optionRepository;
        private readonly IExperimentService experimentService;
        public const string ButtonExperimentName = "button_color";
        public const string PriceExperimentName = "price";

        public ExperimentController(IDeviceRepository deviceRepository, IExperimentRepository experimentRepository,
            IOptionRepository optionRepository, IExperimentService experimentService)
        {
            this.deviceRepository = deviceRepository;
            this.experimentRepository = experimentRepository;
            this.optionRepository = optionRepository;
            this.experimentService = experimentService;
        }

        [HttpGet("button_color")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetButtonColor([FromQuery] string deviceToken)
        {
            try
            {
                if (deviceToken == null)
                {
                    return BadRequest(); // Возвращаем BadRequest если не получили deviceToken
                }

                var experiment = experimentRepository.GetExperimentByName(ButtonExperimentName); // Получаем эксперимент по имени

                var device = deviceRepository.GetDeviceByToken(deviceToken); // Получаем девайс по его токену 

                if (device == null)
                {
                    var option = experimentService.AddOptions(ButtonExperimentName); // Если токена нет, то генериуем для девайса результаты эксперимента

                    device = deviceRepository.Add(deviceToken, experiment, option); // Добавляем девайс и результат эксперимента в бд
                }

                var value = optionRepository.GetOption(device.Id, experiment.Id); // Получаем результат эксперимента для текущего девайса

                if (value == null) // В случае если Value пустое то генерируем результаты эксперимента
                {
                    var option = experimentService.AddOptions(ButtonExperimentName);
                    deviceRepository.AddExperiment(device, experiment, option);
                    value = optionRepository.GetOption(device.Id, experiment.Id);
                }

                var result = new Dictionary<string, string>
                {
                    { "key", ButtonExperimentName },
                    { "value", value.OptionValue }
                };

                return Ok(result); // Возвращаем результат в виде json
            }
            catch
            {
                return StatusCode(500, "Error while getting result");
            }
            
        }

        [HttpGet("price")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetPrice([FromQuery] string deviceToken)
        {
            try
            {
                if (deviceToken == null)
                {
                    return BadRequest(); // Возвращаем BadRequest если не получили deviceToken
                }

                var experiment = experimentRepository.GetExperimentByName(PriceExperimentName); // Получаем эксперимент по имени

                var device = deviceRepository.GetDeviceByToken(deviceToken); // Получаем девайс по его токену

                if (device == null)
                {
                    var option = experimentService.AddOptions(PriceExperimentName); // Если токена нет, то генериуем для девайса результаты эксперимента

                    device = deviceRepository.Add(deviceToken, experiment, option); // Добавляем девайс и результат эксперимента в бд
                }

                var value = optionRepository.GetOption(device.Id, experiment.Id); // Получаем результат эксперимента для текущего девайса

                if (value == null)  // В случае если Value пустое то генерируем результаты эксперимента
                {
                    var option = experimentService.AddOptions(PriceExperimentName);
                    deviceRepository.AddExperiment(device, experiment, option);
                    value = optionRepository.GetOption(device.Id, experiment.Id);
                }

                var result = new Dictionary<string, string>
                {
                    { "key", PriceExperimentName },
                    { "value", value.OptionValue }
                };

                return Ok(result); // Возвращаем результат в виде json
            }
            catch
            {

                return StatusCode(500, "Error while getting result"); // Возращаем 500 ошибку в случае если что-то пошло не так
            }
        }
    }
}
