using FacialRecognitionEmployeeAttendanceSystem_UI.Models.AWS_S3;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Repository
{
    class BucketRepository
    {
        public HttpClient _client;
        public HttpResponseMessage _response;

        public BucketRepository()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:8080/");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public void SaveImage(Buckets buckets)
        {
            var bucket = JsonConvert.SerializeObject(buckets);
            var buffer = Encoding.UTF8.GetBytes(bucket);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PostAsync($"/storage/uploadFile", byteContent);
        }
        public void Delete(Buckets buckets)
        {
            /*var bucket = JsonConvert.SerializeObject(buckets);
            var buffer = Encoding.UTF8.GetBytes(bucket);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.DeleteAsync($"/storage/deleteFile", byteContent);*/
        }
    }
}
