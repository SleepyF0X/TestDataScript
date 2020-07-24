using Models;
using System;

namespace ScriptBuilder
{
    public interface IScriptBuilder
    {
        SQLModel GenerateModel();
        string BuildScript(int stringCount);
    }
}
