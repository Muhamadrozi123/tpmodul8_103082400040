using System;
using System.IO;
using System.Text.Json;

namespace tpmodul8_103082400047
{
    public class CovidConfig
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_deman { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        private const string CONFIG_FILE = "covid_config.json";

        // Load konfigurasi dari file, atau gunakan default jika file tidak ada
        public static CovidConfig Load()
        {
            if (!File.Exists(CONFIG_FILE))
            {
                return new CovidConfig
                {
                    satuan_suhu = "celcius",
                    batas_hari_deman = 14,
                    pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                    pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini"
                };
            }

            string json = File.ReadAllText(CONFIG_FILE);
            return JsonSerializer.Deserialize<CovidConfig>(json);
        }

        // Method untuk mengganti satuan suhu
        public void UbahSatuan()
        {
            if (satuan_suhu.ToLower() == "celcius")
                satuan_suhu = "fahrenheit";
            else
                satuan_suhu = "celcius";
        }
    }
}