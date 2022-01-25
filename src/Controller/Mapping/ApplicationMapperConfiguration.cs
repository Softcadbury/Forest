namespace Controller.Mapping
{
    using AutoMapper;
    using Controller.ViewModels.Node;
    using Controller.ViewModels.Tree;
    using Repository.Entities;

    public class ApplicationMapperConfiguration : Profile
    {
        public ApplicationMapperConfiguration()
        {
            CreateMap<Tree, TreeViewModel>();
            CreateMap<Node, NodeViewModel>();
        }
    }
}