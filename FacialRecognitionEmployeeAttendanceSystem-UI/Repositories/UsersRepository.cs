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
    class UsersRepository
    {
        public HttpClient _client;
        public HttpResponseMessage _response;
        public UsersRepository()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:8080/");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<Users>> GetList()
        {
            _response = await _client.GetAsync($"/api/v1/users/");

            var json = await _response.Content.ReadAsStringAsync();
            List<Users> listUsers = JsonConvert.DeserializeObject<List<Users>>(json);
            return listUsers;
        }
        public void Add(Users users)
        {
            var user = JsonConvert.SerializeObject(users);
            var buffer = Encoding.UTF8.GetBytes(user);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PostAsync($"/api/v1/users/add", byteContent);
        }
        public void Update(long id, Users users)
        {
            var user = JsonConvert.SerializeObject(users);
            var buffer = Encoding.UTF8.GetBytes(user);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PutAsync($"/api/v1/users/update/{id}", byteContent);
        }
        public async Task<Users> GetByIdAsync(long id)
        {
            _response = await _client.GetAsync($"/api/v1/users/{id}");

            var json = await _response.Content.ReadAsStringAsync();
            Users user = JsonConvert.DeserializeObject<Users>(json);
            return user;
        }
        public void Delete(long id)
        {
            _client.DeleteAsync($"/api/v1/users/delete/{id}");
        }
        public async Task<Users> GetByPinAsync(string pin)
        {
            _response = await _client.GetAsync($"/api/v1/users/pin/{pin}");

            var json = await _response.Content.ReadAsStringAsync();
            Users user = JsonConvert.DeserializeObject<Users>(json);
            return user;
        }
        public async Task<Users> GetByFullNameAsync(string fullName)
        {
            _response = await _client.GetAsync($"/api/v1/users/fullname/{fullName}");

            var json = await _response.Content.ReadAsStringAsync();
            Users user = JsonConvert.DeserializeObject<Users>(json);
            return user;
        }
        public void Disable(long id, Object dummyObject)
        {
            var dObject = JsonConvert.SerializeObject(dummyObject);
            var buffer = Encoding.UTF8.GetBytes(dObject);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PutAsync($"/api/v1/users/disable/{id}", byteContent);
        }

        public void Enable(long id, Object dummyObject)
        {
            var dObject = JsonConvert.SerializeObject(dummyObject);
            var buffer = Encoding.UTF8.GetBytes(dObject);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PutAsync($"/api/v1/users/enable/{id}", byteContent);
        }
    }
}
