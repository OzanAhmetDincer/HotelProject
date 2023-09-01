namespace HotelProject.WebUI.Models.Staff
{
    public class StaffViewModel
    {
        // Consume ettiğimiz zaman json'daki datalar ile entity'deki dataların property'leri bire bir aynı olmalı. Ana ksımda neyi listelemek istersek burada onları tanımlayacaz
        public int StaffID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
