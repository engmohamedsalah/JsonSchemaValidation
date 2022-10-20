namespace JsonSchemaValidation.Models;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Athlete
{
    public string id { get; set; }
    public string gender { get; set; }
    public string givenName { get; set; }
    public string familyName { get; set; }
    public Organisation organisation { get; set; }
    public int order { get; set; }
    public Extensions extensions { get; set; }
    public Result result { get; set; }
}

public class Body
{
    public Competition competition { get; set; }
}

public class Competition
{
    public string id { get; set; }
    public string title { get; set; }
    public List<Discipline> disciplines { get; set; }
}

public class Discipline
{
    public string id { get; set; }
    public string title { get; set; }
    public string sportDiscipline { get; set; }
    public List<Event> events { get; set; }
}

public class End
{
    public DateTime datetime { get; set; }
}

public class Event
{
    public string id { get; set; }
    public string title { get; set; }
    public string type { get; set; }
    public string gender { get; set; }
    public string competitorType { get; set; }
    public List<Stage> stages { get; set; }
}

public class ExtendedResult
{
    [JsonProperty("$schema")]
    public string Schema { get; set; }
    public int wazaAri { get; set; }
    public int ippon { get; set; }
    public int yuko { get; set; }
    public int koka { get; set; }
    public int penalty { get; set; }
    public string time { get; set; }
    public string winningTechnique { get; set; }
}

public class Extensions
{
    public Miscellaneous miscellaneous { get; set; }
    public ExtendedResult extendedResult { get; set; }
}

public class Miscellaneous
{
    [JsonProperty("$schema")]
    public string Schema { get; set; }
    public string colour { get; set; }
    public string bodyweight { get; set; }
}

public class Organisation
{
    public string id { get; set; }
    public string country { get; set; }
    public string name { get; set; }
    public string type { get; set; }
}

public class Phase
{
    public string id { get; set; }
    public string title { get; set; }
    public List<Unit> units { get; set; }
}

public class Result
{
    public string value { get; set; }
    public string valueType { get; set; }
    public string wlt { get; set; }
    public Extensions extensions { get; set; }
    public int sortOrder { get; set; }
}

public class UunitRoot
{
    public string type { get; set; }
    public DateTime timestamp { get; set; }
    public string format { get; set; }
    public string source { get; set; }
    public string feedFlag { get; set; }
    public string language { get; set; }
    public Body body { get; set; }
    public DateTime lastUpdate { get; set; }
}

public class Stage
{
    public string id { get; set; }
    public string title { get; set; }
    public string type { get; set; }
    public List<Phase> phases { get; set; }
}

public class Start
{
    public DateTime datetime { get; set; }
}

public class Unit
{
    public string id { get; set; }
    public string title { get; set; }
    public int order { get; set; }
    public Start start { get; set; }
    public End end { get; set; }
    public string status { get; set; }
    public string scheduleStatus { get; set; }
    public List<Athlete> athletes { get; set; }
}


