using ApiFiltroGeral.Context;
using ApiFiltroGeral.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFiltroGeral.Repositorio
{
    public class UfRepositorio
    {
        private readonly BuscaContext _context = new BuscaContext();

        public async Task<IEnumerable<Uf>> SelecionarAsync()
        {
            return await _context.Uf.ToListAsync();
        }

        public async Task<IEnumerable<Uf>> SelecionarPorFiltroAsync(Filtro obj)
        {
            var query = _context.Uf.AsQueryable();

            if (obj.CodigoIbge.HasValue && obj.CodigoIbge != 0)
                query = query.Where(x => x.CodigoIbge == obj.CodigoIbge);

            if (!string.IsNullOrEmpty(obj.Nome))
                query = query.Where(x => x.Nome == obj.Nome);

            if (!string.IsNullOrEmpty(obj.Sigla))
                query = query.Where(x => x.Sigla == obj.Sigla);

            var result = await query.ToListAsync();

            return result;

        }
    }
}
