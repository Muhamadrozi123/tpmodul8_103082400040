using System;

namespace tpmodul8_103082400047
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Load konfigurasi runtime
            var config = CovidConfig.Load();

            // 2. Input user
            Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
            double suhu = double.Parse(Console.ReadLine().Replace(',', '.'));

            Console.Write("Berapa hari yang lalu(perkiraan) anda terakhir memiliki gejala deman? ");
            int hari = int.Parse(Console.ReadLine());

            // 3. Evaluasi kondisi
            bool suhuValid = config.satuan_suhu.ToLower() == "celcius"
                ? (suhu >= 36.5 && suhu <= 37.5)
                : (suhu >= 97.7 && suhu <= 99.5);

            bool hariValid = hari < config.batas_hari_deman;

            // 4. Output sesuai kondisi
            if (suhuValid && hariValid)
                Console.WriteLine(config.pesan_diterima);
            else
                Console.WriteLine(config.pesan_ditolak);

            // 5. Demo method UbahSatuan
            Console.WriteLine("\n--- Demo Ubah Satuan ---");
            config.UbahSatuan();
            Console.WriteLine($"Satuan suhu sekarang diubah menjadi: {config.satuan_suhu}");

            Console.ReadLine(); // Tahan console
        }
    }
}