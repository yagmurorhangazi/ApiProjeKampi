using ApiProjeKampi.WebUI.Dtos.CategoryDtos;
using ApiProjeKampi.WebUI.Dtos.TestimonialsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampi.WebUI.ViewComponents
{
    public class _TestimonialDefaultComponentPatial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TestimonialDefaultComponentPatial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            try
            {
                // Portu şu an Swagger'da çalışan kesin numara olan 7119 yaptık!
                var responseMessage = await client.GetAsync("https://localhost:7119/api/Testimonials/");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                    return View(values);
                }
            }
            catch (Exception)
            {
                return View(new List<ResultTestimonialDto>());
            }
            return View(new List<ResultTestimonialDto>());
        }


    }
}
