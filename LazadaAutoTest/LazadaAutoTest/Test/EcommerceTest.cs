using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


[TestFixture]
public class EcommerceTests
{
    private IWebDriver driver;
    private LazadaPage lazada;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        lazada = new LazadaPage(driver);
    }

    [Test]
    public void SearchIPhone16AndComparePrices()
    {
        var searchTerm = "iPhone 16";

        // Lazada Test
        lazada.Search(searchTerm);
        var lazadaProducts = lazada.GetProducts().Where(p => p.Name.ToLower().Contains("iphone 16")).ToList();
        Assert.IsTrue(lazadaProducts.Any(), "No iPhone 16 found on Lazada");
        //export to product.txt
        double minLazadaPrice = lazadaProducts.Min(p => p.Price);
        
        using (var writer = new System.IO.StreamWriter("product.txt", true))
        {
            foreach (var product in lazadaProducts)
            {
                writer.WriteLine($"{product.Website}: {product.Name} - {product.Price} - {product.Link}");
            }
        }



    }

    [TearDown]
    public void TearDown()
    {
        driver?.Dispose();
    }
}