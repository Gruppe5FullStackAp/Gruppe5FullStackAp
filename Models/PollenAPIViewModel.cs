namespace Eksamen2025Gruppe5.Models
{
    public class PollenAPIViewModel
    {
        public string? Code { get; set; }
        public string? DisplayName { get; set; }
        public int Value { get; set; }
        public string? Category { get; set; }
        public string? IndexDescription { get; set; }
        public string? Date { get; set; }

        // Color-info (RGB)
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
    }
}
