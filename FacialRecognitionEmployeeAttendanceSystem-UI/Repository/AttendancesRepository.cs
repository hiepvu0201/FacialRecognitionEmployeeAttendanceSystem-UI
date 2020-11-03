using FacialRecognitionEmployeeAttendanceSystem_UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Repository
{
    class AttendancesRepository
    {
        public HttpClient _client;
        public HttpResponseMessage _response;
        public AttendancesRepository()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:8080/");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<Attendances>> GetList()
        {
            _response = await _client.GetAsync($"/api/v1/users/");

            var json = await _response.Content.ReadAsStringAsync();
            List<Attendances> listAttendances = JsonConvert.DeserializeObject<List<Attendances>>(json);
            return listAttendances;
        }
    }
}