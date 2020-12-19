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

        public void Add(Departments departments)
        {
            var department = JsonConvert.SerializeObject(departments);
            var buffer = Encoding.UTF8.GetBytes(department);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PostAsync($"/api/v1/departments/add", byteContent);
        }
        public void Update(int id, Departments departments)
        {
            var department = JsonConvert.SerializeObject(departments);
            var buffer = Encoding.UTF8.GetBytes(department);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PutAsync($"/api/v1/departments/update/{id}", byteContent);
        }
        public async Task<Departments> GetByIdAsync(int id)
        {
            _response = await _client.GetAsync($"/api/v1/departments/{id}");

            var json = await _response.Content.ReadAsStringAsync();
            Departments department = JsonConvert.DeserializeObject<Departments>(json);
            return department;
        }

        public void Delete(int id)
        {
            _client.DeleteAsync($"/api/v1/departments/delete/{id}");
        }
    }
}
