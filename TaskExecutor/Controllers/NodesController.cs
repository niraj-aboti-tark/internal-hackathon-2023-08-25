using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using TaskExecutor.Models;
using TaskExecutor.Services;

namespace TaskExecutor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodesController : ControllerBase
    {
        private readonly INodeService _nodeService;

        public NodesController(INodeService nodeService)
        {
            _nodeService = nodeService;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult RegisterNode([FromBody] NodeRegistrationRequest node)
        {
            var nodeId = _nodeService.Add(node.Name, node.Address);
            return Ok($"Node added with Id: '{nodeId}'");
        }

        [HttpDelete]
        [Route("unregister/{name}")]
        public IActionResult UnregisterNode(string name)
        {
            _nodeService.Remove(name);
            return Ok();
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetNodes()
        {
            var nodes = _nodeService.Get(x=> true).Select(node => new
            {
                node.Name,
                Status = node.Status.GetDisplayName(),
            });
            return Ok(nodes);
        }
    }
}
