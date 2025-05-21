namespace Eksamen2025Gruppe5.Models
{
    public class PollenAPIViewModel
    {
        public string? Code { get; set; }
        public string? DisplayName { get; set; }
        public int Value { get; set; }
        public string? Category { get; set; }
        public string? IndexDescription { get; set; }
        public string? Color { get; set; }   // For enkelhet: vises som f.eks. "R:255, G:0, B:0"
        public string? Date { get; set; }    // Dato for prognosen
    }
}
