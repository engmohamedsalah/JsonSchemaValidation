using JsonSchemaValidation.Models;
using Newtonsoft.Json;

namespace JsonSchemaValidation;
public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("JsonSchema Validation!");
        //var file = File.ReadAllText(@"Resources\\unit_judo_v2.json");

        var files =  Directory.GetFiles(@"Resources","*.json");
        foreach (var filepath in files)
        {
            var file = File.ReadAllText(filepath);
            var regexParser = new RegexJsonParser(file);
            Console.WriteLine(filepath);
            regexParser.Parse();
        }
       // var file = File.ReadAllText(@"Resources\\EVT3.json");

        /////DeserializeObject
        //var myDeserializedClass = JsonConvert.DeserializeObject<UunitRoot>(file);


       

        //var JObectParser = new JObjectParser(file);
        //JObectParser.Parse();


    }
}