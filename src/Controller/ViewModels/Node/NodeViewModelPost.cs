namespace Controller.ViewModels.Node;

using System.ComponentModel.DataAnnotations;

public class NodeViewModelPost
{
    [Required]
    public string Label { get; set; } = null!;
}