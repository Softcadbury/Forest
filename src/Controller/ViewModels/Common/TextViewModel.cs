namespace Controller.ViewModels.Common;

/// <summary>
/// NSwag doesn't seems to handle ActionResult<string> correctly in its generated client
/// ActionResult<TextViewModel> must be used instead
/// </summary>
public class TextViewModel
{
    public TextViewModel(string text)
    {
        Text = text;
    }

    public string Text { get; set; }
}