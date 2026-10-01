public class NasabahPrioritas : Rekening
{
    public NasabahPrioritas(string nama, string nomor, decimal saldoAwal)
        : base(nama, nomor, saldoAwal)
    {
    }

    public override void TampilkanInfo()
    {
        Console.WriteLine("Jenis: Prioritas");
        Console.WriteLine($"Nama: {Nama}");
        Console.WriteLine($"Nomor rekening: {NomorRekening}");
        Console.WriteLine($"Saldo: Rp{Saldo:N0}");
    }
}