using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace pluralsightfuncs
{
  public static class OnPaymentReceived
  {
    [FunctionName("OnPaymentReceived")]

    // where MyAppSetting is the name of the application which contains connection string
    // Queue("orders"), Connection="MyAppSetting"

    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, post", Route = null)] HttpRequest req,
            [Queue("orders")] IAsyncCollector<Order> orderQueue,
            ILogger log)
        {
      log.LogInformation("Received a payment");



      string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

      // de-serialize request
      var order = JsonConvert.DeserializeObject<Order>(requestBody);

      // dynamic data = JsonConvert.DeserializeObject(requestBody);

      await orderQueue.AddAsync(order);

      Logger.LogInformation($"Order {order.OrderId} received from {order.Email} for product {order.ProductId}");

      return new OkObjectResult($"Thank you for your purchase");
    }
  }
}
