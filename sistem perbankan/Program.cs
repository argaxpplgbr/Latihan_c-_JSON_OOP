
class Program
{
    static void Main()
    {
        Bank bank = new Bank();
        Penyimpanan penyimpanan = new Penyimpanan();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("===== SISTEM PERBANKAN =====");
            Console.WriteLine("1. Buat rekening reguler");
            Console.WriteLine("2. Buat rekening prioritas");
            Console.WriteLine("3. Lihat semua rekening");
            Console.WriteLine("4. Setor uang");
            Console.WriteLine("5. Tarik uang");
            Console.WriteLine("6. Transfer uang");
            Console.WriteLine("7. Riwayat transaksi");
            Console.WriteLine("8. Keluar");
            Console.Write("Pilih menu: ");

            int pilih = int.Parse(Console.ReadLine()!);

            if (pilih == 1 || pilih == 2)
            {
                Console.Write("Nama nasabah: ");
                string nama = Console.ReadLine()!;

                Console.Write("Nomor rekening: ");
                string nomor = Console.ReadLine()!;

                if (bank.CariRekening(nomor) != null)
                {
                    Console.WriteLine("Nomor rekening sudah digunakan");
                    continue;
                }

                Console.Write("Saldo awal: ");
                decimal saldo = decimal.Parse(Console.ReadLine()!);

                if (saldo < 0)
                {
                    Console.WriteLine("Saldo awal tidak boleh negatif");
                    continue;
                }

                if (pilih == 1)
                {
                    bank.TambahRekening(
                        new NasabahReguler(nama, nomor, saldo));
                }
                else
                {
                    bank.TambahRekening(
                        new NasabahPrioritas(nama, nomor, saldo));
                    penyimpanan.Simpan(bank);
                    Console.WriteLine("Rekening berhasil dibuat");
                        
                }
                
            }
            else if (pilih == 3)
            {
                bank.TampilkanSemua();
            }
            else if (pilih >= 4 && pilih <= 7)
            {
                Console.Write("Nomor rekening: ");
                string nomor = Console.ReadLine()!;

                Rekening? rekening = bank.CariRekening(nomor);

                if (rekening == null)
                {
                    Console.WriteLine("Rekening tidak ditemukan");
                    continue;
                }

                if (pilih == 4)
                {
                    Console.Write("Jumlah setor: ");
                    decimal jumlah = decimal.Parse(Console.ReadLine()!);

                    ITransaksi transaksi = rekening;
                    transaksi.Setor(jumlah);
                    penyimpanan.Simpan(bank);
                
                }
                else if (pilih == 5)
                {
                    Console.Write("Jumlah tarik: ");
                    decimal jumlah = decimal.Parse(Console.ReadLine()!);

                    ITransaksi transaksi = rekening;
                    transaksi.Tarik(jumlah);
                    penyimpanan.Simpan(bank);
                
                }
                else if (pilih == 6)
                {
                    Console.Write("Nomor rekening tujuan: ");
                    string nomorTujuan = Console.ReadLine()!;

                    Rekening? tujuan = bank.CariRekening(nomorTujuan);

                    if (tujuan == null)
                    {
                        Console.WriteLine("Rekening tujuan tidak ditemukan");
                        continue;
                    }

                    Console.Write("Jumlah transfer: ");
                    decimal jumlah = decimal.Parse(Console.ReadLine()!);

                    ITransaksi transaksi = rekening;
                    transaksi.Transfer(tujuan, jumlah);
                    penyimpanan.Simpan(bank);
                
                }
                else if (pilih == 7)
                {
                    Console.WriteLine("===== RIWAYAT TRANSAKSI =====");
                    rekening.TampilkanInfo();
                    rekening.TampilkanRiwayat();
                   
                }
            }
            else if (pilih == 8)
            {
                Console.WriteLine("Program selesai");
                return;
            }
            else
            {
                Console.WriteLine("Pilihan tidak tersedia");
            }
        }
    }
}
