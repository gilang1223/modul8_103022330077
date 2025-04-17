// See https://aka.ms/new-console-template for more information
using System.Numerics;
using modul8_103022330077;
using static modul8_103022330077.Bank_transfer_config;


class Program
{
    static void Main(string[] args)
    {
        Bank_transfer_config config = new Bank_transfer_config();

        if (config.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer:");
            int input  = int.Parse(Console.ReadLine());
            if (input <= config.transfer.threshold) {
                Console.WriteLine($"Low Fee: {config.transfer.low_fee}");
            }
            else if (input > config.transfer.threshold)
            {
                Console.WriteLine($"High Fee: {config.transfer.high_fee}");
            }

        }
        else if (config.lang == "id")
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
            int input = int.Parse(Console.ReadLine());
            if (input <= config.transfer.threshold)
            {
                Console.WriteLine($"Low Fee: {config.transfer.low_fee}");
            }
            else if (input > config.transfer.threshold)
            {
                Console.WriteLine($"High Fee: {config.transfer.high_fee}");
            }
        }
        else
        {
            Console.WriteLine("Language not supported");
        }
        config.transfer.threshold = 1000000;
        config.transfer.low_fee = 5000;
        config.transfer.high_fee = 10000;
        Console.WriteLine($"Threshold: {config.transfer.threshold}");
        Console.WriteLine($"Low Fee: {config.transfer.low_fee}");
        Console.WriteLine($"High Fee: {config.transfer.high_fee}");
    }
}

