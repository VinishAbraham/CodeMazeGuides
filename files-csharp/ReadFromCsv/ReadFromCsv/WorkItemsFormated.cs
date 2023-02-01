using CsvHelper.Configuration.Attributes;

namespace ReadFromCsv
{
    public class WorkItemsFormated
    {
        [Index(0)]
        public string? Id { get; set; }
        [Index(1)]
        public string? WorkItemType { get; set; }
        [Index(2)]
        public string? Title { get; set; }
        [Index(3)]
        public string? StepsId { get; set; }
        [Index(4)]
        public string? PreConditionSteps { get; set; }
        [Index(5)]
        public string? ActionStep { get; set; }
        [Index(6)]
        public string? ValidationStep { get; set; }
        [Index(7)]
        public string? State { get; set; }
        [Index(8)]
        public string? Tags { get; set; }
    }
}
