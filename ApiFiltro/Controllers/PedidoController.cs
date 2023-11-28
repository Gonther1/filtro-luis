using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Querys;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiFiltro.Controllers
{
    public class PedidoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PedidoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Pedido>>> Get()
        {
            var entity = await _unitOfWork.Pedidos.GetAllAsync();
            return _mapper.Map<List<Pedido>>(entity);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pedido>> Get(int id)
        {
            var entity = await _unitOfWork.Pedidos.GetByIdAsync(id);
            return _mapper.Map<Pedido>(entity);
        }

        // 2
        [HttpGet("PedidosTardios-2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PedidosTardios>>> PedidosTardios()
        {
            var entity = await _unitOfWork.Pedidos.GetOrderLate();
            return _mapper.Map<List<PedidosTardios>>(entity);
        }
    }
}