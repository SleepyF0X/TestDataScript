using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ScriptBuilder
{
    public class EFCoreScriptBuilder : IScriptBuilder
    {
        private readonly string[] Names;
        private readonly string[] Surnames;
        //private readonly string[] Emails;
        public EFCoreScriptBuilder(string dataSourceName, string dataSourceSurname/*, string dataSourceEmail*/)
        {
            Names = File.ReadAllLines(dataSourceName);
            Surnames = File.ReadAllLines(dataSourceSurname);
            //Emails = File.ReadAllLines(dataSourceEmail);
        }
        public string BuildScript(int stringCount)
        {
            List<string> ScriptSource = new List<string>();
            for (int i = 0; i <= stringCount; i++)
            {
                SQLModel model = GenerateModel();
                ScriptSource.Add($"new DbProject " +
                    $"{{ " +
                    $"Id = Guid.NewGuid(), " +
                    $"Name = \"{model.Name}\", " +
                    $"Info = \"{model.Surname}\"" +
                    //etc.
                    $"}}");
            }
            var result = String.Join(", \n", ScriptSource);
            string Script = "builder.Entity<DbProject>().HasData(" + result + "); ";
            return Script;
        }

        public SQLModel GenerateModel()
        {
            SQLModel model = new SQLModel
            {
                Id = Guid.NewGuid(),
                Name = Names[new Random().Next(Names.Length)],
                Surname = Surnames[new Random().Next(Surnames.Length)],
            };
            model.Email = model.Name + model.Surname + "@gmail.com";
            return model;
        }
    }
}
