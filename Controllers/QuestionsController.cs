using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GetQuestions.Data;
using GetQuestions.Models;
using GetQuestions.Services;
using System.Text.Json;


namespace GetQuestions.Controller;

[ApiController]
[Route("[controller]")]
public class QuizController : ControllerBase
{
    private readonly GetQuestionServices _questionServices;

    public static QuestionBase MapToModel(string gebiet, QuestionDto dto)
{
    QuestionBase question = gebiet.ToLower() switch
    {
        "arbeitsrecht" => new Arbeitsrecht(),
        "linux" => new Linux(),
        "projektmanagement" => new Projektmanagement(),
        "cyberphysischesysteme" => new Cyberphysischesysteme(),
        "datenbanken" => new Datenbanken(),
        "firewall" => new Firewall(),
        "ipv4" => new Ipv4(),
        "ipv6" => new Ipv6(),
        "it_sicherheit" => new ItSicherheit(),
        "it_systeme" => new ItSysteme(),
        "kalkulationen" => new Kalkulationen(),
        "marketing" => new Marketing(),
        "organisationslehre" => new Organisationslehre(),
        "programmieren" => new Programmieren(),
        "rechtsformen" => new Rechtsformen(),
        "routing" => new Routing(),
        "tcpip" => new Tcpip(),
        "wiso" => new Wiso(),
        _ => throw new NotSupportedException("Unbekanntes Gebiet")
    };

    question.FRAGE = dto.Frage;
    question.ANTWORT_EINS = dto.Antwort_Eins;
    question.ANTWORT_ZWEI = dto.Antwort_Zwei;
    question.ANTWORT_DREI = dto.Antwort_Drei;
    question.ANTWORT_VIER = dto.Antwort_Vier;
    question.RICHTIGE_ANTWORT = dto.Richtige_Antwort;

    return question;

}

    private readonly HashSet<string> _validGebiete = new(StringComparer.OrdinalIgnoreCase)
    {
        "arbeitsrecht", "cyberphysischesysteme", "datenbanken", "firewall", "ipv4", "ipv6",
        "it_sicherheit", "it_systeme", "kalkulationen", "linux", "marketing", "organisationslehre",
        "programmieren", "projektmanagement", "rechtsformen", "routing", "tcpip", "wiso"
    };

    public QuizController(GetQuestionServices questionServices)
    {
        _questionServices = questionServices;
    }

    [HttpGet]
    public IActionResult GetByGebiet([FromQuery] string gebiet)
    {
        if (string.IsNullOrWhiteSpace(gebiet) || !_validGebiete.Contains(gebiet))
            return BadRequest("Ungültiges Gebiet.");

        var questions = _questionServices.GetAll(gebiet);
        return Ok(questions);
    }

    [HttpPost]
public async Task<IActionResult> AddQuestions([FromQuery] string gebiet, [FromBody] List<QuestionDto> questions)
{
    if (string.IsNullOrWhiteSpace(gebiet) || !_validGebiete.Contains(gebiet))
        return BadRequest("Ungültiges Gebiet.");

    var added = new List<QuestionBase>();

    foreach (var dto in questions)
    {
        try
        {
            var question = MapToModel(gebiet, dto);
            await _questionServices.AddQuestion(gebiet, question);
            added.Add(question);
        }
        catch (Exception ex)
        {
            return BadRequest($"Fehler bei einer Frage: {ex.Message}");
        }
    }

    return Ok(added);
}

}


