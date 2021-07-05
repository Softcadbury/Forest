namespace Controller.ViewModels.Tree
{
    using System.ComponentModel.DataAnnotations;

    public class TreeViewModelPost
    {
        [Required]
        public string Label { get; set; } = null!;
    }
}