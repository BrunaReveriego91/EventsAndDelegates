// See https://aka.ms/new-console-template for more information

namespace EventsAndDelegates
{
    class MyClass
    {
        public delegate double OperacaoMatematicaBinaria(double x, double y);

        public static double Somar(double x, double y)
        {
            double r = x + y;
            Console.WriteLine($"A soma de {x} e {y} é igual a {r}.");
            return r;
        }

        public static double Multiplicar(double x, double y)
        {
            double r = x * y;
            Console.WriteLine($"A multiplicação de {x} e {y} é igual a {r}.");
            return r;
        }

        public static double Potenciar(double x, double y)
        {
            double r = Math.Pow(x, y);
            Console.WriteLine($"A potência de {x} elevado a {y} é igual a {r}.");
            return r;
        }



        static void Main(string[] args)
        {
            //OperacaoMatematicaBinaria op = new OperacaoMatematicaBinaria(Multiplicar);
            //op(20, 10);

            List<OperacaoMatematicaBinaria> operacoes = new List<OperacaoMatematicaBinaria>();
            operacoes.Add(new OperacaoMatematicaBinaria(Somar));
            operacoes.Add(new OperacaoMatematicaBinaria(Multiplicar));
            operacoes.Add(new OperacaoMatematicaBinaria(Potenciar));


            /* Método anônimo não foi declarado previamente */
            /* Método anônimo */
            operacoes.Add(delegate (double a, double b)
            {
                double r = a / b;
                Console.WriteLine($"A divisão de {a} por {b} é igual a {r}.");
                return r;
            });



            foreach (var item in operacoes)
            {
                item(10, 2);
                item(20, 3);
                item(30, 4);
                Console.WriteLine();
            }

            OperacaoMatematicaBinaria opMulticast = Somar;
            opMulticast += Multiplicar;
            opMulticast += Potenciar;
            opMulticast += delegate (double a, double b)
            {
                double r = a / b;
                Console.WriteLine($"A divisão de {a} por {b} é igual a {r}.");
                return r;
            };

            opMulticast(2, 3);

        }
    }
}




