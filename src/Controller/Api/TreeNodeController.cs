namespace Controller.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Controller.Base;
    using Controller.ViewModels.Node;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Repository.Contexts;
    using Repository.Entities;

    [Route("api/trees/{treeUuid}/nodes")]
    public class TreeNodeController : CustomApiControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public TreeNodeController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{nodeUuid}")]
        public async Task<ActionResult<NodeViewModel>> Get(Guid treeUuid, Guid nodeUuid)
        {
            Node node = await _context.Nodes.FirstOrDefaultAsync(p => p.Uuid == nodeUuid && p.TreeId == treeUuid);

            if (node == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<NodeViewModel>(node));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NodeViewModel>>> GetAll(Guid treeUuid)
        {
            List<Node> nodes = await _context.Nodes.Where(p => p.TreeId == treeUuid).ToListAsync();

            return Ok(_mapper.Map<IEnumerable<NodeViewModel>>(nodes));
        }

        [HttpPost]
        public async Task<ActionResult<NodeViewModel>> Create(Guid treeUuid, NodeViewModelPost nodePost)
        {
            Node node = new Node(treeUuid, nodePost.Label);

            _context.Nodes.Add(node);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<NodeViewModel>(node));
        }

        [HttpPut("{uuid}")]
        public async Task<ActionResult<NodeViewModel>> Update(Guid treeUuid, Guid nodeUuid, NodeViewModelPut nodePut)
        {
            Node node = await _context.Nodes.FirstOrDefaultAsync(p => p.Uuid == nodeUuid && p.TreeId == treeUuid);

            if (node == null)
            {
                return NotFound();
            }

            node.Label = nodePut.Label;
            _context.Nodes.Update(node);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<NodeViewModel>(node));
        }

        [HttpDelete("{uuid}")]
        public async Task<IActionResult> Delete(Guid treeUuid, Guid nodeUuid)
        {
            Node node = await _context.Nodes.FirstOrDefaultAsync(p => p.Uuid == nodeUuid && p.TreeId == treeUuid);

            if (node != null)
            {
                _context.Nodes.Remove(node);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}