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

    }
}
