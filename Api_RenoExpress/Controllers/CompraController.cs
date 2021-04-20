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
    public class CompraController
    {

        private readonly string _connectionString;
        private readonly InventarioDBContext inventarioDBContext;
        private readonly IMapper mapper;
        public CompraController(InventarioDBContext inventarioDBContext, IMapper mapper, IConfiguration configuration)
        {
            this.inventarioDBContext = inventarioDBContext;
            this.mapper = mapper;
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }


        [HttpGet("{id}", Name = "GetCompra")]
        public async Task<ActionResult<CompraDTO>> Get(int id)
        {
            var compra = await this.inventarioDBContext.Compra
                .FirstOrDefaultAsync(x => x.IdCompra.Equals(id));

            if (compra == null)
            {
                return NotFound();
            }
            var compraDTO = this.mapper.Map<CompraDTO>(compra);
            return compraDTO;
        }

        private ActionResult<CompraDTO> NotFound()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CompraDetCreacionDTO compraCreacion)
        {

            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_Compra", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NoDocumento", compraCreacion.NoDocumento));
                    cmd.Parameters.Add(new SqlParameter("@FechaCompra", compraCreacion.FechaCompra));
                    cmd.Parameters.Add(new SqlParameter("@IdProveedor", compraCreacion.IdProveedor));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", compraCreacion.Cantidad));
                    cmd.Parameters.Add(new SqlParameter("@PrecioTotal", compraCreacion.PrecioTotal));
                    cmd.Parameters.Add(new SqlParameter("@IdProducto", compraCreacion.IdProducto));
                    cmd.Parameters.Add(new SqlParameter("@IdSucursal", compraCreacion.IdSucursal));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return new CreatedAtRouteResult("GetCompra", new { id = compraCreacion });
                }
            }
        }





    }
}
