using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();

public class IPNRequest
{
    public string RequestId { get; set; }
    public string OrderId { get; set; }
    public string Amount { get; set; }
    public string Tip { get; set; }
    public string PaymentType { get; set; }
    public string Narrative { get; set; }
    public string FromAccNo { get; set; }
    public Dictionary<string, string> ExtraData { get; set; }
}

public class IPNResponse
{
    public string Code { get; set; }
    public string Message { get; set; }
}

[ApiController]
[Route("ipn")]
public class IPNController : ControllerBase
{
    [HttpPost]
    public ActionResult<IPNResponse> IPNNotification([FromBody] IPNRequest request)
    {
        Task.Run(() => ProcessIPN(request));
        return Ok(new IPNResponse { Code = "00", Message = "success" });
    }

    private void ProcessIPN(IPNRequest request)
    {
        Thread.Sleep(1000); // Simulate processing delay
        Console.WriteLine("Processing IPN: " + request.OrderId);
    }
}
