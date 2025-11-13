using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.DTOs;
using MyApp.Application.Validators;
using MyApp.Domain.Entities;
using MyApp.Domain.Interfaces;
using System.Collections.Concurrent;
using System.Diagnostics.Contracts;

namespace MyApp.API.Controllers
{
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _repo;
        private readonly IMapper _mapper;
        private readonly ProdutoValidator _validator = new();

        public ProdutoController(IProdutoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var produtos = await _repo.ObterTodosAsync();

            return Ok(_mapper.Map<IEnumerable<ProdutoDTO>>(produtos));
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProdutoDTO produtoDTO)
        {
            var validation = _validator.Validate(produtoDTO);
            if(!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }
            var produto = _mapper.Map<Produto>(produtoDTO);
            await _repo.AdicionarAsync(produto);
            return CreatedAtAction(nameof(GetAll), new { id = produto.Id }, produto);
        }
    }
}
