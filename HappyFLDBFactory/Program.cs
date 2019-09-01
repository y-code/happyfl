using System;
using Microsoft.Extensions.Configuration;

namespace HappyFL.DBFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new HappyFLDbContextFactory();
            Console.WriteLine("Hello World!");
        }
    }
}
