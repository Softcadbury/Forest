namespace Controller.ViewModels.Resources
{
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;
    using global::Resources;
    using Microsoft.Extensions.Localization;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public class ResourcesViewModel
    {
        public ResourcesViewModel(IStringLocalizer<SharedResource> stringLocalizer)
        {
            foreach (PropertyInfo property in typeof(ResourcesViewModel).GetProperties())
            {
                string value = (string?)stringLocalizer[property.Name] ?? property.Name;
                property.SetValue(this, value);
            }
        }

        [Required]
        public string Common_Add { get; set; }

        [Required]
        public string Common_Trees { get; set; }

        [Required]
        public string Common_Label { get; set; }
    }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}