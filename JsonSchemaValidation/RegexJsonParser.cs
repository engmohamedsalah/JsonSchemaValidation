namespace JsonSchemaValidation;

using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;



public class RegexJsonParser : ParserBase
{
    
    //orignial
    //private string _regex_pattern = "(?<=\"" + "\\$schema" + "\"+ *: *\"+).*(?=\")";
    //private string _regex_pattern = "(\\{(.|\n)*(\bschema\b)(.|\n)*}$)";
    //private string _regex_pattern = @"(""\$schema"":)";
    //private string _regex_pattern = @"(\{{1})(.|\n)*(""\$schema"":)";
    //private string _regex_pattern = @"(""[a-zA-Z]*"":\s*{)([^{]|\n)*(""\$schema"")(?=:)(?:\:\s*)([^}]|\n)*(\s})";
    private string _regex_pattern_withoutParent = @"([^{]|\n)*(""\$schema"")(?=:)(?:\:\s*)([^}]|\n)*";
    
   
    
    //this is full 
    //private string _regex_pattern = @"("")([^{])*(\s*"":\s*{)([^{]|\n)*(""\$schema"")(?=:)(?:\:\s*)([^}]|\n)*(\s})";
    
    //this assume the first is the schema
    private string _regex_pattern = @"(""\$schema"")([^}]|\n)*";
    //this ignore the schema maybe or not first element in the json
    //private string _regex_pattern = @"([^{]|\n)*(""\$schema"")([^}]|\n)*";
   
    private RegexOptions _options =  RegexOptions.IgnoreCase;

    public RegexJsonParser(string json) : base(json)
    {
    }

   
    public override void DoParsing()
    {
        //var  matches = Regex.Matches(this._json, this._regex_pattern, this._options);
        //Console.WriteLine(matches.Count);
        //return;
        //var sw = new Stopwatch();
        //sw.Start();
        int cnt = 0;
        foreach (Match m in Regex.Matches(this._json, this._regex_pattern, this._options))
        {
            cnt++;
            //Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            // Console.WriteLine(Uri.IsWellFormedUriString(m.Value, UriKind.RelativeOrAbsolute));
            // Console.WriteLine("found at index {0}.", m.Index);
            var json = JObject.Parse($"{{{m.Value}}}");
            //Console.WriteLine(json["$schema"]);
             Console.WriteLine(Uri.IsWellFormedUriString(json["$schema"].ToString(), UriKind.Absolute));

            //Console.WriteLine("found at index {0}.", m.ValueSpan.ToString());
        }
        Console.WriteLine($"found number of $schema = {cnt}");
        //sw.Stop();
        // sw.ElapsedMilliseconds;

        //var sw2 = new Stopwatch();
        //sw2.Start();
        //foreach (Match m in Regex.Matches(this._json, this._regex_pattern_withoutParent, this._options))
        //{
        //    Console.WriteLine("found at index {0}.", m.Index);
        //}
        //sw2.Stop();
        //Console.WriteLine(sw2.ElapsedMilliseconds);


    }

   
}
