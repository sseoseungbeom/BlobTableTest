using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Cosmos.Table;

namespace seungbeom.Function
{
    public static class WriteTable
    {
        [FunctionName("WriteTable")]
        public static String Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] 
            HttpRequest req, ILogger log, ExecutionContext context)
        {
            string connStrA = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            string requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            string valueA = data.a;

            CloudStorageAccount stoA = CloudStorageAccount.Parse(connStrA);
            CloudTableClient tbC = stoA.CreateCloudTableClient();
            CloudTable tableA = tbC.GetTableReference("tableA");


            return "";

        
        }
    }
}
