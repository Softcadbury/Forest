namespace Controller.Api
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Repository.Contexts;
    using Repository.Entities;

    [ApiController]
    [Route("api/trees")]
    public class TreeController : ControllerBase
    {
        private readonly Context _context;

        public TreeController(Context context)
        {
            _context = context;
        }

        [HttpGet("{uuid}")]
        public async Task<ActionResult<Tree>> Get(Guid uuid)
        {
            Tree tree = await _context.Trees.FirstOrDefaultAsync(p => p.Uuid == uuid);
            return tree != null ? Ok(tree) : NotFound();
        }

        [HttpGet]
        public async Task<IEnumerable<Tree>> GetAll()
        {
            return await _context.Trees.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Tree>> Create(Tree tree)
        {
            // todo - use viewmodel
            _context.Trees.Add(tree);
            await _context.SaveChangesAsync();
            return tree;
        }

        [HttpPut("{uuid}")]
        public async Task<ActionResult<Tree>> Update(Guid uuid, Tree tree)
        {
            Tree treeToUpdate = await _context.Trees.FirstOrDefaultAsync(p => p.Uuid == uuid);

            if (treeToUpdate == null)
            {
                return NotFound();
            }

            // todo - mapping between tree and treeToUpdate
            _context.Trees.Update(tree);
            await _context.SaveChangesAsync();
            return tree;
        }

        [HttpDelete("{uuid}")]
        public async Task<IActionResult> Delete(Guid uuid)
        {
            Tree tree = await _context.Trees.FirstOrDefaultAsync(p => p.Uuid == uuid);

            if (tree != null)
            {
                _context.Trees.Remove(tree);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}