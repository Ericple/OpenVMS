using MongoDB.Bson;
using MongoDB.Driver;
namespace NETVMS.Models;

public class ModelBase
{
    protected string? Table;//Collection Name that contains the model
    protected object? Obj;//The model
    protected BsonObjectId DataBaseID;//Unique identifier in database
    protected readonly MongoClient DataClient = new("mongodb://127.0.0.1:27017/");
    protected string Identifier;//Unique identifier for each instance
    protected string Company;//Indicates who this instance belongs to
    protected int Status;//Indicates the status of this instance - See Enum - [instance type]
}