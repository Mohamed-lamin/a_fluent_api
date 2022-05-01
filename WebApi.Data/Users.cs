namespace WebApi.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class User

{
    public int Id { get; set; } 
    public string FirstName { get; set; }=String.Empty;
    public string LastName { get; set; }= String.Empty; 

    public string ContactEmailAddress { get; set; }= String.Empty;

    public UserGroup? Group { get; set; }
    public int? UserGroupId { get; set; }
}
public class UserEntiyTypeConfiguration:IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.FirstName);
        builder.Property(u => u.ContactEmailAddress);
        builder.HasOne(u => u.Group)
            .WithMany(g => g.Users)
            .HasForeignKey(u => u.UserGroupId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);
    }
}
public class UserGroup
{
    public int Id { get; set; }
    public int Name { get; set; }

    public List<User> Users { get; set; } = new();

}