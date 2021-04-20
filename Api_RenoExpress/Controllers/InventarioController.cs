using Api_RenoExpress.Contexts;
using Api_RenoExpress.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api_RenoExpress.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class InventarioController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly InventarioDBContext inventarioDBContext;
        private readonly IMapper mapper;
        public InventarioController(InventarioDBContext inventarioDBContext, IMapper mapper, IConfiguration configuration)
        {
            this.inventarioDBContext = inventarioDBContext;
            this.mapper = mapper;
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }


        //Obtener inventario de todos los productos se una sucursal
        [HttpGet("{idSucursal}", Name = "GetInventarioSucursal")]
        public async Task<ActionResult<IEnumerable<InventarioDTO>>> Gett(int idSucursal)
        {

            var inventarioProd = await inventarioDBContext.Inventario.Where(x => x.IdSucursal == idSucursal).ToListAsync();
            var inventarioProdDTO = this.mapper.Map<List<InventarioDTO>>(inventarioProd);
            return inventarioProdDTO;
        }




        //Obtener un inventario de un producto en un sucursal especifico
        [HttpGet("{idProducto}/{idSucursal}", Name = "GetProductoSucursal")]
        public async Task<ActionResult<IEnumerable<InventarioDTO>>> Gett(int idProducto, int idSucursal)
        {
      
            var inventarioProd = await inventarioDBContext.Inventario.Where(x => x.IdProducto == idProducto).Where(x => x.IdSucursal == idSucursal).ToListAsync();
            var inventarioProdDTO = this.mapper.Map<List<InventarioDTO>>(inventarioProd);
            return inventarioProdDTO;
        }


        //Obtener todos los registros en tabla inventario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventarioDTO>>> Get()
        {
            var inventario = await inventarioDBContext.Inventario.ToListAsync();
            var inventarioDTO = mapper.Map<List<InventarioDTO>>(inventario);
            return inventarioDTO;
        }


    




    }
}
