using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

public class QuestionDto
{
    public string? Frage { get; set; }
    public string? Antwort_Eins { get; set; }
    public string? Antwort_Zwei { get; set; }
    public string? Antwort_Drei { get; set; }
    public string? Antwort_Vier { get; set; }
    public string? Richtige_Antwort { get; set; }
}


public class Arbeitsrecht : QuestionBase
{ 
    [Key]
    [Column("AID")]
    public int AID { get; set; }
}
public class Cyberphysischesysteme : QuestionBase
{ 
    [Key]
    [Column("CID")]
    public int CID { get; set; }
}
public class Datenbanken : QuestionBase
{ 
    [Key]
    [Column("DID")]
    public int DID { get; set; }
}
public class Firewall : QuestionBase
{
    [Key]
    [Column("FWID")]
    public int FID { get; set; }
 }
public class Ipv4 : QuestionBase
{
    [Key]
    [Column("IP4ID")]
    public int IP4ID { get; set; }
 }
public class Ipv6 : QuestionBase
{
    [Key]
    [Column("IP6ID")]
    public int IP6ID { get; set; }
 }
public class ItSicherheit : QuestionBase
{
    [Key]
    [Column("ITSIID")]
    public int ITSIID { get; set; }
 }
public class ItSysteme : QuestionBase
{ 
    [Key]
    [Column("ITSYID")]
    public int ITSYID { get; set; }
}
public class Kalkulationen : QuestionBase
{
    [Key]
    [Column("KID")]
    public int KID { get; set; }
 }
public class Linux : QuestionBase
{
    [Key]
    [Column("LID")]
    public int LID { get; set; }
 }
public class Marketing : QuestionBase
{ 
    [Key]
    [Column("MID")]
    public int MID { get; set; }
}
public class Organisationslehre : QuestionBase
{ 
    [Key]
    [Column("OID")]
    public int OID { get; set; }
}
public class Programmieren : QuestionBase
{
    [Key]
    [Column("PID")]
    public int PID { get; set; }
 }
public class Projektmanagement : QuestionBase
{
    [Key]
    [Column("PRID")]
    public int PRID { get; set; }
 }
public class Rechtsformen : QuestionBase
{
    [Key]
    [Column("RFID")]
    public int RFID { get; set; }
}
public class Routing : QuestionBase
{
    [Key]
    [Column("RUID")]
    public int RUID { get; set; }
 }
public class Tcpip : QuestionBase
{ 
    [Key]
    [Column("TCPID")]
    public int TCPID { get; set; }
}
public class Wiso : QuestionBase
{
    [Key]
    [Column("WID")]
    public int WID { get; set; }
 }
