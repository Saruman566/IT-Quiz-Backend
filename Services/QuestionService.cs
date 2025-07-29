using GetQuestions.Models;
using GetQuestions.Data;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace GetQuestions.Services
{
    public class GetQuestionServices
    {
        private readonly QuizDbContext _context;

        private readonly Dictionary<string, Func<IEnumerable<QuestionBase>>> _getters;
        private readonly Dictionary<string, Func<QuestionBase, Task>> _adders;

        public GetQuestionServices(QuizDbContext context)
        {
            _context = context;

            _getters = new Dictionary<string, Func<IEnumerable<QuestionBase>>>(StringComparer.OrdinalIgnoreCase)
        {
            { "arbeitsrecht", () => _context.Arbeitsrecht },
            { "cyberphysischesysteme", () => _context.Cyberphysischesysteme },
            { "datenbanken", () => _context.Datenbanken },
            { "firewall", () => _context.Firewall },
            { "ipv4", () => _context.Ipv4 },
            { "ipv6", () => _context.Ipv6 },
            { "it_sicherheit", () => _context.ItSicherheit },
            { "it_systeme", () => _context.ItSysteme },
            { "kalkulationen", () => _context.Kalkulationen },
            { "linux", () => _context.Linux },
            { "marketing", () => _context.Marketing },
            { "organisationslehre", () => _context.Organisationslehre },
            { "programmieren", () => _context.Programmieren },
            { "projektmanagement", () => _context.Projektmanagement },
            { "rechtsformen", () => _context.Rechtsformen },
            { "routing", () => _context.Routing },
            { "tcpip", () => _context.Tcpip },
            { "wiso", () => _context.Wiso }
        };

            _adders = new Dictionary<string, Func<QuestionBase, Task>>(StringComparer.OrdinalIgnoreCase)
        {
            { "arbeitsrecht", q => AddQuestionAsync(_context.Arbeitsrecht, (Arbeitsrecht)q) },
            { "cyberphysischesysteme", q => AddQuestionAsync(_context.Cyberphysischesysteme, (Cyberphysischesysteme)q) },
            { "datenbanken", q => AddQuestionAsync(_context.Datenbanken, (Datenbanken)q) },
            { "firewall", q => AddQuestionAsync(_context.Firewall, (Firewall)q) },
            { "ipv4", q => AddQuestionAsync(_context.Ipv4, (Ipv4)q) },
            { "ipv6", q => AddQuestionAsync(_context.Ipv6, (Ipv6)q) },
            { "it_sicherheit", q => AddQuestionAsync(_context.ItSicherheit, (ItSicherheit)q) },
            { "it_systeme", q => AddQuestionAsync(_context.ItSysteme, (ItSysteme)q) },
            { "kalkulationen", q => AddQuestionAsync(_context.Kalkulationen, (Kalkulationen)q) },
            { "linux", q => AddQuestionAsync(_context.Linux, (Linux)q) },
            { "marketing", q => AddQuestionAsync(_context.Marketing, (Marketing)q) },
            { "organisationslehre", q => AddQuestionAsync(_context.Organisationslehre, (Organisationslehre)q) },
            { "programmieren", q => AddQuestionAsync(_context.Programmieren, (Programmieren)q) },
            { "projektmanagement", q => AddQuestionAsync(_context.Projektmanagement, (Projektmanagement)q) },
            { "rechtsformen", q => AddQuestionAsync(_context.Rechtsformen, (Rechtsformen)q) },
            { "routing", q => AddQuestionAsync(_context.Routing, (Routing)q) },
            { "tcpip", q => AddQuestionAsync(_context.Tcpip, (Tcpip)q) },
            { "wiso", q => AddQuestionAsync(_context.Wiso, (Wiso)q) }
        };
        }

        public IEnumerable<QuestionBase> GetAll(string gebiet)
        {
            if (!_getters.ContainsKey(gebiet))
                throw new ArgumentException("Ungültiger Tabellenname.");

            return _getters[gebiet]().ToList();
        }

        public async Task AddQuestion(string gebiet, QuestionBase newQuestion)
        {
            if (!_adders.ContainsKey(gebiet))
                throw new ArgumentException("Ungültiger Tabellenname.");

            await _adders[gebiet](newQuestion);
            await _context.SaveChangesAsync();
        }

        private async Task AddQuestionAsync<TEntity>(DbSet<TEntity> dbSet, TEntity entity) where TEntity : QuestionBase
        {
            await dbSet.AddAsync(entity);
        }
    
    
    
}


}
