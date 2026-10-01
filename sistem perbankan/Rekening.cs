public abstract class Rekening : ITransaksi
{
    public string Nama { get; private set; }
    public string NomorRekening { get; private set; }
    public decimal Saldo { get; private set; }

    private List<string> riwayat = new List<string>();

    public List<string> Riwayat
    {
        get
        {
            return riwayat;
        }
    }

    public Rekening(string nama, string nomor, decimal saldoAwal)
    {
        Nama = nama;
        NomorRekening = nomor;
        Saldo = saldoAwal;
    }

    public void Setor(decimal jumlah)
    {
        if (jumlah <= 0)
        {
            Console.WriteLine("Jumlah setor harus lebih dari 0");
            return;
        }

        Saldo += jumlah;
        riwayat.Add($"Setor: +Rp{jumlah:N0}");

        Console.WriteLine("Setor berhasil");
    }

    public bool Tarik(decimal jumlah)
    {
        if (jumlah <= 0)
        {
            Console.WriteLine("Jumlah tarik harus lebih dari 0");
            return false;
        }

        if (jumlah > Saldo)
        {
            Console.WriteLine("Saldo tidak mencukupi");
            return false;
        }

        Saldo -= jumlah;
        riwayat.Add($"Tarik: -Rp{jumlah:N0}");

        Console.WriteLine("Penarikan berhasil");
        return true;
    }

    public bool Transfer(Rekening tujuan, decimal jumlah)
    {
        if (tujuan == null)
        {
            Console.WriteLine("Rekening tujuan tidak ditemukan");
            return false;
        }

        if (tujuan.NomorRekening == NomorRekening)
        {
            Console.WriteLine("Tidak bisa transfer ke rekening sendiri");
            return false;
        }

        if (jumlah <= 0)
        {
            Console.WriteLine("Jumlah transfer harus lebih dari 0");
            return false;
        }

        if (jumlah > Saldo)
        {
            Console.WriteLine("Saldo tidak mencukupi");
            return false;
        }

        Saldo -= jumlah;
        tujuan.Saldo += jumlah;

        riwayat.Add(
            $"Transfer ke {tujuan.NomorRekening}: -Rp{jumlah:N0}");

        tujuan.riwayat.Add(
            $"Transfer dari {NomorRekening}: +Rp{jumlah:N0}");

        Console.WriteLine("Transfer berhasil");
        Console.WriteLine($"Penerima: {tujuan.Nama}");
        Console.WriteLine($"Nominal: Rp{jumlah:N0}");

        return true;
    }

    public void TampilkanRiwayat()
    {
        if (riwayat.Count == 0)
        {
            Console.WriteLine("Belum ada transaksi");
            return;
        }

        foreach (string transaksi in riwayat)
        {
            Console.WriteLine(transaksi);
        }
    }

    public abstract void TampilkanInfo();
}