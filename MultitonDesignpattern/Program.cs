
var mssql = Database.GetInstance("MSSQL");
var oracle = Database.GetInstance("Oracle");
var mongoDB = Database.GetInstance("mongoDB");
var mssql1 = Database.GetInstance("MSSQL1");
//mssql1.ConnectionString("asdsda"); 
//mssql1.Connection();


var mssql2 = Database.GetInstance("MSSQL");
var oracle2 = Database.GetInstance("Oracle");
var mongoDB2 = Database.GetInstance("mongoDB");
class Database
{
    private Database()
    {
        Console.WriteLine($"{nameof(Database)} nesnesi üretildi");
    }

    static Dictionary<string, Database> _database = new();
    //MultitonDesingPattern kullanabilmek için Disctionary küütphanesini kullanmamız gerekiyor çünkü key,valuye ilişkisine ihtiyacımız var.

    public static Database GetInstance(string key)
    {
        if(!_database.ContainsKey(key))
            _database[key] = new Database();

        return _database[key];
    }
    public void Connection()
    {
        Console.WriteLine("Connected");
    }
    string connectionString = "";
    public static Database GetInstance(string key, string connectionString)
    {
        Database _database = GetInstance(key);
        _database.ConnectionString(connectionString); 
        return _database;
    }
    public void Disconnect()
    {
        Console.WriteLine("Disconnected");
    }

    public void ConnectionString(string connectionString)
    { 

    }

}