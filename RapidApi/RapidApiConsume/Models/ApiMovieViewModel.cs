namespace RapidApiConsume.Models
{
    public class ApiMovieViewModel
    {
        // Burada tnaımladığımız propertyler rapidapi'den çektiğimiz veriler ile aynı olmalı. Yani api de hangi özellikler varsa onların içerisinden istediğimizi burada tanımlarız. RapidApi sayfasından kullanacağımız api kısmında "results" bölümünden tüm özelliklere ulaşırız. Oradan istediğimizi kullanırız. 
        public int rank { get; set; }
        public string title { get; set; }
        public string rating { get; set; }
        public string trailer { get; set; }
    }
}
