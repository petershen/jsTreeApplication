using jsTreeApplication.Models;
using jsTreeApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jsTreeApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeDataController : ControllerBase
    {
        private readonly IRepository _repositiry;

        public TreeDataController(IRepository repositiry)
        {
            _repositiry = repositiry;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _repositiry.GetTreeNodes());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm]TreeNode treeNode)
        {
            treeNode.Id = Guid.NewGuid().ToString("N");

            try
            {
                return Ok(await _repositiry.AddTreeNode(treeNode));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                return Ok(await _repositiry.DeleteTreeNode(id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromForm] TreeNode treeNode)
        {
            try
            {
                return Ok(await _repositiry.UpdateTreeNode(treeNode));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
