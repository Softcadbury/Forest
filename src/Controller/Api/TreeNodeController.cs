namespace Controller.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using Controller.Base;
    using Controller.Helpers;
    using Controller.ViewModels.Node;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Repository.Contexts;
    using Repository.Entities;

    [Route("api/trees/{treeId}/nodes")]
    public class TreeNodeController : CustomApiControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public TreeNodeController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{nodeId}")]
        public async Task<ActionResult<NodeViewModel>> Get(Guid treeId, Guid nodeId)
        {
            Node node = await _context.Nodes.FirstOrDefaultAsync(p => p.Id == nodeId && p.TreeId == treeId);

            if (node == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<NodeViewModel>(node));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NodeViewModel>>> GetAll(Guid treeId)
        {
            List<Node> nodes = await _context.Nodes.Where(p => p.TreeId == treeId).ToListAsync();

            return Ok(_mapper.Map<IEnumerable<NodeViewModel>>(nodes));
        }

        [HttpGet("prettyPrint")]
        public async Task<ActionResult<string>> GetPrettyPrint(Guid treeId)
        {
            Tree? tree = await _context.Trees.Where(p => p.Id == treeId).SingleOrDefaultAsync();

            if (tree == null)
            {
                return NotFound();
            }

            var stringBuilder = new StringBuilder();
            NodeHelper.PrettyPrintTree(stringBuilder, tree);

            return Ok(stringBuilder.ToString());
        }

        [HttpPost]
        public async Task<ActionResult<NodeViewModel>> Create(Guid treeId, NodeViewModelPost nodePost)
        {
            Node node = new Node(treeId, nodePost.Label);

            _context.Nodes.Add(node);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<NodeViewModel>(node));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<NodeViewModel>> Update(Guid treeId, Guid nodeId, NodeViewModelPut nodePut)
        {
            Node node = await _context.Nodes.FirstOrDefaultAsync(p => p.Id == nodeId && p.TreeId == treeId);

            if (node == null)
            {
                return NotFound();
            }

            node.Label = nodePut.Label;
            _context.Nodes.Update(node);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<NodeViewModel>(node));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid treeId, Guid nodeId)
        {
            Node node = await _context.Nodes.FirstOrDefaultAsync(p => p.Id == nodeId && p.TreeId == treeId);

            if (node != null)
            {
                _context.Nodes.Remove(node);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}