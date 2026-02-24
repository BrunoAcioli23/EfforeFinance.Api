using Microsoft.AspNetCore.Mvc;
using EfforeFinance.Api.Models;
using EfforeFinance.Api.Repositories;
using System;

namespace EfforeFinance.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacoesController : ControllerBase
    {
        private readonly TransacaoRepository _repository;

        public TransacoesController(TransacaoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult InserirNovaTransacao([FromBody] Transacao transacao)
        {
            try
            {
                if (transacao == null)
                {
                    return BadRequest("Os dados da transação não podem ser nulos.");
                }

                if (transacao.vlTransacao <= 0)
                {
                    return BadRequest("O valor da transação deve ser maior que zero.");
                }

                int idGerado = _repository.InserirTransacao(transacao);

                return Created(string.Empty, new { Mensagem = "Transação salva com sucesso!", Id = idGerado });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Erro = "Erro interno ao salvar transação.", Detalhe = ex.Message });
            }
        }
    }
}
