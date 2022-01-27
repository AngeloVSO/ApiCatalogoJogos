using ApiCatalogoJogos.Exceptions;
using ApiCatalogoJogos.Models;
using ApiCatalogoJogos.Models.Dto;
using ApiCatalogoJogos.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jogo>>> ObterJogos([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var jogos = await _jogoService.Obter(pagina, quantidade);

            if (jogos.Count() == 0)
                return NoContent();

            return Ok(jogos);
        }

        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<Jogo>> ObterJogoPorId(Guid idJogo)
        {
            var jogo = await _jogoService.Obter(idJogo);

            if (jogo == null)
                return NotFound("Jogo não encontrado em nossa base de dados");

            return Ok(jogo);
        }

        [HttpPost]
        public async Task<ActionResult<Jogo>> InserirJogo([FromBody] JogoDto jogoDto)
        {
            try
            {
                return Ok (await _jogoService.Inserir(jogoDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> AtualizarJogo([FromBody] JogoDto jogoDto, [FromRoute] Guid idJogo)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, jogoDto);

                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarPrecoJogo([FromRoute] double preco, [FromRoute] Guid idJogo)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, preco);

                return Ok();
            }
            catch (JogoNaoCadastradoException)
            {
                return NotFound("O jogo não existe");
            }
        }

        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> DeletarJogo([FromRoute] Guid idJogo)
        {
            try
            {
                await _jogoService.Deletar(idJogo);

                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
