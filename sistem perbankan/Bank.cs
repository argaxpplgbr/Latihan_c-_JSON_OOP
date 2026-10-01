using System;
using System.Collections.Generic;

public class Bank
{
    private List<Rekening> daftarRekening = new List<Rekening>();

    public List<Rekening> DaftarRekening
    {
        get
        {
            return daftarRekening;
        }
    }

    public void TambahRekening(Rekening rekening)
    {
        daftarRekening.Add(rekening);
    }

    public Rekening? CariRekening(string nomor)
    {
        foreach (Rekening rekening in daftarRekening)
        {
            if (rekening.NomorRekening == nomor)
            {
                return rekening;
            }
        }

        return null;
    }

    public void TampilkanSemua()
    {
        if (daftarRekening.Count == 0)
        {
            Console.WriteLine("Belum ada rekening");
            return;
        }

        foreach (Rekening rekening in daftarRekening)
        {
            rekening.TampilkanInfo();
            Console.WriteLine("-------------------");
        }
    }
}