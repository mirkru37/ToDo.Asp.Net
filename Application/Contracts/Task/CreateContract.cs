using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Domain;

namespace Application.Contracts.Task;

public class CreateContract
{
    public string? Id { get; set; }
    [Required]
    [DisplayName("What you supposed to do? - ")]
    [StringLength(20, MinimumLength = 3)]
    public string Name { get; set; }
    [DisplayName("Add a description")]
    [StringLength(100)]
    public string? Description { get; set; }
    [DisplayName("Do we have a deadline?")]
    public DateTime? Deadline { get; set; }

    [DisplayName("How important is it?")]
    [Range(0, 10)]
    [DefaultValue(0)]
    public int Priority { get; set; }
    public virtual List<TagEntity>? Tags { get; set; }
    public virtual FolderEntity? Folder { get; set; }
    public virtual UserEntity? User { get; set; }
}