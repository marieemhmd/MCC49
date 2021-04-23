using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Bola> bola = new List<Bola>();
            bola.Add(new Bola(3));
            bola.Add(new Bola(4));
            bola.Add(new Bola(5));

            int i = 0;
            while (i == 0)
            {
                int option = TampilanMenu();
                Bola volume = new Bola();
                switch (option)
                {
                    case 1:
                        TambahData(bola);
                        break;
                    case 2:
                        HapusData(bola);
                        break;
                    case 3:
                        TampilData(bola, volume);
                        break;
                    case 4:
                        i = Exit(i);
                        break;
                    default:
                        break;
                }
            }
        }

        private static int Exit(int i)
        {
            Console.Write("Apakah Anda yakin ingin keluar? (Y/N) ");
            string option = Console.ReadLine();
            while ((option != "Y") && (option != "y") && (option != "N") && (option != "n"))
            {
                Console.Write("Pilihan yang Anda masukkan salah. Silakan masukkan kembali (Y/y) atau (N/n): ");
                option = Console.ReadLine();
            }

            if ((option == "Y") || (option == "y"))
            {
                i++;
            }
            Console.WriteLine();
            return i;
        }

        private static int TampilanMenu()
        {
            try
            {
                Console.WriteLine("==== MENU ====");
                Console.WriteLine("1. Tambah Data Volume Bola Yang Ingin Dihitung");
                Console.WriteLine("2. Hapus Data Volume Bola");
                Console.WriteLine("3. Tampil Data Volume Bola");
                Console.WriteLine("4. Exit");
                Console.Write("Input Anda: ");
                int option = Convert.ToInt32(Console.ReadLine());
                if ((option <= 0) || (option > 4))
                {
                    Console.Write("Input yang Anda masukkan salah. Masukkan ulang input: ");
                    option = Convert.ToInt32(Console.ReadLine());
                    while((option <= 0) || (option > 4))
                    {
                        Console.Write("Input yang Anda masukkan salah. Masukkan ulang input: ");
                        option = Convert.ToInt32(Console.ReadLine());
                    }
                }
                Console.WriteLine();
                return option;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine();
                return 0;
            }
        }

        private static void TampilData(List<Bola> bola, Bola volume)
        {
            Console.WriteLine("Tampilkan Semua Volume Bola");
            int j = 1;

            foreach (Bola i in bola)
            {
                Console.WriteLine($"Bola ke-{j} | Jari-jari: {i.JariJari}");
                Console.WriteLine($"            Volume: {Convert.ToString(String.Format("{0:0.00}", volume.Volume(i.JariJari)))}");
                Console.WriteLine();
                j++;
            }
        }

        private static void HapusData(List<Bola> bola)
        {
            int i = 0;
            while (i == 0)
            {
                try
                {
                    Console.Write("Pilih Data: ");
                    int pilihHapus = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine($"Apakah Anda yakin ingin menghapus data bola ke-{pilihHapus} dengan jari-jari {bola[pilihHapus-1].JariJari}? (Y/N)");
                    Console.Write("Jawaban Anda: ");
                    string option = Console.ReadLine();
                    Console.WriteLine();

                    while ((option != "Y") && (option != "y") && (option != "N") && (option != "n"))
                    {
                        Console.Write("Pilihan yang Anda masukkan salah. Silakan masukkan kembali (Y/y) atau (N/n): ");
                        option = Console.ReadLine();
                    }

                    if((option == "Y") || (option == "y"))
                    {
                        bola.RemoveAt(pilihHapus - 1);
                        Console.WriteLine("Hapus Data Berhasil !!!");
                        Console.WriteLine();
                        break;
                    }
                    else if((option == "N")||(option == "n"))
                    {
                        Console.WriteLine("Hapus data dibatalkan");
                        Console.WriteLine();
                        break;
                    }
                    i++;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    Console.WriteLine();
                }
            }
        }

        private static void TambahData(List<Bola> bola)
        {
            int i = 0;
            while (i == 0)
            {
                try
                {
                    Console.Write("Masukkan jari-jari: ");
                    int jariJari = Convert.ToInt32(Console.ReadLine());
                    if (jariJari <= 0)
                    {
                        Console.Write("Jari-jari yang Anda masukkan salah. Masukkan kembali jari-jari bernilai positif: ");
                        jariJari = Convert.ToInt32(Console.ReadLine());
                        while (jariJari <= 0)
                        {
                            Console.Write("Jari-jari yang Anda masukkan masih salah. Masukkan kembali jari-jari bernilai positif: ");
                            jariJari = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    bola.Add(new Bola(jariJari));
                    Console.WriteLine();
                    Console.WriteLine("Tambah Data Volume Bola Berhasil !!!");
                    Console.WriteLine();
                    i++;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    Console.WriteLine();
                }
            }
        }
    }
}
