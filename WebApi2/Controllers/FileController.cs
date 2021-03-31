using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi2.DTO;
using WebApi2.ManagementServices;
using Microsoft.AspNetCore.Http;

namespace WebApi2.Controllers
{
    [Route("Pratiche")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IManagementService _managementService;
        public FileController(IManagementService managementService)
        {
            _managementService = managementService;
        }

        [Route("GetPratica/{id:int}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetFileById(int id)
        {
            try
            {
                var f = _managementService.GetFileById(id);
                return f is not null ? Ok(f) : NotFound();
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                return BadRequest(aoore.Message);
            }
        }

        [Route("CreaPratica")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FileDTO> AddFile([FromBody] FileDTO file)
        {
            try
            {
                var addedFile = _managementService.AddFile(file);
                return Created($"GetPratica/{addedFile.ID}", addedFile);
            }
            catch (ArgumentNullException ane)
            {
                return BadRequest(ane.Message);
            }
        }

        [Route("AggiornaPratica")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateFile([FromBody] FileDTO file)
        {
            try
            {
                var updatedFile = _managementService.UpdateFile(file);
                return Ok(updatedFile);
            }
            catch (ArgumentNullException ane)
            {
                return BadRequest(ane.Message);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [Route("CancellaPratica/{id:int}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult DeleteFileById(int id)
        {
            try
            {
                _managementService.DeleteFileById(id);
                return Ok();
            }
            catch(ArgumentOutOfRangeException aoore)
            {
                return BadRequest(aoore.Message);
            }
            catch (InvalidOperationException ioex)
            {
                return Conflict(ioex.Message);
            }
        }

        [Route("AssegnaPratica/{idFile:int}/{idCollector:int}")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<FileCollectorDTO> AssignFile(int idFile, int idCollector)
        {
            try
            {
                var assignedFile = _managementService.AssignFile(idFile, idCollector);
                return Ok(assignedFile);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (InvalidOperationException ioex)
            {
                return Conflict(ioex.Message);
            }
        }

        [Route("CancellaAssegnazione/{idFile:int}/{idCollector:int}")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UnassignFile(int idFile, int idCollector)
        {
            try
            {
                _managementService.UnassignFile(idFile, idCollector);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
