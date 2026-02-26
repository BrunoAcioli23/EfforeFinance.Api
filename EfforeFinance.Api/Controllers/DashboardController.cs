using System;
using Microsoft.AspNetCore.Mvc;
using EfforeFinance.Api.Repositories;

namespace EfforeFinance.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardRepository _repository;

        public DashboardController(DashboardRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("saldo/{idConta}")]
        public IActionResult ObterSaldo(int idConta)
        {
            try
            {
                var saldo = _repository.ObterSaldoConta(idConta);

                return Ok(new { SaldoAtual = saldo });
            } catch (Exception ex)
            {
                return StatusCode(500, new { Erro = "Erro ao buscar saldo.", Detalhe = ex.Message });
            }
        }

        [HttpGet("resumo/{idUsuario}/{mes}/{ano}")]
        public IActionResult ObterResumo(int idUsuario, int mes, int ano)
        {
            try
            {
                var resumo = _repository.ObterResumoDespesas(idUsuario, mes, ano);

                return Ok(resumo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Erro = "Erro ao buscar resumo de despesas.", Detalhe = ex.Message });
            }
        }
    }
}
