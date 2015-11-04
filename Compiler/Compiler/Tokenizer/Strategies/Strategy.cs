using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Tokenizer.Strategies
{
    interface Strategy
    {
        Token Match(string value, Token lastToken);
    }
}
