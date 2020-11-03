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
    class DepartmentsRepository
    {
        public HttpClient _client;
        public HttpResponseMessage _response;
        public DepartmentsRepository()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:8080/");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Departments>> GetList()
        {
            _response = await _client.GetAsync($"/api/v1/departments/");

            var json = await _response.Content.ReadAsStringAsync();
            List<Departments> listDepartment = JsonConvert.DeserializeObject<List<Departments>>(json);
            return listDepartment;
        }
    }
}
