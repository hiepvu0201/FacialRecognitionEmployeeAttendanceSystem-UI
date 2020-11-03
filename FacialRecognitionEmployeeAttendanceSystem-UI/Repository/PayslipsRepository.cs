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
    }
}
