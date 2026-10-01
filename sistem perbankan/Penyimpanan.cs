using System.Text.Json;

public class Penyimpanan
{
    private string file = "dataBank.json";

    public void Simpan(Bank bank)
    {
        List<DataBank> data = new List<DataBank>();

        foreach (Rekening rekening in bank.DaftarRekening)
        {
            string jenis = "Reguler";

            if (rekening is NasabahPrioritas)
            {
                jenis = "Prioritas";
            }

            data.Add(new DataBank
            {
                Nama = rekening.Nama,
                NomorRekening = rekening.NomorRekening,
                Jenis = jenis,
                Saldo = rekening.Saldo,
                Riwayat = rekening.Riwayat
            });
        }

        string json = JsonSerializer.Serialize(
            data,
            new JsonSerializerOptions
            {
                WriteIndented = true
            }
        );

        File.WriteAllText(file, json);

        Console.WriteLine("Data berhasil disimpan!");
    }
}