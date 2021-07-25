﻿namespace Controller.Mapping
{
    using AutoMapper;
    using Controller.ViewModels.Node;
    using Controller.ViewModels.Tree;
    using Repository.Entities;

    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<Tree, TreeViewModel>();
            CreateMap<Node, NodeViewModel>();
        }
    }
}