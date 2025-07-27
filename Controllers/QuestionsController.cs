using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GetQuestions.Data;
using GetQuestions.Models;
using GetQuestions.Services;
using System.Text.Json;


namespace GetQuestions.Controller;

[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private readonly GetQuestionServices _questionServices;

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
    public async Task<IActionResult> AddQuestion([FromQuery] string gebiet, [FromBody] JsonElement newQuestionJson)
    {
        if (string.IsNullOrWhiteSpace(gebiet) || !_validGebiete.Contains(gebiet))
            return BadRequest("Ungültiges Gebiet.");

        try
        {      
            var type = gebiet.ToLower() switch
            {
                "arbeitsrecht" => typeof(Arbeitsrecht),
                "cyberphysischesysteme" => typeof(Cyberphysischesysteme),
                "datenbanken" => typeof(Datenbanken),
                "firewall" => typeof(Firewall),
                "ipv4" => typeof(Ipv4),
                "ipv6" => typeof(Ipv6),
                "it_sicherheit" => typeof(ItSicherheit),
                "it_systeme" => typeof(ItSysteme),
                "kalkulationen" => typeof(Kalkulationen),
                "linux" => typeof(Linux),
                "marketing" => typeof(Marketing),
                "organisationslehre" => typeof(Organisationslehre),
                "programmieren" => typeof(Programmieren),
                "projektmanagement" => typeof(Projektmanagement),
                "rechtsformen" => typeof(Rechtsformen),
                "routing" => typeof(Routing),
                "tcpip" => typeof(Tcpip),
                "wiso" => typeof(Wiso),
                _ => null
            };

            if (type == null)
                return BadRequest("Ungültiges Gebiet.");

            var newQuestion = (QuestionBase)JsonSerializer.Deserialize(newQuestionJson.GetRawText(), type)!;

            await _questionServices.AddQuestion(gebiet, newQuestion);

            return Ok(newQuestion);
        }
        catch (Exception ex)
        {
            return BadRequest($"Fehler beim Hinzufügen der Frage: {ex.Message}");
        }
    }
}


