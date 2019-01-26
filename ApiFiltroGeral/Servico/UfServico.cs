using ApiFiltroGeral.Models;
using ApiFiltroGeral.Models.Inputs;
using ApiFiltroGeral.Repositorio;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFiltroGeral.Servico
{
    public class UfServico
    {
        private readonly UfRepositorio _repositorio = new UfRepositorio();

        public async Task<IEnumerable<Uf>> SelecionarAsync()
        {
            return await _repositorio.SelecionarAsync();
        }

        public async Task<IEnumerable<Uf>> SelecionarPorFiltroAsync(FiltroInput obj)
        {
            var entidade = new Filtro()
            {
                CodigoIbge = obj.CodigoIbge,
                Nome = obj.Nome,
                Sigla = obj.Sigla
            };

            if (!entidade.IsValid()) return default(IEnumerable<Uf>);

            var result = await _repositorio.SelecionarPorFiltroAsync(entidade);

            return result;
        }
    }
}
