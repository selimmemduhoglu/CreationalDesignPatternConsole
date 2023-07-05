
//new Example();
//new Example();
//new Example();

Example _ex1 = Example.GetInstance;
Example _ex2= Example.GetInstance;
Example _ex3 = Example.GetInstance;

//Burada ne kadar çağırsakta çağıralım sadece bir kere üretilecektir.
class Example
{
    private Example()
    {
        Console.WriteLine($"{nameof(Example)} nesnesi oluşturuldu.");
    }

    static Example _exapmle; //1.yöntem

    static Example() //2.yöntem (Burada static constructor kullanıyoruz bunun amacı ise static constructor sadece 1 kere tetikleniyor ondan sonra tetiklenmiyor.)
    {
        _exapmle = new Example();
    }
    public static Example GetInstance
    {
        get
        {
            #region 1.Yöntem
            if (_exapmle == null)
                _exapmle = new Example();

            return _exapmle;


            #endregion
            #region 2.Yöntem
            return _exapmle;
            #endregion

        }

    }
}

/*Burada Singleton Design Pattern kullanmak için ve yazılımcıya zorunlu kılmak için nesne oluşturma işini
new işlevine bırakmıyoruz ve bu işlevi static bir method sayesinde gerçekleştiriyoruz.*/

/*Bu işlevi static Example etInstance methodu sayesinde eğer ki Example nesnesi oluşmamışsa oluşturuyo eğer
ki nesne hali hazırda varsa direkt onu return ediyor. Bunun içinde static bir şekilde tanımlıyoruz yukarda.*/