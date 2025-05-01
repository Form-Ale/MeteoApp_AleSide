namespace MeteoApp
{
    public class Entry
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public double Temperature { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public string Weather { get; set; }
        public double Wind { get; set; }
        public double Humidity { get; set; }
        public string Icon { get; set; }
    }
}