namespace Controller.Api
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Controller.Base;
    using Controller.ViewModels.Tree;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Repository.Contexts;
    using Repository.Entities;

    [Route("api/trees")]
    public class TreeController : CustomApiControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public TreeController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{treeId}")]
        public async Task<ActionResult<TreeViewModel>> Get(Guid treeId)
        {
            Tree tree = await _context.Trees.FirstOrDefaultAsync(p => p.Id == treeId);

            if (tree == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TreeViewModel>(tree));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TreeViewModel>>> GetAll()
        {
            List<Tree> trees = await _context.Trees.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<TreeViewModel>>(trees));
        }

        [HttpPost]
        public async Task<ActionResult<TreeViewModel>> Create(TreeViewModelPost treePost)
        {
            Tree tree = new Tree(treePost.Label);

            _context.Trees.Add(tree);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<TreeViewModel>(tree));
        }

        [HttpPut("{treeId}")]
        public async Task<ActionResult<TreeViewModel>> Update(Guid treeId, TreeViewModelPut treePut)
        {
            Tree tree = await _context.Trees.FirstOrDefaultAsync(p => p.Id == treeId);

            if (tree == null)
            {
                return NotFound();
            }

            tree.Label = treePut.Label;
            _context.Trees.Update(tree);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<TreeViewModel>(tree));
        }

        [HttpDelete("{treeId}")]
        public async Task<IActionResult> Delete(Guid treeId)
        {
            Tree tree = await _context.Trees.FirstOrDefaultAsync(p => p.Id == treeId);

            if (tree != null)
            {
                _context.Trees.Remove(tree);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}