namespace iMobileDevice.Generator.CodeDom
{
    using System;
    using System.CodeDom;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal partial class CSharpTextWriter
    {
        private void Generate(CodeStatementCollection statements)
        {
            foreach (CodeStatement statement in statements)
            {
                this.Generate(statement);
            }
        }

        private void Generate(CodeStatement statement)
        {
            if (statement is CodeMethodReturnStatement)
            {
                this.Generate((CodeMethodReturnStatement)statement);
            }
            else if (statement is CodeExpressionStatement)
            {
                this.Generate((CodeExpressionStatement)statement);
            }
            else if (statement is CodeVariableDeclarationStatement)
            {
                this.Generate((CodeVariableDeclarationStatement)statement);
            }
            else if (statement is CodeAssignStatement)
            {
                this.Generate((CodeAssignStatement)statement);
            }
            else if (statement is CodeConditionStatement)
            {
                this.Generate((CodeConditionStatement)statement);
            }
            else if (statement is CodeThrowExceptionStatement)
            {
                this.Generate((CodeThrowExceptionStatement)statement);
            }
            else if (statement is CodeCommentStatement)
            {
                this.Generate((CodeCommentStatement)statement);
            }
            else if (statement is CodeTryCatchFinallyStatement)
            {
                this.Generate((CodeTryCatchFinallyStatement)statement);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        private void Generate(CodeTryCatchFinallyStatement statement)
        {
            this.WriteLine("try");
            this.WriteLine("{");
            this.Indent++;
            this.Generate(statement.TryStatements);
            this.Indent--;
            this.WriteLine("}");

            foreach (CodeCatchClause catchClause in statement.CatchClauses)
            {
                this.WriteLine($"catch ({catchClause.CatchExceptionType.BaseType} {catchClause.LocalName})");
                this.WriteLine("{");
                this.Indent++;
                this.Generate(catchClause.Statements);
                this.Indent--;
                this.WriteLine("}");
            }

            if (statement.FinallyStatements.Count > 0)
            {
                this.WriteLine("finally");
                this.WriteLine("{");
                this.Indent++;
                this.Generate(statement.FinallyStatements);
                this.Indent--;
                this.WriteLine("}");
            }
        }

        private void Generate(CodeCommentStatement statement)
        {
            if (statement.Comment.DocComment)
            {
                this.Write("/// ");
            }
            else
            {
                this.Write("// ");
            }

            this.Write(statement.Comment.Text);
            this.WriteLine();
        }

        private void Generate(CodeThrowExceptionStatement statement)
        {
            this.Write("throw ");

            if (statement.ToThrow != null)
            {
                this.Generate(statement.ToThrow);
            }

            this.WriteLine(";");
        }

        private void Generate(CodeConditionStatement statement)
        {
            this.Write("if (");
            this.Generate(statement.Condition);
            this.Write(")");
            this.WriteLine();
            this.WriteLine("{");
            this.Indent++;

            this.Generate(statement.TrueStatements);

            this.Indent--;
            this.WriteLine("}");

            if (statement.FalseStatements != null && statement.FalseStatements.Count > 0)
            {
                this.WriteLine("else");
                this.WriteLine("{");
                this.Indent++;

                this.Generate(statement.FalseStatements);

                this.Indent--;
                this.WriteLine("}");
            }
        }

        private void Generate(CodeAssignStatement statement)
        {
            this.Generate(statement.Left);
            this.Write(" = ");
            this.Generate(statement.Right);
            this.WriteLine(";");
        }

        private void Generate(CodeExpressionStatement statement)
        {
            this.Generate(statement.Expression);
            this.WriteLine(";");
        }

        private void Generate(CodeMethodReturnStatement statement)
        {
            this.Write("return ");
            this.Generate(statement.Expression);
            this.WriteLine(";");
        }

        private void Generate(CodeVariableDeclarationStatement statement)
        {
            this.Generate(statement.Type);
            this.Write(" ");
            this.Write(statement.Name);

            if (statement.InitExpression != null)
            {
                this.Write(" = ");
                this.Generate(statement.InitExpression);
            }

            this.WriteLine(";");
        }

        private void WriteDocumentation(CodeCommentStatementCollection comments)
        {
            foreach (CodeCommentStatement comment in comments)
            {
                StringReader reader = new StringReader(comment.Comment.Text);

                while (reader.Peek() > 0)
                {
                    this.WriteLine($"/// {reader.ReadLine().TrimStart()}");
                }
            }
        }
    }
}
