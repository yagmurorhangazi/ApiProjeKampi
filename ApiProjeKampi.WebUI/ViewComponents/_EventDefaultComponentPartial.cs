using ApiProjeKampi.WebUI.Dtos.EventDtos;
using ApiProjeKampi.WebUI.Dtos.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampi.WebUI.ViewComponents
{
    public class _EventDefaultComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _EventDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            try
            {
                // Portu şu an Swagger'da çalışan kesin numara olan 7119 yaptık!
                var responseMessage = await client.GetAsync("https://localhost:7119/api/YummyEvent/");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultEventDto>>(jsonData);
                    return View(values);
                }
            }
            catch (Exception)
            {
                return View(new List<ResultEventDto>());
            }
            return View(new List<ResultEventDto>());
        }
    }
}
