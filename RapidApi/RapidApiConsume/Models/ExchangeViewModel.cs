namespace RapidApiConsume.Models
{
    public class ExchangeViewModel
    {
        // Burada ki verilere RapidApi sayfasında kullacağımız api tablosundan ulaşırız. Fakat bu api tablomuzda veriler iç içe. Nested yapıda olan bu verileri alabilmek için api sayfasından results kısmından tüm verileri kopyalarız. Sonrasında buraya direkt yapıştırmak yerine sol üstten Edit->Paste special -> Paste JSON as Classes olanı seçeriz ve aşağıdaki gibi çıktıyı alırız.
        public Exchange_Rates[] exchange_rates { get; set; }
        public string base_currency { get; set; }
        public string base_currency_date { get; set; }


        public class Exchange_Rates
        {
            public string exchange_rate_buy { get; set; }
            public string currency { get; set; }
        }

    }
}
