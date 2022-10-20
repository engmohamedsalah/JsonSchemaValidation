namespace JsonSchemaValidation;

using Newtonsoft.Json.Linq;
using System;



public class JObjectParser : ParserBase
{

    public JObjectParser(string json) : base(json)
    {
    }

    public override void DoParsing()
    {
        var obj = JObject.Parse(_json);

        RecursionParsing(obj,string.Empty);

    }
    public void RecursionParsing(JObject obj,string rootName)
    {

        foreach (var item in obj.Properties())
        {
            if (item.Name == "$schema")
            {
                Console.WriteLine("==========================");
                Console.WriteLine($"found {rootName}");
                Console.WriteLine(item.Value);
                //Console.WriteLine(obj);
            }
            
            if(item.HasValues)
            {
                if (item.Value.GetType() == typeof(JObject) )
                {
                   
                    RecursionParsing(item.Value.ToObject<JObject>()!,item.Name);
                }
                else if (item.Value.GetType() == typeof(JArray)  )
                {
                    
                    foreach(var o in item.Value)
                    {
                        RecursionParsing((JObject)o,item.Name);
                    }
                }
            }
            

        }
        
    }
}
