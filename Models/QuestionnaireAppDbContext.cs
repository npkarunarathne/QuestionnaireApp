using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace QuestionnaireApp2.Models
{
    public class QuestionnaireAppDbContext : DbContext
    {

        public QuestionnaireAppDbContext(DbContextOptions<QuestionnaireAppDbContext> options)
            : base(options)
        {
        }

         public DbSet<Programs> Program { get; set; }
         public DbSet<PersonalInformationFields> PersonalInformationFields { get; set; }
         public DbSet<CustomQuestion> CustomQuestion { get; set; }
         public DbSet<QuestionTypes> QuestionTypes { get; set; }
         public DbSet<QuestionValues> QuestionValues { get; set; }
         public DbSet<Responses> Responses { get; set; }
         public DbSet<PersonalInformationResponses> PersonalInformationResponses { get; set; }
         public DbSet<CustomQuestionResponses> CustomQuestionResponses { get; set; }

         protected override void OnModelCreating(ModelBuilder builder)
         {
             builder.Entity<QuestionTypes>().HasData(new
             { 
                     Id = "9ea1a9da-3285-4550-a396-85a10fb79dff",
                     Name = "Paragraph",
                     HasValues = false 
             }); 
             builder.Entity<QuestionTypes>().HasData(new
             { 
                 Id = "1fdd811a-8295-4a17-bcb4-23ee0ee8a3b3",
                 Name = "Yes/No",
                 HasValues = false 
             });
             builder.Entity<QuestionTypes>().HasData(new
             { 
                 Id = "eba711bb-4243-4bb9-adf3-1e8cd04d7722",
                 Name = "Dropdown",
                 HasValues = true 
             });
             builder.Entity<QuestionTypes>().HasData(new
             { 
                 Id = "22ef9236-27d5-4b79-9543-c2c7e606fb4d",
                 Name = "Date",
                 HasValues = false 
             });
             
             builder.Entity<QuestionTypes>().HasData(new
             { 
                 Id = "35c29351-1b7e-41c5-9632-98523c10da9d",
                 Name = "Number",
                 HasValues = false 
             }); 
         } 

    }
}
