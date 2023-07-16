

while (true)
{
    for (int i = 0; i < 100; i++)
    {
        try
        {
            //A? aCAST = (A)ProductCreator.GetInstance(ProductType.A); //Cast sayesinde eğerki tip dönüşümü yapılamazsa Exception fırlatılır.
            A? aAS = ProductCreator.GetInstance(ProductType.A) as A;  // As sayesinde eğer ki tip fönüşümü yapılamazsa null assign edilir exception dan kaçınılmış olunur.
            aAS.Run();

            B? b = ProductCreator.GetInstance(ProductType.A) as B;
            b.Run();

            C? c = ProductCreator.GetInstance(ProductType.A) as C;
            c.Run();
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}

#region Abstract Products
interface IProduct
{
    void Run();
}
#endregion

#region Concrete Products
class A : IProduct
{
    public void Run()
    {
        throw new NotImplementedException();
    }
}
class B : IProduct
{
    public void Run()
    {
        throw new NotImplementedException();
    }
}
class C : IProduct
{
    public void Run()
    {
        throw new NotImplementedException();
    }
}
#endregion

#region Creator
enum ProductType
{
    A, B, C
}

class ProductCreator
{
    static public IProduct GetInstance(ProductType productType)
    {
        IProduct _product = null;

        switch (productType)
        {
            case ProductType.A:
                _product = new A();
                break;
            case ProductType.B:
                _product = new B();
                break;
            case ProductType.C:
                _product = new C();
                break;
            default:
                break;
        }
        return _product;

    }
}
#endregion

/*Factory Design Pattern sayesinde nesneye ihtiyaç olduğu anlarda üretilmesi yerine nesneyi isteme davranışına sahip oluyoruz.
 * 1.Kazanç = böylelikle  üretim maliyetini kodun yazıldığı yerde, ilgili nesneyi ihtiyaç olan noktada üretim maliyetini arındırmış oluyoruz.
   2.Kazanç = Bu üretilen nesneleri
 */