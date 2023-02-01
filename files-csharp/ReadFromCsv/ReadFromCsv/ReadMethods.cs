using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;

namespace ReadFromCsv
{
    public static class ReadMethods
    {
        public static void ReadWorkItems(string csvPath)
        {
            var readConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                Comment = '#',
                HasHeaderRecord = true
            };

            var writeConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                Comment = '#',
                HasHeaderRecord = false
            };

            var reader = new StreamReader(csvPath);
            var csvReader = new CsvReader(reader, readConfiguration);
            csvReader.Context.RegisterClassMap<WorkItemMap>();
            var workItemsList = csvReader.GetRecords<WorkItems>();


            var PreConditionSteps = "";
            var ActionStep = "";
            var ValidateStep = "";
            
            //Iterates over each csv row of records get column values
            foreach (var workItem in workItemsList)
            {
                    
                Console.WriteLine(workItem.Id);
                var stepsXml = workItem.Steps;


                //////////// XML Section ////////////
                    
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(stepsXml);
                XmlNodeList nodeList = doc.SelectNodes("/steps/step");

                //Loop through the selected Nodes.
                foreach (XmlNode node in nodeList)
                {

                    var stepType = node.Attributes["type"].Value;
                    var stepId = node.Attributes["id"].Value;
                   
                    var stepInnerText = node.InnerText;
                    var stepInnerTextClean = Regex.Replace(stepInnerText, "<.*?>", String.Empty); ;

                   
                    
                    if (stepType == "ActionStep")
                    {
                        string[] separatingStrings = { "<DIV>","<P>","<SPAN" };

                        string[] steps = stepInnerText.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);

                        var stepsClean = Regex.Replace(stepInnerText, "<.*?>", String.Empty); ;
                        PreConditionSteps = stepsClean;
                    }
                    else if (stepType== "ValidateStep")
                    {


                        string[] separatingStrings = { "<DIV>","<P>" };

                        string[] steps = stepInnerText.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);

                        var ActionStepClean = Regex.Replace(steps[0], "<.*?>", String.Empty); ;
                        ActionStep = ActionStepClean;

                        var ValidateStepClean = Regex.Replace(steps[1], "<.*?>", String.Empty); ;
                        ValidateStep = ValidateStepClean;


                    }


                    var workItemsFormattedData= new List<WorkItemsFormated>()
                    {
                        new WorkItemsFormated { Id = workItem.Id, WorkItemType = workItem.WorkItemType, Title = workItem.Title,StepsId = stepId,PreConditionSteps = PreConditionSteps,ActionStep =ActionStep,ValidationStep = ValidateStep,State = workItem.State,Tags = workItem.Tags}

                    };

                    //Write to CSV - New File
                    using var stream = File.Open(@"C:\ADO_Export\Output_TestCases.csv", FileMode.Append);
                    using var writer = new StreamWriter(stream);
                    using (var csvWriter = new CsvWriter(writer, writeConfiguration))
                    {
                        csvWriter.WriteRecords(((IEnumerable<WorkItemsFormated>)workItemsFormattedData));


                    }
                }

                
            }
        }
    }
}
