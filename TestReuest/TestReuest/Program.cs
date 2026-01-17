using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class OrderUpdate
{
    public string ProductName { get; set; }
}

public class Simulation
{
    public static async Task SimulateConcurrentPutRequests()
    {
        string apiUrl = "http://localhost:8082/api/orders/31";

        List<Task> tasks = new List<Task>();
        for (int i = 0; i < 10; i++)
        {
            int requestNumber = i + 1;
            tasks.Add(Task.Run(async () => // Tạo Task cho mỗi request
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        OrderUpdate orderUpdate = new OrderUpdate() { ProductName = "Rau Song"+Convert.ToString(i) };
                        string jsonBody = JsonSerializer.Serialize(orderUpdate);
                        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client.PutAsync(apiUrl, content);

                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();
                            Console.WriteLine($"Request {requestNumber} thành công: {response.StatusCode} - {responseContent}");
                        }
                        else
                        {
                            Console.WriteLine($"Request {requestNumber} thất bại: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi request {requestNumber}: {ex.Message}");
                    }
                }
            }));
        }

        await Task.WhenAll(tasks); // Chờ tất cả các Task hoàn thành
        Console.WriteLine("Đã hoàn thành tất cả các request.");
    }
}

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Bắt đầu giả lập 10 request PUT đồng thời...");
        await Simulation.SimulateConcurrentPutRequests();
        Console.WriteLine("Kết thúc giả lập.");
    }
}
