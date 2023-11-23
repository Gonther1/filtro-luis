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
    public class ProductoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Producto>>> Get()
        {
            var entity = await _unitOfWork.Productos.GetAllAsync();
            return _mapper.Map<List<Producto>>(entity);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Producto>> Get(string id)
        {
            var entity = await _unitOfWork.Productos.GetByIdAsync(id);
            return _mapper.Map<Producto>(entity);
        }

        // 3

        [HttpGet("ProductosSinVender")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductDontSells>>> ProductosSinVender()
        {
            var entity = await _unitOfWork.Productos.GetProductsDontSell();
            return _mapper.Map<List<ProductDontSells>>(entity);
        }
    }
}