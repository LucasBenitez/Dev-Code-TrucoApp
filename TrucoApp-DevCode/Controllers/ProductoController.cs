﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.Interfaces;
using System;

namespace Router.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoServicio _productoServicio;

        public ProductoController(IProductoServicio productoServicio)
        {
            _productoServicio = productoServicio;
        }

        [HttpGet]
        [Route("ObtenerProductos")]
        public ActionResult ObtenerProductos()
        {
            try
            {

                return StatusCode(StatusCodes.Status200OK, _productoServicio.GetProductos());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("ObtenerProductoPorId/{idProducto:int}")]
        public ActionResult ObtenerProductoPorId(int idProducto)
        {
            try
            {

                return StatusCode(StatusCodes.Status200OK, _productoServicio.GetProductoPorId(idProducto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("ObtenerColoresPorIdProducto/{idProducto:int}")]
        public ActionResult ObtenerColoresPorIdProducto(int idProducto)
        {
            try
            {

                return StatusCode(StatusCodes.Status200OK, _productoServicio.GetColoresPorIdProducto(idProducto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("ObtenerTallesPorIdProducto/{idProducto:int}")]
        public ActionResult ObtenerTallesPorIdProducto(int idProducto)
        {
            try
            {

                return StatusCode(StatusCodes.Status200OK, _productoServicio.GetTallesPorIdProducto(idProducto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
