﻿namespace Controller.Api;

using AutoMapper;
using Common.Misc;
using Controller.Base;
using Controller.ViewModels.Tree;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using Repository.Entities;

[Route("api/trees")]
public class TreeController : CustomApiControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly CurrentContext _currentContext;
    private readonly IMapper _mapper;

    public TreeController(ApplicationDbContext applicationDbContext, CurrentContext currentContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _currentContext = currentContext;
        _mapper = mapper;
    }

    [HttpGet("{treeId}")]
    public async Task<ActionResult<TreeViewModel>> Get(Guid treeId)
    {
        Tree? tree = await _applicationDbContext.Trees.FirstOrDefaultAsync(p => p.Id == treeId);

        if (tree == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<TreeViewModel>(tree));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TreeViewModel>>> GetAll()
    {
        List<Tree> trees = await _applicationDbContext.Trees.OrderByDescending(p => p.CreationDate).ToListAsync();

        return Ok(_mapper.Map<IEnumerable<TreeViewModel>>(trees));
    }

    [HttpPost]
    public async Task<ActionResult<TreeViewModel>> Create(TreeViewModelPost treePost)
    {
        Tree tree = new Tree(_currentContext.TenantId, treePost.Label);

        _applicationDbContext.Trees.Add(tree);
        await _applicationDbContext.SaveChangesAsync();

        return Ok(_mapper.Map<TreeViewModel>(tree));
    }

    [HttpPut("{treeId}")]
    public async Task<ActionResult<TreeViewModel>> Update(Guid treeId, TreeViewModelPut treePut)
    {
        Tree? tree = await _applicationDbContext.Trees.FirstOrDefaultAsync(p => p.Id == treeId);

        if (tree == null)
        {
            return NotFound();
        }

        tree.Label = treePut.Label;
        _applicationDbContext.Trees.Update(tree);
        await _applicationDbContext.SaveChangesAsync();

        return Ok(_mapper.Map<TreeViewModel>(tree));
    }

    [HttpDelete("{treeId}")]
    public async Task<IActionResult> Delete(Guid treeId)
    {
        Tree? tree = await _applicationDbContext.Trees.FirstOrDefaultAsync(p => p.Id == treeId);

        if (tree != null)
        {
            _applicationDbContext.Trees.Remove(tree);
            await _applicationDbContext.SaveChangesAsync();
        }

        return Ok();
    }
}