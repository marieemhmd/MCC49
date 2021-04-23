using System;

namespace Basic_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            int jumlahBola;
            const double phi = 3.14;
            Console.Write("Masukkan Jumlah Bola: ");
            jumlahBola = Convert.ToInt32(Console.ReadLine());
            if (jumlahBola < 0)
            {
                Console.Write("Input yang Anda masukkan salah. Silakan masukkan kembali input bernilai positif: ");
                jumlahBola = Convert.ToInt32(Console.ReadLine());
                while (jumlahBola < 0)
                {
                    Console.Write("Input yang Anda masukkan masih salah. Silakan masukkan kembali input bernilai positif: ");
                    jumlahBola = Convert.ToInt32(Console.ReadLine());
                }
            }

            int[] jari_jari = new int[jumlahBola];

            for (int i = 0; i < jumlahBola; i++)
            {
                Console.Write($"Input jari-jari bola ke-{i + 1}: ");
                jari_jari[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine($"Volume {jumlahBola} bola telah dihitung. Tekan sembarang untuk melihat hasil.");
            Console.ReadLine();
            Console.Clear();

            for (int i = 0; i < jumlahBola; i++)
            {
                Console.WriteLine($"Bola ke-{i + 1} | Jari-jari  : {jari_jari[i]}");
                Console.WriteLine($"            Volume bola: {VolumeBola(phi, jari_jari[i])}");
            }
        }
        static double VolumeBola(double pi, double r)
        {
            return pi * r * r * r * 4 / 3;
        }
    }
}
