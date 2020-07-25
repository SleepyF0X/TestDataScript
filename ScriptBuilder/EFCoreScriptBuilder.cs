using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ScriptBuilder
{
    public class EfCoreScriptBuilder : IScriptBuilder
    {
        private readonly string[] _names;

        private readonly string[] _surnames;

        //private readonly string[] Emails;
        public EfCoreScriptBuilder(string dataSourceName, string dataSourceSurname /*, string dataSourceEmail*/)
        {
            _names = File.ReadAllLines(dataSourceName);
            _surnames = File.ReadAllLines(dataSourceSurname);
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

            var result = string.Join(", \n", ScriptSource);
            var script = "builder.Entity<DbProject>().HasData(" + result + "); ";
            return script;
        }

        public SQLModel GenerateModel()
        {
            SQLModel model = new SQLModel
            {
                Id = Guid.NewGuid(),
                Name = _names[new Random().Next(_names.Length)],
                Surname = _surnames[new Random().Next(_surnames.Length)],
            };
            model.Email = model.Name + model.Surname + "@gmail.com";
            return model;
        }
    }
}