using ApiCatalogoJogos.Models;
using ApiCatalogoJogos.Models.Dto;
using PagedList;
using System;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Services
{
    public interface IJogoService : IDisposable
    {
        Task<IPagedList<Jogo>> Obter(int pagina, int quantidade);
        Task<Jogo> Obter(Guid id);
        Task<Jogo> Inserir(JogoDto jogoDto);
        Task Atualizar(Guid id, JogoDto jogoDto);
        Task Atualizar(Guid id, double preco);
        Task Deletar(Guid id);
    }
}
