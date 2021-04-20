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
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api_RenoExpress.Controllers
{
    [Route("Api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VentaController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly InventarioDBContext inventarioDBContext;
        private readonly IMapper mapper;
        public VentaController(InventarioDBContext inventarioDBContext, IMapper mapper, IConfiguration configuration)
        {
            this.inventarioDBContext = inventarioDBContext;
            this.mapper = mapper;
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }


        [HttpGet("{id}", Name = "GetVenta")]
        public async Task<ActionResult<VentaDTO>> Get(int id)
        {
            var venta = await this.inventarioDBContext.Venta
                .FirstOrDefaultAsync(x => x.IdVenta.Equals(id));

            if (venta == null)
            {
                return NotFound();
            }
            var ventaDTO = this.mapper.Map<VentaDTO>(venta);
            return ventaDTO;
        }

        private ActionResult<VentaDTO> NotFound()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VentaDetCreacionDTO ventaCreacion)
        {

            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_Venta", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NoFactura ", ventaCreacion.NoFactura));
                    cmd.Parameters.Add(new SqlParameter("@FechaVenta ", ventaCreacion.FechaVenta));
                    cmd.Parameters.Add(new SqlParameter("@IdSucursal", ventaCreacion.IdSucursal));
                    cmd.Parameters.Add(new SqlParameter("@IdCliente", ventaCreacion.IdCliente));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", ventaCreacion.Cantidad));
                    cmd.Parameters.Add(new SqlParameter("@SubTotal", ventaCreacion.SubTotal));
                    //cmd.Parameters.Add(new SqlParameter("@IdVenta", ventaCreacion.IdVenta));
                    cmd.Parameters.Add(new SqlParameter("@IdProducto", ventaCreacion.IdProducto));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return new CreatedAtRouteResult("GetVenta", new { id = ventaCreacion });
                }
            }
        }




    }
}
