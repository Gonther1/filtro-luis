using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Querys;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiFiltro.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ClienteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
            var entity = await _unitOfWork.Clientes.GetAllAsync();
            return _mapper.Map<List<Cliente>>(entity);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var entity = await _unitOfWork.Clientes.GetByIdAsync(id);
            return _mapper.Map<Cliente>(entity);
        }

        // 1

        [HttpGet("ClientesConPedidos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClientesYPedidos>>> ClientesConPedidos()
        {
            var entity = await _unitOfWork.Clientes.ClientsWithOrders();
            return _mapper.Map<List<ClientesYPedidos>>(entity);
        }

        // 9

        [HttpGet("ClientePedidoTardio")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClientePedidoTardio>>> ClientePedidoTardio()
        {
            var entity = await _unitOfWork.Clientes.ClientsWithOrderLast();
            return _mapper.Map<List<ClientePedidoTardio>>(entity);
        }
    }
}