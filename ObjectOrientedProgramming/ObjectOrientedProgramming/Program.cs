using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CodingCamp> codingCamps = new List<CodingCamp>();
            //CodingCamp codingCamp1 = new CodingCamp("MCC-REG-49-NET", "Coding Camp 49");
            //CodingCamp codingCamp2 = new CodingCamp("MCC-REG-48-NET", "Coding Camp 48");
            codingCamps.Add(new CodingCamp("MCC-REG-49-NET", "Coding Camp 49"));
            codingCamps.Add(new CodingCamp("MCC-REG-48-NET", "Coding Camp 48"));
            codingCamps.Add(new CodingCamp("MCC-REG-47-JAVA", "Coding Camp 47"));
            codingCamps.Add(new CodingCamp("MCC-REG-46-JAVA", "Coding Camp 46"));

            while (true)
            {
                TampilMenu();

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        TambahData(codingCamps);
                        break;
                    case 2:
                        HapusData(codingCamps);
                        break;
                    case 3:
                        TampilkanData(codingCamps);
                        break;
                    case 4:
                        TambahParticipant(codingCamps);
                        break;
                    default:
                        break;

                }
            }

            //Console.WriteLine("Coding Camp");
            //foreach(CodingCamp cc in codingCamps)
            //{
            //    Console.WriteLine($"ID : {cc.Id}");
            //    Console.WriteLine($"Name : {cc.Name}");
            //}

            //Console.WriteLine("Coding Camp");
            //Console.WriteLine($"ID : {codingCamp1.Id}");
            //Console.WriteLine($"Name : {codingCamp1.Name}");

            //Console.WriteLine("Coding Camp");
            //Console.WriteLine($"ID : {codingCamp2.Id}");
            //Console.WriteLine($"Name : {codingCamp2.Name}");


        }

        private static void TampilMenu()
        {
            Console.WriteLine("===MENU===");
            Console.WriteLine("1. Tambah data");
            Console.WriteLine("2. Hapus data");
            Console.WriteLine("3. Tampilkan semua data");
            Console.WriteLine("4. Tambah participant");
        }

        private static void TambahParticipant(List<CodingCamp> codingCamps)
        {
            Console.WriteLine("Pilih kelas: ");
            int inputKelas = Convert.ToInt32(Console.ReadLine());
            CodingCamp codingCamp = codingCamps.ElementAt(inputKelas - 1);

            Console.WriteLine($"ID: {codingCamp.Id}");
            Console.WriteLine($"Nama: {codingCamp.Name}");

            Console.WriteLine("INPUT PARTICIPANT");
            Console.WriteLine("NAMA: ");
            string nama = Console.ReadLine();
            Participant participant = new Participant(nama);

            codingCamp.Participants.Add(participant);
            codingCamp.TampilPeserta();
        }

        private static void TampilkanData(List<CodingCamp> codingCamps)
        {
            Console.WriteLine("Tampilkan semua data !!!");
            Console.WriteLine("Coding Camp");
            foreach (CodingCamp cc in codingCamps)
            {
                Console.WriteLine($"ID : {cc.Id}");
                Console.WriteLine($"Name : {cc.Name}");
            }
        }

        private static void HapusData(List<CodingCamp> codingCamps)
        {
            Console.WriteLine("Pilih data: ");
            int pilihHapus = Convert.ToInt32(Console.ReadLine());
            codingCamps.RemoveAt(pilihHapus - 1);
            Console.WriteLine("Hapus data berhasil !!!");
        }

        private static void TambahData(List<CodingCamp> codingCamps)
        {
            Console.WriteLine("Masukkan ID: ");
            string id = Console.ReadLine();
            Console.WriteLine("Masukkan Nama: ");
            string name = Console.ReadLine();

            codingCamps.Add(new CodingCamp(id, name));
            Console.WriteLine("Tambah data berhasil !!!");
        }
    }
}
