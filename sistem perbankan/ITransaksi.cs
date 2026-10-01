public interface ITransaksi
{
    void Setor(decimal jumlah);
    bool Tarik(decimal jumlah);
    bool Transfer(Rekening tujuan, decimal jumlah);
}