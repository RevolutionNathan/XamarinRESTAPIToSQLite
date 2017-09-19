using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StarWarsPeople2.Dtos;
using StarWarsPeople2.Models;
using System.Diagnostics;
using System.Text;

namespace StarWarsPeople2.Services
{
    public class DataService
    {
        HttpClient client;
        public List<SWPeople> People { get; private set; }
        public List<SWAPPeopleDto> DTO {get; private set;}
        public Results results { get; set; }

        public DataService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }


        public async Task<List<SWPeople>> GetPeopleAsync()
        {
           
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    DTO = JsonConvert.DeserializeObject<Results>(content).results;

                    People = DTO.Select(x => new SWPeople() { name = x.name, height = x.height, mass = x.mass, hair_color = x.hair_color, skin_color = x.skin_color, eye_color = x.eye_color, birth_year = x.birth_year, gender = x.gender, homeworld = x.homeworld }).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return People;
        }
    }
}
