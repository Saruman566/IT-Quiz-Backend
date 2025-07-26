using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace GetQuestions.Models;


public class Quest
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

