using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GetQuestions.Data;
using GetQuestions.Models;

namespace GetQuestions.Controller;

[ApiController]
[Route("api/[controller]")]
public class QuestController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly HashSet<string> _validTables = new()
    {
        "arbeitsrecht", "cyberphysischesysteme", "datenbanken", "firewall", "ipv4", "ipv6",
        "it_sicherheit", "it_systeme", "kalkulationen", "linux", "marketing", "organisationslehre",
        "programmieren", "projektmanagement", "rechtsformen", "routing", "tcpip", "wiso"
    };

    public QuestController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetByGebiet([FromQuery] string gebiet)
{
    if (!_validTables.Contains(gebiet.ToLower()))
        return BadRequest("Ungültiges Gebiet.");

    var sql = $@"
        SELECT FRAGE, ANTWORT_EINS, ANTWORT_ZWEI, ANTWORT_DREI, ANTWORT_VIER, RICHTIGE_ANTWORT 
        FROM `{gebiet}`";

    var quests = _context.Set<Quest>()
        .FromSqlRaw(sql)
        .ToList();

    return Ok(quests);
}

    [HttpPost]
    public IActionResult AddQuest([FromQuery] string gebiet, [FromBody] Quest quest)
    {
        if (!_validTables.Contains(gebiet.ToLower()))
            return BadRequest("Ungültiges Gebiet.");

        var sql = @$"
            INSERT INTO `{gebiet}` 
            (FRAGE, ANTWORT_EINS, ANTWORT_ZWEI, ANTWORT_DREI, ANTWORT_VIER, RICHTIGE_ANTWORT) 
            VALUES (@frage, @a1, @a2, @a3, @a4, @correct)";

        _context.Database.ExecuteSqlRaw(sql,
            new MySql.Data.MySqlClient.MySqlParameter("@frage", quest.FRAGE ?? ""),
            new MySql.Data.MySqlClient.MySqlParameter("@a1", quest.ANTWORT_EINS ?? ""),
            new MySql.Data.MySqlClient.MySqlParameter("@a2", quest.ANTWORT_ZWEI ?? ""),
            new MySql.Data.MySqlClient.MySqlParameter("@a3", quest.ANTWORT_DREI ?? ""),
            new MySql.Data.MySqlClient.MySqlParameter("@a4", quest.ANTWORT_VIER ?? ""),
            new MySql.Data.MySqlClient.MySqlParameter("@correct", quest.RICHTIGE_ANTWORT ?? "")
        );

        return Ok(quest);
    }
}
