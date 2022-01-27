using ApiCatalogoJogos.Data;
using ApiCatalogoJogos.Exceptions;
using ApiCatalogoJogos.Models;
using PagedList;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        
        private ApiCatalogoJogosContext _context;

        public JogoRepository(ApiCatalogoJogosContext context)
        {
            _context = context;
        }

        public async Task<IPagedList<Jogo>> Obter(int pagina, int quantidade)
        {
            return _context.Jogos.ToPagedList(pagina, quantidade) ;
        }

        public async Task<Jogo> Obter(Guid id)
        {
            var jogo = await _context.Jogos.FindAsync(id);

            if (jogo == null)
                return null;

            return jogo;
        }
        public async Task<Jogo> Obter(string nome, string produtora)
        {
            var jogo = _context.Jogos.Where(j => j.Nome.Equals(nome) && j.Produtora.Equals(produtora)).FirstOrDefault();
            return jogo;
        }

        public async Task Inserir(Jogo jogo)
        {
            _context.Jogos.Add(jogo);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Jogo jogo)
        {
            _context.Jogos.Update(jogo);
            await _context.SaveChangesAsync();
        }

       
        public async Task Deletar(Guid id)
        {
            var jogo = await _context.Jogos.FindAsync(id);
            
            if (jogo == null)
                throw new JogoNaoCadastradoException();

            _context.Jogos.Remove(jogo);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
