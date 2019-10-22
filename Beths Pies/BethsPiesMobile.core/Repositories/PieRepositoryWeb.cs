using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BethsPiesMobile.core.Models;
using Newtonsoft.Json;

namespace BethsPiesMobile.core.Repositories
{
    public class PieRepositoryWeb
    {
        public async Task<List<Pie>> GetAllPies()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var responseMessage = await httpClient.GetAsync("http://172.18.12.241:5000/api/pies");
            if (!responseMessage.IsSuccessStatusCode) return null;
            var jsonResilt = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            var pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(jsonResilt);
            return pies.ToList();
        }

        public List<Category> GetCategoriesWithPies()
        {
            throw new NotImplementedException();
        }

        public async Task<Pie> GetPieById(int id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var responseMessage = await httpClient.GetAsync("http://172.18.12.241:5000/api/pies" + id);
            if (!responseMessage.IsSuccessStatusCode) return null;
            var jsonResilt = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            var pie = JsonConvert.DeserializeObject<Pie>(jsonResilt);
            return pie;
        }
    }
}
