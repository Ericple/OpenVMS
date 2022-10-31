namespace OpenVMS.Service.AirMarket.Models;

public class MarketItem
{
    private string Identifier;
    private string MarketType;
    private float Price;
    private string Seller;
    private string ImageUrl;
    private string Info;

    public MarketItem(string identifier, string marketType, float price, string imageUrl, string seller, string info)
    {
        Identifier = identifier;
        MarketType = marketType;
        Price = price;
        ImageUrl = imageUrl;
        Seller = seller;
        Info = info;
    }

    public MarketItem Get()
    {
        return this;
    }
}