namespace Controller.ViewModels.Node;

using System.ComponentModel.DataAnnotations;

public class NodeViewModelPut
{
    [Required]
    public string Label { get; set; } = null!;
}