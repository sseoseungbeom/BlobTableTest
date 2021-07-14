using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Storage.Blobs;

namespace seungbeom.Function
{
    public static class GetJSONData
    {
        [FunctionName("GetJSONData")]
        public static String Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] 
            HttpRequest req, ILogger log, ExecutionContext context)
        {
            string connStrA = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            string requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
             string valueA =  data.a;
                //a가 valueA에 받아져서 requestBody에 넘김

               BlobServiceClient clientA = new BlobServiceClient(connStrA);
               BlobServiceClient containerA = clientA.getBlobContainerClient("sbcon");
               BlobClient blobA = containerA.GetBlobClient(valuesA + ".json"); //안쪽에 파일명
               //BlobClient = 특정파일을 의미

               string responseA = "No Data";

               if(blobA.Exists()) //blobA가존재하면 실행
               {
                   using (MemoryStream msA = new MemoryStream())
                   {
                       blobA.DownloadTo(msA); 
                        responseA = System.Text.Encoding.UTF8.GetString(msA.ToArray());
                   }
               }

            return  responseA;
        }
    }
}
