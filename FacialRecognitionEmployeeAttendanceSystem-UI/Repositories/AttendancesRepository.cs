﻿using FacialRecognitionEmployeeAttendanceSystem_UI.Models;
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
            _response = await _client.GetAsync($"/api/v1/attendances/");

            var json = await _response.Content.ReadAsStringAsync();
            List<Attendances> listAttendances = JsonConvert.DeserializeObject<List<Attendances>>(json);
            return listAttendances;
        }
        public void Add(Attendances attendances)
        {
            var attendance = JsonConvert.SerializeObject(attendances);
            var buffer = Encoding.UTF8.GetBytes(attendance);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PostAsync($"/api/v1/attendances/add", byteContent);
        }
        public void Update(long id, Attendances attendances)
        {
            var attendance = JsonConvert.SerializeObject(attendances);
            var buffer = Encoding.UTF8.GetBytes(attendance);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PutAsync($"/api/v1/attendances/update/{id}", byteContent);
        }
        public async Task<Attendances> GetByIdAsync(long id)
        {
            _response = await _client.GetAsync($"/api/v1/attendances/{id}");

            var json = await _response.Content.ReadAsStringAsync();
            Attendances listAttendances = JsonConvert.DeserializeObject<Attendances>(json);
            return listAttendances;
        }
        public async Task<List<Attendances>> GetByDateTimeAsync(string dateTime)
        {
            _response = await _client.GetAsync($"/api/v1/attendances/datecheck/{dateTime}");

            var json = await _response.Content.ReadAsStringAsync();
            List<Attendances> Attendances = JsonConvert.DeserializeObject<List<Attendances>>(json);
            return Attendances;
        }
        public async Task<List<Attendances>> GetByDateTimeAndUserNameAsync(string dateCheck, long userId)
        {
            _response = await _client.GetAsync($"/api/v1/attendances/userid/{userId}/datecheck/{dateCheck}");

            var json = await _response.Content.ReadAsStringAsync();
            List<Attendances> listAttendances = JsonConvert.DeserializeObject<List<Attendances>>(json);
            return listAttendances;
        }

        public async Task<List<Attendances>> GetByUserIdAsync(long userId)
        {
            _response = await _client.GetAsync($"/api/v1/attendances/userid/{userId}");

            var json = await _response.Content.ReadAsStringAsync();
            List<Attendances> listAttendances = JsonConvert.DeserializeObject<List<Attendances>>(json);
            return listAttendances;
        }

        public void Delete(long id)
        {
            _client.DeleteAsync($"/api/v1/attendances/delete/{id}");
        }

        public void Disable(long id, Object dummyObject)
        {
            var dObject = JsonConvert.SerializeObject(dummyObject);
            var buffer = Encoding.UTF8.GetBytes(dObject);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PutAsync($"/api/v1/attendances/disable/{id}", byteContent);
        }

        public void Enable(long id, Object dummyObject)
        {
            var dObject = JsonConvert.SerializeObject(dummyObject);
            var buffer = Encoding.UTF8.GetBytes(dObject);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PutAsync($"/api/v1/attendances/enable/{id}", byteContent);
        }

        public void CheckIn(Attendances attendances)
        {
            var attendance = JsonConvert.SerializeObject(attendances);
            var buffer = Encoding.UTF8.GetBytes(attendance);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PostAsync($"/api/v1/attendances/checkin", byteContent);
        }

        public void CheckOut(long id, Attendances attendances)
        {
            var attendance = JsonConvert.SerializeObject(attendances);
            var buffer = Encoding.UTF8.GetBytes(attendance);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PutAsync($"/api/v1/attendances/checkout/{id}", byteContent);
        }
    }
}