using CsvHelper.Configuration.Attributes;
using System.Xml.Serialization;

namespace ReadFromCsv
{
    public class StepsTemplate
    {
        public int Id { get; set; }

        public int Last { get; set; }

        public List<Step> Step { get; set; }

    }

    public class Step
    {

    public List<ParameterizedString> ParameterizedString { get; set; }

    public object Description { get; set; }

    public int Id { get; set; }
    
    public string Type { get; set; }

    }

    public class ParameterizedString
    {

        public bool Isformatted { get; set; }

        public string Text { get; set; }
    }

}
