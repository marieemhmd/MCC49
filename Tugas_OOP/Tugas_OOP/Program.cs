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
            

            while (true)
            {
                int option = TampilanMenu();
                Bola v = new Bola();
                switch (option)
                {

                    case 1:
                        TambahData(bola);
                        break;
                    case 2:
                        HapusData(bola);
                        break;
                    case 3:
                        TampilData(bola, v);
                        break;

                    default:
                        break;
                }

            }
        }

        private static int TampilanMenu()
        {
            Console.WriteLine("==== MENU ====");
            Console.WriteLine("1. Tambah Data Volume Bola Yang Ingin Dihitung");
            Console.WriteLine("2. Hapus Data Volume Bola");
            Console.WriteLine("3. Tampil Data Volume Bola");
            Console.Write("Input Anda: ");
            int option = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            return option;
        }

        private static void TampilData(List<Bola> bola, Bola v)
        {
            Console.WriteLine("Tampilkan Semua Volume Bola");
            int j = 1;

            foreach (Bola i in bola)
            {
                Console.WriteLine($"Bola ke-{j} | Jari-jari: {i.jariJari}");
                Console.WriteLine($"            Volume: {Convert.ToString(String.Format("{0:0.00}", v.volume(i.jariJari)))}");
                Console.WriteLine();
                j++;
            }
        }

        private static void HapusData(List<Bola> bola)
        {
            Console.Write("Pilih Data: ");
            int pilihHapus = Convert.ToInt32(Console.ReadLine());
            bola.RemoveAt(pilihHapus - 1);
            Console.WriteLine("Hapus Data Berhasil !!!");
            Console.WriteLine();
        }

        private static void TambahData(List<Bola> bola)
        {
            Console.Write("Masukkan jari-jari: ");
            int jariJari = Convert.ToInt32(Console.ReadLine());
            bola.Add(new Bola(jariJari));
            Console.WriteLine("Tambah Data Volume Bola Berhasil !!!");
            Console.WriteLine();
        }
    }
}
