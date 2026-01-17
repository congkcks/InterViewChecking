

namespace CS007A_REF_VALUE;

class Program
{

    static void InputData(ref int a,ref int b)
    {
        Console.WriteLine("Enter two integers:");
        a= Convert.ToInt32(Console.ReadLine());
        b= Convert.ToInt32(Console.ReadLine());

    }
    static void TinhTong( int[] numbers)
    {
        int sum = 0;
        foreach (var num in numbers)
        {
            sum += num;
        }
        Console.WriteLine($"Sum: {sum}");
    }
    public class Counter
    {
        public  int Count = 0;

        public Counter()
        {
            Count++;
        }
    }
    public class Config()
    {
        private static string _configvalue;
        public static string ConfigValue
        {
            get { return _configvalue; }
            set { _configvalue = value; }
        }
    }
    abstract class Demo
    { 
        public abstract void Show();
        public abstract void Hide();
        public string Name { get; set; }
        public string Description { get; set; }

    }
    class DemoImplementation : Demo
    {
        public override void Show()
        {
            Console.WriteLine("Show method implementation.");
        }
        public override void Hide()
        {
            Console.WriteLine("Hide method implementation.");
        }
    }
    interface IExample
    {
        void Display();
        int Calculate(int x, int y);
    }
    class ExampleImplementation : IExample
    {
        public void Display()
        {
            Console.WriteLine("Display method implementation.");
        }
        public int Calculate(int x, int y)
        {
            return x + y;
        }
    }
    public class Company
    {
        private string companyName;

        public Company(string name)
        {
            companyName = name;
        }

        // Lớp lồng nhau
        private class Employee
        {
            private string employeeName;
            private int employeeId;

            public Employee(string name, int id)
            {
                employeeName = name;
                employeeId = id;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"Employee Name: {employeeName}, ID: {employeeId}");
            }
        }

        public void AddEmployee(string name, int id)
        {
            Employee employee = new Employee(name, id);
            Console.WriteLine($"Added Employee to {companyName}:");
            employee.DisplayInfo();
        }
    }
    public class DeMo1
    {
        public void show<T,U>(T key,U value)=>
            Console.WriteLine($"Key: {key}, Value: {value}");
    }
    public class Gene<T>
    {
        private T geneData;
        public Gene(T data)
        {
            geneData = data;
        }
        public Gene()
        {
            geneData = default(T);
        }
        public T GetGeneData()
        {
            return geneData;
        }
    }
  
    public delegate bool dele5 (string msg);
    static void InRa(dele5 d5)
    {
        Console.WriteLine(d5("Hello World!"));
    }
    static long multiplication(int a, int b) => a * b;
    static void TinhTong(Func<int,int,int > callback)
    {
        int sum = callback(10,20);
        Console.WriteLine($"Sum: {sum}");
    }
    static public int daubuoi(int a,int b) => a + b;

    static public void ShowUppercase(string msg)=>Console.WriteLine(msg.ToUpper());
    static public void ShowLowercase(string msg)=>Console.WriteLine(msg.ToLower());
    public delegate void DeleEvent(string msg);
    public class Person
    {
        public string name;
        public int id;
        public int age;
        public Person( string name, int age, int id)
        {
            this.name = name;
            this.age = age;
            this.id = id;
        }
    }
    class Animal
    {
        public Animal()
        {
            Console.WriteLine("Animal constructor");
        }
        public virtual void Speak()
        {
            Console.WriteLine("Animal speaks");
        }
    }

    class Dog : Animal
    {
        public Dog()
        {
            Console.WriteLine("Dog constructor");
        }
        public override void Speak()
        {
            Console.WriteLine("Dog barks");
        }
    }
    static void Main(string[] args)
    {
        Dog myDog = new Dog();
        Animal dog = myDog as Animal;
        if (dog != null)
        {
            dog.Speak();
        }
        else
        {
            Console.WriteLine("Conversion failed: myDog is not a Dog.");
        }





    }


}