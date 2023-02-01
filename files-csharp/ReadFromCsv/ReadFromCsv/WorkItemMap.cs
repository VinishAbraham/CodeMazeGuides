using CsvHelper.Configuration;
using ReadFromCsv;

public class WorkItemMap : ClassMap<WorkItems> 
{ 
    public WorkItemMap() 
    { 
        Map(p => p.Id).Index(0); 
        Map(p => p.WorkItemType).Index(1); 
        Map(p => p.Title).Index(2);
        Map(p => p.Steps).Index(3);
        Map(p => p.State).Index(4);
        Map(p => p.Tags).Index(5);
    } 
}