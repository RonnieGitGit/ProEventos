using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IPalestranteService
    {
        Task<Palestrante> AddPalestrante(Palestrante model);

        Task<Evento> UpdateEvento(int palestranteId, Palestrante model);

        Task<Evento> DeleteEvento(int id);

        Task<Palestrante[]> GetAllPalestrantesByNomeAsync (string nome, bool includeEventos);

        Task<Palestrante[]> GetAllPalestrantesAsync (bool includeEventos);

        Task<Palestrante> GetPalestranteByIdAsync (int palestranteId, bool includeEventos);

    }
}