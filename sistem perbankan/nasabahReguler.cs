public class NasabahReguler : Rekening
{
    public NasabahReguler(string nama, string nomor, decimal saldoAwal)
        : base(nama, nomor, saldoAwal)
    {
    }

    public override void TampilkanInfo()
    {
        Console.WriteLine("Jenis: Reguler");
        Console.WriteLine($"Nama: {Nama}");
        Console.WriteLine($"Nomor rekening: {NomorRekening}");
        Console.WriteLine($"Saldo: Rp{Saldo:N0}");
    }
}