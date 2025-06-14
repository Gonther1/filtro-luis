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
    public class EmpleadoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmpleadoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Empleado>>> Get()
        {
            var entity = await _unitOfWork.Empleados.GetAllAsync();
            return _mapper.Map<List<Empleado>>(entity);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Empleado>> Get(int id)
        {
            var entity = await _unitOfWork.Empleados.GetByIdAsync(id);
            return _mapper.Map<Empleado>(entity);
        }

        // 6

        [HttpGet("ClientesAndOficinas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmpleadosYOficina>>> ClientesAndOficinas()
        {
            var entity = await _unitOfWork.Empleados.GetEmployessDontRepresentant();
            return _mapper.Map<List<EmpleadosYOficina>>(entity);
        }
    }
}