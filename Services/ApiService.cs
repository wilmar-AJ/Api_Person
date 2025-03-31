
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using Personas.Models;
using System;

namespace Personas.Services;



    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ObservableCollection<Person>> GetPeopleAsync()
        {
            try
            {
                string url = "https://randomuser.me/api/?results=9"; // Obtiene 9 personas
                var response = await _httpClient.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(response))
                    return new ObservableCollection<Person>();

                var data = JsonSerializer.Deserialize<ApiResponse>(response, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var people = data?.Results.Select(p => new Person
                {
                    name = $"{p.name.First} {p.name.Last}",
                    age = p.Dob.Age,
                    email = p.email,
                    gender = p.gender,
                    picture = p.picture.Large
                });

                return new ObservableCollection<Person>(people);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener datos: {ex.Message}");
                return new ObservableCollection<Person>();
            }
        }
    }

    public class ApiResponse
    {
        public List<ApiPerson> Results { get; set; }
    }

    public class ApiPerson
    {
        public NameInfo name { get; set; }

        public DobInfo Dob { get; set; }
       
        public string email { get; set; }
        public string gender { get; set; }
        public PictureInfo picture { get; set; }
    }

    public class NameInfo
    {
        public string First { get; set; }
        public string Last { get; set; }
    }


      public class DobInfo
    {
        public int Age { get; set; }
    }

  

    public class PictureInfo
    {
        public byte Large { get; set; }
    }

