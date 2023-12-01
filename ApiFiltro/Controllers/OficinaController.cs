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
    public class OficinaController : BaseController
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OficinaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Oficina>>> Get()
        {
            var entity = await _unitOfWork.Oficinas.GetAllAsync();
            return _mapper.Map<List<Oficina>>(entity);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Oficina>> Get(string id)
        {
            var entity = await _unitOfWork.Oficinas.GetByIdAsync(id);
            return _mapper.Map<Oficina>(entity);
        }

        [HttpGet("OficinasSinRepresentantesDeVentas-4")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<OficinasSinEmpleados>>> OficinasSinRepresentantesDeVentas()
        {
            var entity = await _unitOfWork.Oficinas.OfficeWithoutRepresentantOfSales();
            return _mapper.Map<List<OficinasSinEmpleados>>(entity);
        }
    }
}