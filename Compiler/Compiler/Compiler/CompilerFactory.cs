using Compiler.Tokenizer;
using Compiler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compiler
{
    public class CompilerFactory
    {
        private List<CompiledStatement> compilers;
        private static CompilerFactory instance;
        public static CompilerFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CompilerFactory();
                }
                return instance;
            }
        }

        private CompilerFactory()
        {
            compilers = new List<CompiledStatement>();
            compilers.Add(new CompiledAssignment());
            compilers.Add(new CompiledDeclaration());
        }

        public CompiledStatement CreateCompiledStatement(CustomLLNode<Token> currentToken)
        {
            foreach(CompiledStatement compiledStatement in compilers)
            {
                if (compiledStatement.isMatch(currentToken))
                {
                    return compiledStatement.clone();
                }
            }
            throw new Exception();
        }
    }
}
