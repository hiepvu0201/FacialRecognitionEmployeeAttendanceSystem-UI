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
    class PayslipsRepository
    {
        public HttpClient _client;
        public HttpResponseMessage _response;
        public PayslipsRepository()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:8080/");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<Payslips>> GetList()
        {
            _response = await _client.GetAsync($"/api/v1/payslips/");

            var json = await _response.Content.ReadAsStringAsync();
            List<Payslips> listPayslips = JsonConvert.DeserializeObject<List<Payslips>>(json);
            return listPayslips;
        }
        public async Task<List<Payslips>> GetListByDate(string dateTime)
        {
            _response = await _client.GetAsync($"/api/v1/payslips/datecheck/{dateTime}");

            var json = await _response.Content.ReadAsStringAsync();
            List<Payslips> listPayslips = JsonConvert.DeserializeObject<List<Payslips>>(json);
            return listPayslips;
        }
        public void Add(Payslips payslips)
        {
            var payslip = JsonConvert.SerializeObject(payslips);
            var buffer = Encoding.UTF8.GetBytes(payslip);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PostAsync($"/api/v1/payslips/add", byteContent);
        }
        public void Update(long id, Payslips payslips)
        {
            var payslip = JsonConvert.SerializeObject(payslips);
            var buffer = Encoding.UTF8.GetBytes(payslip);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PutAsync($"/api/v1/payslips/update/{id}", byteContent);
        }
        public async Task<Payslips> GetByIdAsync(long id)
        {
            _response = await _client.GetAsync($"/api/v1/payslips/{id}");

            var json = await _response.Content.ReadAsStringAsync();
            Payslips payslip = JsonConvert.DeserializeObject<Payslips>(json);
            return payslip;
        }

        public void Delete(long id)
        {
            _client.DeleteAsync($"/api/v1/payslips/delete/{id}");
        }

        public void Disable(long id, Object dummyObject)
        {
            var dObject = JsonConvert.SerializeObject(dummyObject);
            var buffer = Encoding.UTF8.GetBytes(dObject);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PutAsync($"/api/v1/payslips/disable/{id}", byteContent);
        }

        public void Enable(long id, Object dummyObject)
        {
            var dObject = JsonConvert.SerializeObject(dummyObject);
            var buffer = Encoding.UTF8.GetBytes(dObject);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PutAsync($"/api/v1/payslips/enable/{id}", byteContent);
        }
    }
}
