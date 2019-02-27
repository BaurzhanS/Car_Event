using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public class EvenetArgs
    {
        public static readonly System.EventArgs Empty;
        public EvenetArgs()
        {

        }
    }

    public class CarEventArgs : EvenetArgs
    {
        public readonly string msg;
        public CarEventArgs(string msg)
        {
            this.msg = msg;
        }
    }


    public delegate void CarEngineHandler(string msgForCaller);
    public class Car
    {
        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;

        public Car()
        {
            MaxSpeed = 100;
        }
        public Car(string Name, int MaxSpeed, int CurrentSpeed)
        {
            this.CurrentSpeed = CurrentSpeed;
            this.MaxSpeed = MaxSpeed;
            this.Name = Name;
        }

        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string Name { get; set; }

        private bool carIsDead;

        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                if (Exploded != null)
                    Exploded.Invoke("Sorry, this car is dead");
            }
            else
            {
                this.CurrentSpeed += delta;
                if (10 == (MaxSpeed - CurrentSpeed) &&
                    AboutToBlow != null)
                    AboutToBlow.Invoke("Careful !!!");

                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("Current speed: {0}", CurrentSpeed);
            }
        }
    }

    public class People
    {
        public void Test()
        {

        }
    }
    //1 Объявили делегат
    public delegate void GetMessage();
    public delegate int Operation(int x, int y);

    public delegate int Sum(int number);

    public delegate int LengthLogin(string s);
    public delegate bool BoolPassword(string s1, string s2);
    class Program
    {
        //2 Создаем переменную делегата
        static GetMessage del;
        //static Operation op;

        static void Main(string[] args)
        {


            return;
            #region
            Sum del1 = SumValue();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Сумма {0} равна: {1}",
                    i, del1.Invoke(i));
            }
    
            CarEngineHandler handler =
                delegate (string msg)
                //(string msg) =>
                {
                    Console.WriteLine("\n------------Message----------\n");
                    Console.WriteLine("--> {0}", msg);
                    Console.WriteLine("------------------------------");
                };
            handler("HOLAAA");

            ShowMessage("HOLAAA", (string msg) => 
            {
                Console.WriteLine(msg);
            }); handler("HOLAAA");

           
            Console.WriteLine("---------");
            Car car = new Car("Volvo", 100, 10);          
            car.Exploded += handler;
            //зарегистрировать событие
            car.AboutToBlow += OnCarEngineEvent;
            
            CarEngineHandler d = new CarEngineHandler(OnCarEngineEvent);
            car.Exploded += d;

            for (int i = 0; i < 6; i++)
            {
                car.Accelerate(20);
            }

            Console.ReadLine();
            //if (DateTime.Now.Hour < 12)
            //{
            //    ShowMessage(GoodMorning);
            //}
            //else
            //{
            //    ShowMessage(GoodEvening);
            //}


            //People p = new People();
            //del = p.Test;

            //Operation op = new Operation(Add);
            //int result = op.Invoke(4, 5);
            //Console.WriteLine(result);

            //op = Multiply;
            //result = op.Invoke(4, 5);
            //Console.WriteLine(result);

            //result = op(4,5);

            //if (DateTime.Now.Hour < 12)
            //{
            //    del = GoodMorning;
            //}
            //else
            //{
            //    del = GoodEvening;
            //}

            //4. Вызов метода
            //del();
            //del.Invoke();
            #endregion

            Console.ReadLine();
        }
        static void SetLogin()
        {
            string login = "110188";
            string login2 = "110188";
            //  public delegate int LengthLogin(string s);
            LengthLogin lengthLoginDelegate = s => s.Length;

            BoolPassword bp = (s1, s2) => { return true; };
            bool result =bp.Invoke("", "");

            LengthLogin lengthLoginDelegate2 = 
                (string s) => { return s.Length; };

            int legthLogin = lengthLoginDelegate.Invoke(login);


        }

        static Sum SumValue()
        {
            int result = 0;

            Sum del = (int number) =>
            {
                for (int i = 0; i < number; i++)
                    result += i;

                return result;
            };

            return del;
        }

        private static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n------------Message----------\n");
            Console.WriteLine("--> {0}", msg);
            Console.WriteLine("------------------------------");
        }

        private static int Add(int x, int y)
        {
            return x + y;
        }
        private static int Multiply(int x, int y)
        {
            return x * y;
        }

        private static void ShowMessage(GetMessage _del)
        {
            _del.Invoke();
        }

        private static void ShowMessage(string msg, CarEngineHandler handler)
        {
            handler.Invoke(msg);
        }


        private static void GoodMorning()
        {
            Console.WriteLine("GoodMorning");
        }
        private static void GoodEvening()
        {
            Console.WriteLine("GoodEvening");
        }

    }
}
