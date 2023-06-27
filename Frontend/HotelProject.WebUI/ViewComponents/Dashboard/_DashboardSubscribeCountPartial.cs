using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial:ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofile/ozhanaloglu"),
                Headers =
    {
        { "X-RapidAPI-Key", "06a2d8f040mshf9a93a3b9709ff7p1fa3a1jsn59d0f7ed5481" },
        { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ResultInstagramFollowersDto resultInstagramFollowersDto = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
                ViewBag.v1= resultInstagramFollowersDto.followers;
                ViewBag.v2= resultInstagramFollowersDto.following;
                return View(resultInstagramFollowersDto);
            }

        }
    }
}
