namespace JsonSchemaValidation;

using System;
using System.Diagnostics;



public abstract class ParserBase
{
    protected readonly string _json;

    protected ParserBase(string json)
    {
        _json = json;
    }

    public  long Parse()
    {
        var sw = new Stopwatch();
        sw.Start();
        DoParsing();
        sw.Stop();
        Console.WriteLine($"the parser {this.GetType().Name} take {sw.ElapsedMilliseconds} mileseconds");
        return sw.ElapsedMilliseconds;
    }
    public abstract void DoParsing();
}
