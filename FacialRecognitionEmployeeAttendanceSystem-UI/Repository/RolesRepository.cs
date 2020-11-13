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
    class RolesRepository
    {
        public HttpClient _client;
        public HttpResponseMessage _response;
        public RolesRepository()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:8080/");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<Roles>> GetList()
        {
            _response = await _client.GetAsync($"/api/v1/roles/");

            var json = await _response.Content.ReadAsStringAsync();
            List<Roles> listRoles = JsonConvert.DeserializeObject<List<Roles>>(json);
            return listRoles;
        }
        public void Add(Roles roles)
        {
            var role = JsonConvert.SerializeObject(roles);
            var buffer = Encoding.UTF8.GetBytes(role);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PostAsync($"/api/v1/roles/add", byteContent);
        }
        public void Update(int id, Roles roles)
        {
            var role = JsonConvert.SerializeObject(roles);
            var buffer = Encoding.UTF8.GetBytes(role);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PutAsync($"/api/v1/roles/update/{id}", byteContent);
        }
        public async Task<Roles> GetByIdAsync(int id)
        {
            _response = await _client.GetAsync($"/api/v1/roles/{id}");

            var json = await _response.Content.ReadAsStringAsync();
            Roles role = JsonConvert.DeserializeObject<Roles>(json);
            return role;
        }

        public void Delete(int id)
        {
            _client.DeleteAsync($"/api/v1/roles/delete/{id}");
        }
    }
}
