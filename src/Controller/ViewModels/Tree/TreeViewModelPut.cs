namespace Controller.ViewModels.Tree;

using System.ComponentModel.DataAnnotations;

public class TreeViewModelPut
{
    [Required]
    public string Label { get; set; } = null!;
}