using ApiCatalogoJogos.Exceptions;
using ApiCatalogoJogos.Models;
using ApiCatalogoJogos.Models.Dto;
using ApiCatalogoJogos.Repositories;
using PagedList;
using System;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        public async Task<IPagedList<Jogo>> Obter(int pagina, int quantidade)
        {
            return await _jogoRepository.Obter(pagina, quantidade);
        }

        public async Task<Jogo> Obter(Guid id)
        {
            return await _jogoRepository.Obter(id);
        }

        public async Task<Jogo> Inserir(JogoDto jogoDto)
        {
            var jogo = await _jogoRepository.Obter(jogoDto.Nome, jogoDto.Produtora);

            if (jogo != null)
                throw new JogoJaCadastradoException();

            var novoJogo = new Jogo
            {
                Id = Guid.NewGuid(),
                Nome = jogoDto.Nome,
                Produtora = jogoDto.Produtora,
                Preco = jogoDto.Preco
            };

            await _jogoRepository.Inserir(novoJogo);

            return novoJogo;
        }

        public async Task Atualizar(Guid id, JogoDto jogoDto)
        {
            var existeJogo = await _jogoRepository.Obter(id);

            if (existeJogo == null)
                throw new JogoNaoCadastradoException();

            existeJogo.Nome = jogoDto.Nome;
            existeJogo.Produtora = jogoDto.Produtora;
            existeJogo.Preco = jogoDto.Preco;

            await _jogoRepository.Atualizar(existeJogo);
        }

        public async Task Atualizar(Guid id, double preco)
        {
            var existeJogo = await _jogoRepository.Obter(id);

            if (existeJogo == null)
                throw new JogoNaoCadastradoException();

            existeJogo.Preco = preco;

            await _jogoRepository.Atualizar(existeJogo);
        }

        public async Task Deletar(Guid id)
        {
            await _jogoRepository.Deletar(id);
        }


        public void Dispose()
        {
            _jogoRepository?.Dispose();
        }
    }
}
