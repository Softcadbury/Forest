namespace Controller.Api
{
    using AutoMapper;
    using Common.Misc;
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
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly CurrentContext _currentContext;
        private readonly IMapper _mapper;

        public TreeNodeController(ApplicationDbContext applicationDbContext, CurrentContext currentContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _currentContext = currentContext;
            _mapper = mapper;
        }

        [HttpGet("{nodeId}")]
        public async Task<ActionResult<NodeViewModel>> Get(Guid treeId, Guid nodeId)
        {
            Node? node = await _applicationDbContext.Nodes.FirstOrDefaultAsync(p => p.Id == nodeId && p.TreeId == treeId);

            if (node == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<NodeViewModel>(node));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NodeViewModel>>> GetAll(Guid treeId)
        {
            List<Node> nodes = await _applicationDbContext.Nodes.Where(p => p.TreeId == treeId).ToListAsync();

            return Ok(_mapper.Map<IEnumerable<NodeViewModel>>(nodes));
        }

        [HttpGet("prettyPrint")]
        public async Task<ActionResult<string>> GetPrettyPrint(Guid treeId)
        {
            Tree? tree = await _applicationDbContext.Trees.Where(p => p.Id == treeId).SingleOrDefaultAsync();

            if (tree == null)
            {
                return NotFound();
            }

            return Ok(TreeHelper.PrettyPrintTree(tree));
        }

        [HttpPost]
        public async Task<ActionResult<NodeViewModel>> Create(Guid treeId, NodeViewModelPost nodePost)
        {
            Node node = new Node(_currentContext.TenantId, treeId, nodePost.Label);

            _applicationDbContext.Nodes.Add(node);
            await _applicationDbContext.SaveChangesAsync();

            return Ok(_mapper.Map<NodeViewModel>(node));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<NodeViewModel>> Update(Guid treeId, Guid nodeId, NodeViewModelPut nodePut)
        {
            Node? node = await _applicationDbContext.Nodes.FirstOrDefaultAsync(p => p.Id == nodeId && p.TreeId == treeId);

            if (node == null)
            {
                return NotFound();
            }

            node.Label = nodePut.Label;
            _applicationDbContext.Nodes.Update(node);
            await _applicationDbContext.SaveChangesAsync();

            return Ok(_mapper.Map<NodeViewModel>(node));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid treeId, Guid nodeId)
        {
            Node? node = await _applicationDbContext.Nodes.FirstOrDefaultAsync(p => p.Id == nodeId && p.TreeId == treeId);

            if (node != null)
            {
                _applicationDbContext.Nodes.Remove(node);
                await _applicationDbContext.SaveChangesAsync();
            }

            return Ok();
        }
    }
}