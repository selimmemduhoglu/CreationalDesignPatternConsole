
//#region 1.Yöntem


//var t1 = Task.Run(() =>  //kod satırı asenkron bir işlemi başlatır.
//{
//    Example.GetInstance();
//});
//var t2 = Task.Run(() =>
//{
//    Example.GetInstance();
//});

//await Task.WhenAll(t1, t2); // Task.WhenAll metodu ile birden çok Task'in tamamlanmasını bekler. 



//var t3 = Task.Run(() =>
//{
//    Example.GetInstance();
//});
//var t4 = Task.Run(() =>
//{
//    Example.GetInstance();
//});

//await Task.WhenAll(t3, t4);


//class Example
//{
//    private Example()
//    {
//        Console.WriteLine($"{nameof(Example)} nesnesi oluşturulmuştur.");  
//    }

//    static Example? _example;

//    static object _obj = new object();
//    static public Example GetInstance()
//    {
//        lock(_obj) //kilitleme işlemi burada gerçekleir ka. tane asenkron işlemi çağrılsa dair sadece ilki için bir işlem yapacak ve nesneyi üretecek diğerleri için üretilmeyecek bu sayede asenkron işlmelerde Sİngleton patternini uygulayabilmiş olacağız.
//        {//ifadesi, bir nesnenin eşzamanlı erişimini sınırlamak için kullanılan bir mekanizmadır. //Burada _obj adlı bir nesne kullanılarak kilitlenir. 
//            if (_example == null)
//                _example = new Example();
//            return _example;
//        }

//    }

//}

//#endregion


#region 2.Yöntem 
//Static constructor kullanarak asenkron işlemlerde lock kullanmadan zaten nesne 1 kere üretileceği için daha sade ve gücenli bir işlem yapılmış oluyor.
//Yani asenkron işlemlerin, methodların olduğu durumlarda static contructor kullanmak yani bu 2.işlemi kullanmak daha mantıklı.
List<Task> _tasks = new();

for (int i = 0; i < 100; i++)
{
    _tasks.Add(Task.Run(() =>  //kod satırı asenkron bir işlemi başlatır.
    {
        Example.GetInstance();
    }));
}

await Task.WhenAll(_tasks);

class Example
{
    private Example()
    {
        Console.WriteLine($"{nameof(Example)} nesnesi oluşturulmuştur.");
    }
    static Example()
    {
        _example = new Example();
    }

    static Example? _example;

    static object _obj = new object();
    static public Example GetInstance()
    {
        return _example;

    }
}

#endregion