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
    [ApiController]
    [Route("api/[controller]")]
    public class GamaProductoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GamaProductoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<GamaProducto>>> Get()
        {
            var entity = await _unitOfWork.GamasProductos.GetAllAsync();
            return _mapper.Map<List<GamaProducto>>(entity);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GamaProducto>> Get(string id)
        {
            var entity = await _unitOfWork.GamasProductos.GetByIdAsync(id);
            return _mapper.Map<GamaProducto>(entity);
        }

        // 10

        [HttpGet("GamasProductosCompradas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClientesGamasProductos>>> GamasProductosCompradas()
        {
            var entity = await _unitOfWork.GamasProductos.GamasProductosAndHerClients();
            return _mapper.Map<List<ClientesGamasProductos>>(entity);
        }

        [HttpGet("CustomersGammas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> CustomersGammas()
        {
            var results = await _unitOfWork.GamasProductos.CustomersGammas();

            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }
    }
}