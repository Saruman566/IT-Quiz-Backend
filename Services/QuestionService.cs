using GetQuestions.Models;
using GetQuestions.Data;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace GetQuestions.Services
{
    public class GetQuestionServices
    {
        private readonly AppDbContext _context;

        private readonly HashSet<string> _validTables = new()
        {
            "arbeitsrecht", "cyberphysischesysteme", "datenbanken", "firewall", "ipv4", "ipv6",
            "it_sicherheit", "it_systeme", "kalkulationen", "linux", "marketing", "organisationslehre",
            "programmieren", "projektmanagement", "rechtsformen", "routing", "tcpip", "wiso"
        };

        public GetQuestionServices(AppDbContext context)
        {
            _context = context;
        }

        public List<Quest> GetAll(string gebiet)
        {
            if (!_validTables.Contains(gebiet.ToLower()))
                throw new ArgumentException("Ungültiger Tabellenname.");

            return _context.Quests
                .FromSqlRaw($"SELECT * FROM `{gebiet}`")
                .ToList();
        }

        public Quest AddQuestion(string gebiet, Quest newQuestion)
        {
            if (!_validTables.Contains(gebiet.ToLower()))
                throw new ArgumentException("Ungültiger Tabellenname.");

            var sql = @$"
                INSERT INTO `{gebiet}` 
                (FRAGE, ANTWORT_EINS, ANTWORT_ZWEI, ANTWORT_DREI, ANTWORT_VIER, RICHTIGE_ANTWORT) 
                VALUES (@frage, @a1, @a2, @a3, @a4, @correct)";

            _context.Database.ExecuteSqlRaw(sql,
                new MySqlParameter("@frage", newQuestion.FRAGE ?? ""),
                new MySqlParameter("@a1", newQuestion.ANTWORT_EINS ?? ""),
                new MySqlParameter("@a2", newQuestion.ANTWORT_ZWEI ?? ""),
                new MySqlParameter("@a3", newQuestion.ANTWORT_DREI ?? ""),
                new MySqlParameter("@a4", newQuestion.ANTWORT_VIER ?? ""),
                new MySqlParameter("@correct", newQuestion.RICHTIGE_ANTWORT ?? "")
            );

            return newQuestion;
        }
    }
}
