public class DataBank
{
    public string Nama { get; set; } = "";
    public string NomorRekening { get; set; } = "";
    public string Jenis { get; set; } = "";
    public decimal Saldo { get; set; }

    public List<string> Riwayat {get; set;} = new List<string>();
}