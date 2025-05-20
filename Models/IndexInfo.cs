namespace Eksamen2025Gruppe5.Models
{
    public class IndexInfo
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        public int DateInfoId { get; set; }
        public DateInfo DateInfo { get; set; }
        public int ColorInfoId { get; set; }
        public ColorInfo ColorInfo { get; set; }
    }
}
