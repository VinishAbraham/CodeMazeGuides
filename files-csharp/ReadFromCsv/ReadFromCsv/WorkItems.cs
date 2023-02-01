using CsvHelper.Configuration.Attributes;

namespace ReadFromCsv
{
    public class WorkItems
    {
        [Index(0)]
        public string? Id { get; set; }
        [Index(1)]
        public string? WorkItemType { get; set; }
        [Index(2)]
        public string? Title { get; set; }
        [Index(3)]
        public string? Steps { get; set; }
        [Index(4)]
        public string? State { get; set; }
        [Index(5)]
        public string? Tags { get; set; }
    }
}
