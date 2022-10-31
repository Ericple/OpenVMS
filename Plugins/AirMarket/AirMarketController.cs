using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace OpenVMS.Service.AirMarket;

[ApiController]
[Route("market")]
public class AirMarketController : ControllerBase
{
    private static AirMarketService Service = new AirMarketService();

    [HttpGet]
    public ActionResult<object> Get() => Service.Get();

    [HttpPost("/add")]
    public ActionResult<bool> Add(string identifier,string marketType,float price,string imageUrl,string seller,string info)
    {
        var item = new BsonDocument
        {
            {"Identifier",identifier},
            {"MarketType",marketType},
            {"Price",price},
            {"ImageUrl",imageUrl},
            {"Seller",seller},
            {"Info",info}
        };
        
        Service.Create(item);
        return Ok();
    }
}