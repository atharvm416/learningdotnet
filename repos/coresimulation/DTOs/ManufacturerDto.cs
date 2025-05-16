namespace coresimulation.DTOs
{
    public class ManufacturerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Website { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
