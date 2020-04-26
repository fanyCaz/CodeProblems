using HelloWorld.Mates;     //trae el scope donde esta declarada esta clase
using System;   //namespace lo traes con using
using System.Linq;

namespace HelloWorld
{
    class Program
    {
        //ENUMS A set of name/value pairs constants
        enum Season     //default values son int
        {                   //a group of related constants
            Spring,
            Summer,
            Autumn,
            Winter
        }

        public enum ShippingMethod
        {       //''pueden ser registros de la db''
            RegularAirMail = 1,
            RegisteredAirMail = 2,
            Express = 3
        }

        //Función local 'private'; se puede usar sin objeto 'static'; no devuelve cosas 'void'
        private static void BasicStuff()
        {
            //BASIC STUFF
            var values = 2;         //var funciona como script, convierte a conveniencia con lo que se declare
            float number = 1.3f;    //4 bytes 1 byte => 8 bits
            decimal numero = 1.2m;  //16 bytes
            //Console.Beep(); //hace un beep que cuqui lel
            Console.WriteLine("Hello World!");
            Console.WriteLine("{0}, {1}: {2}", values, number, numero);

            byte dos = 2;
            int intDos = dos;
            string strDos = "2";
            int intDos2 = Convert.ToInt32(strDos);
            Console.WriteLine("{0}, {1},", intDos2, intDos2);

            var numerito = "1224";
            byte b = 0;
            try
            {
                b = Convert.ToByte(numerito);
            }
            catch (Exception)
            {
                Console.WriteLine("numerito no se pudo convertir a byte");
            }
            Console.WriteLine(b);

            int a = 1;
            int c = ++a;    //a se incrementa primero, y luego se asigna a 'c'
            Console.WriteLine(c);   //the coment should explain why and how and constraints

            //CLASES
            //Como están en el mismo namespace, puedes acceder a ella
            Persona Alicia = new Persona();
            Alicia.firstName = "Alicia";
            Alicia.secondName = "Castillo";
            Alicia.Introduce();

            //podemos usar Add sin hacer otro objeto porque el metodo es estático
            var response = Calculator.Add(2, 5);
            Console.WriteLine(response);

            //ARREGLOS
            Console.WriteLine("Arreglos");
            var numbers = new int[3] { 2, 5, 8 };       //si no lo declaras el valor default es 0
            string strNumbers = string.Join(',', numbers);
            Console.WriteLine(strNumbers);
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            var flags = new bool[3];        //declaras los arrays como var
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(flags[i]);
            }

            string path = "c:\\users";
            string pathV = @"c:\users";     //verbatim string @"xtv\" permite que no toma en cuenta los space chracters
            Console.WriteLine(path);
            Console.WriteLine(pathV);

            //ENUM
            Season spring = Season.Spring;
            Console.WriteLine((int)spring);
            Console.WriteLine((Season)3);

            var method = ShippingMethod.Express;
            int methodId = 2;           //asume que lo traes de la db
            Console.WriteLine(method);
            Console.WriteLine((ShippingMethod)methodId);    //entonces se representa esos records en el codigo
            string methodStr = "RegularAirMail";  //asume que lo traes de la db
            Console.WriteLine(Enum.Parse(typeof(ShippingMethod), methodStr)); //parse un string a un Enum

            //REFERENCE TYPES AND VALUE TYPES
            var aa = 10;
            var bb = aa;
            bb++;
            Console.WriteLine(aa);
            Console.WriteLine(bb);
            var array2 = numbers;
            array2[0] = 432;                            // los array son non-primitype types
            Console.WriteLine(string.Join(',', array2)); //estan apuntando al mismo objeto en memoria
            Console.WriteLine(string.Join(',', numbers));   //por lo tanto, se modifican ambos si uno tiene un cambio
            var numerico = 1;
            numerico = Persona.Increment(numerico);
            Console.WriteLine(numerico);
            Console.WriteLine(numbers.First());
            var personita = new Persona() { age = 20 };
            Persona.MakeOlder(personita);
            Console.WriteLine(personita.age);
        }

        private static void ControlFlowIf()
        {
            //ej 1
            int number = 0;
            Console.WriteLine("Ingresa un numero entre 1 y 10");
            number = Convert.ToInt32( Console.ReadLine() );
            if(number > 0 && number <= 10)
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Invalid");
            }

            //ej2
            Console.WriteLine("Ingresa dos valores, uno enter, dos enter");
            int number1 = Convert.ToInt32(Console.ReadLine());
            int number2 = Convert.ToInt32(Console.ReadLine());
            if(number1 > number2)
            {
                Console.WriteLine("{0} es el mayor", number1);
            }
            else if(number2 > number1)
            {
                Console.WriteLine("{0} es el mayor", number2);
            }
            else
            {
                Console.WriteLine("{0} y {1} son iguales", number1,number2);
            }

            //ej4
            /*speed camera*/
            Console.WriteLine("Ingresa la velocidad Limite");
            int speedLimit = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingresa la velocidad del carro");
            int speedCar = Convert.ToInt32(Console.ReadLine());
            int demeritPoints = 0;
            if(speedCar <= speedLimit)
            {
                Console.WriteLine("Ok");
            }
            else
            {
                demeritPoints = (speedCar - speedLimit) / 5;
                Console.WriteLine("{0} puntos de Demerito",demeritPoints);
            }
            if(demeritPoints > 12)
            {
                Console.WriteLine("Licencia Suspendida");
            }
        }

        private static void ControlFlowCycle()
        {
            string phrase = "you've got the love";  //string is enumerable cuz its an array of characters
            foreach(var letter in phrase)
            {
                Console.WriteLine(letter);
            }
            while (true)
            {
                Console.WriteLine("Type something");
                var input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    break;
                }
            }

            var random = new Random();
            Console.WriteLine(random.Next(97,157));

            //ej5 input 1,2,4 string; output 4; regresa el numero mayor del string
            Console.WriteLine("Ingresa unos numeracos x,g,s,g");
            var inputStr = Console.ReadLine();
            var separation = inputStr.Split(',');
            int max = Convert.ToInt32(separation[0]);
            foreach(var s in separation)
            {
                if (max < Convert.ToInt32(s))
                {
                    max = Convert.ToInt32(s);
                }
            }
            Console.WriteLine(max);
        }
        static void Main(string[] args)
        {
            //BasicStuff();
            //ControlFlowIf();
            //ControlFlowCycle();

        }
    }
}
