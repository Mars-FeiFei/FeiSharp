using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeiSharpStudio
{
    public enum TokenTypes
    {
        Keyword,
        Identifier,
        Number,
        String,
        Punctuation,
        Operator,
        EndOfFile,
        Type,
        Bool,
        FuncName,
        Code
    }
}
