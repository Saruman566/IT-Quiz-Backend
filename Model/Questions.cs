using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace GetQuestions.Models;

public abstract class QuestionBase
{
    [JsonPropertyName("frage")]
    public string? FRAGE { get; set; }

    [JsonPropertyName("antwort_eins")]
    public string? ANTWORT_EINS { get; set; }

    [JsonPropertyName("antwort_zwei")]
    public string? ANTWORT_ZWEI { get; set; }

    [JsonPropertyName("antwort_drei")]
    public string? ANTWORT_DREI { get; set; }

    [JsonPropertyName("antwort_vier")]
    public string? ANTWORT_VIER { get; set; }

    [JsonPropertyName("richtige_antwort")]
    public string? RICHTIGE_ANTWORT { get; set; }
}

public class Arbeitsrecht : QuestionBase { }
public class Cyberphysischesysteme : QuestionBase { }
public class Datenbanken : QuestionBase { }
public class Firewall : QuestionBase { }
public class Ipv4 : QuestionBase { }
public class Ipv6 : QuestionBase { }
public class ItSicherheit : QuestionBase { }
public class ItSysteme : QuestionBase { }
public class Kalkulationen : QuestionBase { }
public class Linux : QuestionBase { }
public class Marketing : QuestionBase { }
public class Organisationslehre : QuestionBase { }
public class Programmieren : QuestionBase { }
public class Projektmanagement : QuestionBase { }
public class Rechtsformen : QuestionBase { }
public class Routing : QuestionBase { }
public class Tcpip : QuestionBase { }
public class Wiso : QuestionBase { }
