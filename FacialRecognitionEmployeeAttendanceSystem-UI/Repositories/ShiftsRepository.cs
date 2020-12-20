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
    class ShiftsRepository
    {
        public HttpClient _client;
        public HttpResponseMessage _response;
        public ShiftsRepository()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:8080/");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<Shifts>> GetList()
        {
            _response = await _client.GetAsync($"/api/v1/shifts/");

            var json = await _response.Content.ReadAsStringAsync();
            List<Shifts> listShifts = JsonConvert.DeserializeObject<List<Shifts>>(json);
            return listShifts;
        }
        public void Add(Shifts shifts)
        {
            var shift = JsonConvert.SerializeObject(shifts);
            var buffer = Encoding.UTF8.GetBytes(shift);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PostAsync($"/api/v1/shifts/add", byteContent);
        }
        public void Update(long id, Shifts shifts)
        {
            var shift = JsonConvert.SerializeObject(shifts);
            var buffer = Encoding.UTF8.GetBytes(shift);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PutAsync($"/api/v1/shifts/update/{id}", byteContent);
        }
        public async Task<Shifts> GetByIdAsync(long id)
        {
            _response = await _client.GetAsync($"/api/v1/shifts/{id}");

            var json = await _response.Content.ReadAsStringAsync();
            Shifts shift = JsonConvert.DeserializeObject<Shifts>(json);
            return shift;
        }
        public void Delete(long id)
        {
            _client.DeleteAsync($"/api/v1/shifts/delete/{id}");
        }
    }
}