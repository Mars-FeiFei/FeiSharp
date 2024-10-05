using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FeiSharpCodeEditor_WinForm.net8._0_
{
    public class Parser
    {
        private Stopwatch Stopwatch { get; set; }
        private readonly List<Token> _tokens;
        private int _current;
        public Dictionary<string, object> _variables = new();
        public Dictionary<string, FunctionInfo> _functions = new();
        public event EventHandler<OutputEventArgs> OutputEvent;
        public Dictionary<string, object> _results = new();
        public Parser(List<Token> tokens)
        {
            _tokens = tokens;
            _current = 0;
            _variables.Add("true", true);
            _variables.Add("false", false);
        }
        protected virtual void OnOutputEvent(OutputEventArgs e)
        {
            EventHandler<OutputEventArgs> handler = OutputEvent;
            handler?.Invoke(this, e);
        }
        // Parse statements (variable declarations and print statements)
        public void ParseStatements(string funcName = "")
        {
            do
            {
                if (MatchKeyword("var"))
                {
                    ParseVariableDeclaration();
                }
                else if (MatchKeyword("print"))
                {
                    PrintStmt printStmt = ParsePrintStatement();
                    EvaluatePrintStmt(printStmt);
                }
                else if (MatchKeyword("init"))
                {
                    ParseInitStatement();
                }
                else if (MatchKeyword("set"))
                {
                    ParseSetStatement();
                }
                else if (MatchKeyword("import"))
                {
                    ParseImportStatement();
                }
                else if (MatchKeyword("export"))
                {
                    ParseExportStatement();
                }
                else if (MatchKeyword("start"))
                {
                    ParseStartStatement();
                }
                else if (MatchKeyword("stop"))
                {
                    ParseStopStatement();
                }
                else if (MatchKeyword("wait"))
                {
                    ParseWaitStatement();
                }
                else if (MatchKeyword("watchstart"))
                {
                    ParseWatchStartStatement();
                }
                else if (MatchKeyword("watchend"))
                {
                    ParseWatchEndStatement();
                }
                else if (MatchKeyword("abe"))
                {
                    ParseABSStatement();
                }
                else if (MatchKeyword("helper"))
                {
                    ParseHelperStatement();
                }
                else if (MatchKeyword("true"))
                {
                    ParseTrueStatement();
                }
                else if (MatchKeyword("false"))
                {
                    ParseFalseStatement();
                }
                else if (MatchKeyword("if"))
                {
                    ParseIfStatement();
                }
                else if (MatchKeyword("while"))
                {
                    ParseWhileStatement();
                }
                else if (MatchKeyword("func"))
                {
                    ParseFunctionStatement();
                }
                else if (MatchKeyword("dowhile"))
                {
                    ParseDowhileStatement();
                }
                else if (MatchKeyword("throw"))
                {
                    ParseThrowStatement();
                }
                else if (MatchKeyword("return"))
                {
                    ParseReturnStatement(funcName);
                }
                else if (MatchKeyword("gethtml"))
                {
                    ParseGetHtmlStatement();
                }
                else if (MatchKeyword("getVarsFromJsonFilePath"))
                {
                    ParseGetJsonFilePathStatement();
                }
                else if (MatchFunction(Peek().Value))
                {
                    RunFunction(Peek().Value);
                }
            } while (!IsAtEnd() && (Peek().Type == TokenType.Keyword || _functions.ContainsKey(Peek().Value)));
        }
        //private void ParseReplaceStatement()
        //{
        //    if (!MatchPunctuation("(")) throw new Exception("Expected '('");
        //    string arg = EvaluateExpression(ParseExpression()).ToString();
        //    if (!MatchPunctuation(",")) throw new Exception("Expected ','");
        //    string oldString = EvaluateExpression(ParseExpression()).ToString();
        //    if (!MatchPunctuation(",")) throw new Exception("Expected ','");
        //    string newString = EvaluateExpression(ParseExpression()).ToString();
        //    _variables.Add("replace:return", arg.Replace(oldString,newString));
        //    _functions.Add("replace", new FunctionInfo("replace", new List<string>(), new List<Token>()));
        //    if (!MatchPunctuation(")")) throw new Exception("Expected ')'");
        //    if (!MatchPunctuation(";")) throw new Exception("Expected ';'");
        //}
        private void ParseGetJsonFilePathStatement()
        {
            if (!MatchPunctuation("(")) throw new Exception("Expected '('");
            string content = File.ReadAllText(Advance().Value);
            content = content.Replace("{", "").Replace("}", "");
            string[] contentDatas = content.Split(',');
            foreach (var item in contentDatas)
            {
                if (double.TryParse(item.Split(':')[1], out double other))
                {
                    _variables.Add(item.Split(':')[0].Replace("\"", ""), double.Parse(item.Split(':')[1]));
                }
                else if (bool.TryParse(item.Split(':')[1], out bool otherBool))
                {
                    _variables.Add(item.Split(':')[0].Replace("\"", ""), bool.Parse(item.Split(':')[1]));
                }
                else
                {
                    _variables.Add(item.Split(':')[0].Replace("\"", ""), item.Split(':')[1].Split('\"')[1]);
                }
            }
            if (!MatchPunctuation(")")) throw new Exception("Expected ')'");
            if (!MatchPunctuation(";")) throw new Exception("Expected ';'");
        }
        private void ParseGetHtmlStatement()
        {
            if (!MatchPunctuation("(")) throw new Exception("Expected '('");
            string content = "";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(EvaluateExpression(ParseExpression()).ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                content = response.Content.ReadAsStringAsync().Result;
            }
            if (!MatchPunctuation(",")) throw new Exception("Expected ','");
            try
            {
                _variables.Add(EvaluateExpression(ParseExpression()).ToString(), content);
            }
            catch
            {
                _variables[EvaluateExpression(ParseExpression()).ToString()] = content;
            }
            if (!MatchPunctuation(")")) throw new Exception("Expected ')'");
            if (!MatchPunctuation(";")) throw new Exception("Expected ';'");
        }
        private void ParseReturnStatement(string funcName)
        {
            _results.Add(funcName, EvaluateExpression(ParseExpression()));
            _variables.Add($"{funcName}:return", _results[funcName]);
        }

        private void ParseThrowStatement()
        {
            if (!MatchPunctuation("(")) throw new Exception("Expected '('");
            Exception? ex = new();
            try
            {
                ex = (Exception)Activator.CreateInstance(Type.GetType("System." + Peek().Value));
            }
            catch
            {
                throw new Exception("This type isn't inherit Exception.");
            }
            throw (ex);
            if (!MatchPunctuation(")")) throw new Exception("Expected ')'");
            if (!MatchPunctuation(";")) throw new Exception("Expected ';'");
        }
        private void ParseDowhileStatement()
        {
            if (!MatchPunctuation("(")) throw new Exception("Expected '('");
            int current = _current;
            string b = EvaluateExpression(ParseExpression()).ToString();
            bool a = bool.Parse(b);
            if (!MatchPunctuation(")")) throw new Exception("Expected ')'");
            List<Token> tokens = new List<Token>();
            int indexC = 0;
            for (int i = _current + 1; i < _tokens.Count; i++)
            {
                if (_tokens[i].Type == TokenType.Punctuation && _tokens[i].Value == "}")
                {
                    indexC = i;
                    break;
                }
                tokens.Add(_tokens[i]);
            }
            TestVoid();
            do
            {
                _variables = Run(tokens, _variables);
                _current = current;
                a = bool.Parse(EvaluateExpression(ParseExpression()).ToString());
            } while (a);
            _current = indexC;
        }
        private void TestVoid() { }
        private void RunFunction(string funcName)
        {
            FunctionInfo functionInfo = _functions[funcName];
            List<object> actualParameters = new();
            Advance();
            while (Peek().Value != ")" && Peek().Value != ";")
            {
                if (Peek().Value == "," || Peek().Value == "(")
                {
                    Advance();
                    continue;
                }
                else
                {
                    actualParameters.Add(EvaluateExpression(ParseExpression()));
                    Advance();
                }
            }
            for (int i = 0; i < functionInfo.Parameter.Count; i++)
            {
                try
                {
                    _variables.Add(functionInfo.Parameter[i], actualParameters[i]);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new Exception("Parameters is not correct.");
                }
            }
            _variables = Run(functionInfo.FunctionBody, _variables, funcName);
        }
        private bool MatchFunction(string funcName)
        {
            return _functions.ContainsKey(funcName);
        }
        private void ParseFunctionStatement()
        {
            FunctionInfo functionInfo;
            string name = "";
            name = Peek().Value;
            List<string> parameters = [];
            Advance();
            while (Peek().Value != ")")
            {
                if (Peek().Value == "," || Peek().Value == "(")
                {
                    Advance();
                    continue;
                }
                else
                {
                    parameters.Add(Peek().Value);
                    Advance();
                }
            }
            Advance();
            List<Token> tokens = ParseTokens();
            functionInfo = new(name, parameters, tokens);
            _functions.Add(name, functionInfo);
            Advance();
            Advance();
        }
        private List<Token> ParseTokens()
        {
            List<Token> tokens = new List<Token>();
            int indexC = 0;
            for (int i = _current + 1; i < _tokens.Count; i++)
            {
                if (_tokens[i].Type == TokenType.Punctuation && _tokens[i].Value == "]")
                {
                    indexC = i;
                    break;
                }
                tokens.Add(_tokens[i]);
                Advance();
            }
            return tokens;
        }
        private void ParseWhileStatement()
        {
            if (!MatchPunctuation("(")) throw new Exception("Expected '('");
            int current = _current;
            string b = EvaluateExpression(ParseExpression()).ToString();
            bool a = bool.Parse(b);
            if (!MatchPunctuation(")")) throw new Exception("Expected ')'");
            List<Token> tokens = new List<Token>();
            int indexC = 0;
            for (int i = _current + 1; i < _tokens.Count; i++)
            {
                if (_tokens[i].Type == TokenType.Punctuation && _tokens[i].Value == "}")
                {
                    indexC = i;
                    break;
                }
                tokens.Add(_tokens[i]);
            }
            TestVoid();
            while (a)
            {
                _variables = Run(tokens, _variables);
                _current = current;
                a = bool.Parse(EvaluateExpression(ParseExpression()).ToString());
            }
            _current = indexC;
        }
        private void ParseIfStatement()
        {
            if (!MatchPunctuation("(")) throw new Exception("Expected '('");
            int current = _current;
            string b = EvaluateExpression(ParseExpression()).ToString();
            bool a = bool.Parse(b);
            if (!MatchPunctuation(")")) throw new Exception("Expected ')'");
            List<Token> tokens = new List<Token>();
            int indexC = 0;
            for (int i = _current + 1; i < _tokens.Count; i++)
            {
                if (_tokens[i].Type == TokenType.Punctuation && _tokens[i].Value == "}")
                {
                    indexC = i;
                    break;
                }
                if (_tokens[i].Type == TokenType.Punctuation && _tokens[i].Value == "{")
                {
                    continue;
                }
                tokens.Add(_tokens[i]);
            }
            TestVoid();
            if (a)
            {
                _variables = Run(tokens, _variables);
                _current = current;
                a = bool.Parse(EvaluateExpression(ParseExpression()).ToString());
            }
            _current = indexC;
        }
        private void ParseTrueStatement()
        {
        }

        private void ParseFalseStatement()
        {
        }

        private void ParseHelperStatement()
        {
            if (!MatchPunctuation("(")) throw new Exception("Expected '('");
            string a = EvaluateExpression(ParseExpression()).ToString();
            if (a.Equals("syntax", StringComparison.OrdinalIgnoreCase))
            {
                OnOutputEvent(new OutputEventArgs("Syntax:\r\n1.keyword+(args);\r\nInvoke keyword with args.\r\nWarning: If keyword hasn't args,\r\nuse keyword+;\r\n2.Define var.\r\n(1)define:\r\ninit(varname,Type); Or var varname = value;\r\n(2)assignment:\r\nset(varname,value);\r\n3.Keywords Table.\r\n________________________________________________\r\n|keyword   |  args   |  do somwthings           |\r\n|paint        text     print the text           |\r\n|watchstart  varname   start stopwatch.         |\r\n|watchend     null     stop stopwatch           |\r\n|init    varname,Type  init var.                |\r\n|set    varname,value  set var.                 |\r\n|...          ....     ............             |\r\n|_______________________________________________|"));
            }
            else if (a.Equals("github", StringComparison.OrdinalIgnoreCase))
            {
                OnOutputEvent(new("https://github.com/Mars-FeiFei/FeiSharp \r\n It is copy to your clipboard."));
                Clipboard.SetText("https://github.com/Mars-FeiFei/FeiSharp");
            }
            else
            {
                throw new Exception("Invalid string for \"helper\" keyword: " + a);
            }
            if (!MatchPunctuation(")")) throw new Exception("Expected ')'");
            if (!MatchPunctuation(";")) throw new Exception("Expected ';'");
        }
        private void ParseABSStatement()
        {
            if (!MatchPunctuation("(")) throw new Exception("Expected '('");
            string a = EvaluateExpression(ParseExpression()).ToString();
            if (!MatchPunctuation(",")) throw new Exception("Expected ','");
            int b = int.Parse(EvaluateExpression(ParseExpression()).ToString());
            if (!MatchPunctuation(",")) throw new Exception("Expected ','");
            int c = int.Parse(EvaluateExpression(ParseExpression()).ToString());
            if (!MatchPunctuation(",")) throw new Exception("Expected ','");
            int d = int.Parse(EvaluateExpression(ParseExpression()).ToString());
            if (!MatchPunctuation(")")) throw new Exception("Expected ')'");
            if (!MatchPunctuation(";")) throw new Exception("Expected ';'");
            try
            {
                _variables.Add(a, (b + c + d) / 3);
            }
            catch
            {
                _variables[a] = (b + c + d) / 3;
            }
        }
        private void ParseWatchEndStatement()
        {
            Stopwatch.Stop();
            try
            {
                _variables.Add(name, Stopwatch.Elapsed.TotalSeconds);
            }
            catch
            {
                _variables[name] = Stopwatch.Elapsed.TotalSeconds;
            }
            if (!MatchPunctuation(";")) throw new Exception("Expected ';'");
        }
        string name = "";
        private void ParseWatchStartStatement()
        {
            if (!MatchPunctuation("(")) throw new Exception("Expected '('");
            Stopwatch = Stopwatch.StartNew();
            name = EvaluateExpression(ParseExpression()).ToString();
            if (!MatchPunctuation(")")) throw new Exception("Expected ')'");
            if (!MatchPunctuation(";")) throw new Exception("Expected ';'");
        }
        private void ParseWaitStatement()
        {
            if (!MatchPunctuation("(")) throw new Exception("Expected '('");
            Thread.Sleep(int.Parse(EvaluateExpression(ParseExpression()).ToString()) * 1000);
            if (!MatchPunctuation(")")) throw new Exception("Expected ')'");
            if (!MatchPunctuation(";")) throw new Exception("Expected ';'");
        }
        private void ParseStopStatement()
        {
            if (!MatchPunctuation(";")) throw new Exception("Expected ';'");
            OnOutputEvent(new OutputEventArgs("Application is stop..."));
            foreach (var item in _variables)
            {
                OnOutputEvent(new OutputEventArgs($"var {item.Key} = {item.Value} : {item.Value.GetType()}"));
            }
            OnOutputEvent(new OutputEventArgs($"{_variables.Count}" + " items of vars."));
        }
        private void ParseStartStatement()
        {
            if (!MatchPunctuation("(")) throw new Exception("Expected '('");
            Expr b = ParseExpression();
            string a = (string)EvaluateExpression(b);
            Process.Start(a);
            if (!MatchPunctuation(")")) throw new Exception("Expected ')'");
            if (!MatchPunctuation(";")) throw new Exception("Expected ';'");
        }
        private void ParseExportStatement()
        {
            if (!MatchPunctuation("(")) throw new Exception("Expected '('");
            Expr b = ParseExpression();
            string a = (string)EvaluateExpression(b);
            if (!MatchPunctuation(",")) throw new Exception("Expected ','");
            Expr b1 = ParseExpression();
            string a1 = (string)EvaluateExpression(b1);
            File.AppendAllText(a, a1);
            if (!MatchPunctuation(")")) throw new Exception("Expected ')'");
            if (!MatchPunctuation(";")) throw new Exception("Expected ';'");
        }
        private void ParseImportStatement()
        {
            if (!MatchPunctuation("(")) throw new Exception("Expected '('");
            Expr b = ParseExpression();
            string a = (string)EvaluateExpression(b);
            Run(File.ReadAllText(a));
            if (!MatchPunctuation(")")) throw new Exception("Expected ')'");
            if (!MatchPunctuation(";")) throw new Exception("Expected ';'");
        }
        internal void Run(string code)
        {
            string sourceCode = code;
            Lexer lexer = new(sourceCode);
            List<Token> tokens = [];
            Token token;
            do
            {
                token = lexer.NextToken();
                tokens.Add(token);
            } while (token.Type != TokenType.EndOfFile);

            Parser parser = new(tokens);
            parser._functions = _functions;
            try
            {
                parser.ParseStatements();
            }
            catch (Exception ex)
            {
                OnOutputEvent(new OutputEventArgs("Parsing error: " + ex.Message));
            }
            return;
        }
        internal Dictionary<string, object> Run(IEnumerable<Token> tokens, Dictionary<string, object> _vars)
        {
            List<Token> _tokens = new(tokens);
            Parser parser = new(_tokens);
            parser.OutputEvent = this.OutputEvent;
            parser._variables = _vars;
            try
            {
                parser.ParseStatements();
            }
            catch (Exception ex)
            {
                OnOutputEvent(new OutputEventArgs("Parsing error: " + ex.Message));
            }
            return parser._variables;
        }
        internal Dictionary<string, object> Run(IEnumerable<Token> tokens, Dictionary<string, object> _vars, string funcName)
        {
            List<Token> _tokens = new(tokens);
            Parser parser = new(_tokens);
            parser.OutputEvent = this.OutputEvent;
            parser._variables = _vars;
            try
            {
                parser.ParseStatements(funcName);
            }
            catch (Exception ex)
            {
                OnOutputEvent(new OutputEventArgs("Parsing error: " + ex.Message));
            }
            return parser._variables;
        }
        internal Dictionary<string, object> Run(string code, int a)
        {
            string sourceCode = code;
            Lexer lexer = new(sourceCode);
            List<Token> tokens = [];
            Token token;
            do
            {
                token = lexer.NextToken();
                tokens.Add(token);
            } while (token.Type != TokenType.EndOfFile);

            Parser parser = new(tokens);
            parser.OutputEvent = this.OutputEvent;
            try
            {
                parser.ParseStatements();
            }
            catch (Exception ex)
            {
                OnOutputEvent(new OutputEventArgs("Parsing error: " + ex.Message));
            }
            return parser._variables;
        }
        private string GetCenter(string str, char fir, char lat)
        {
            return str.Split(fir)[1].Split(lat)[0];
        }
        private object ParseExStr(string ex)
        {
            List<Token> tokens = new List<Token>();
            Lexer lx = new(ex);
            while (lx.NextToken().Type != TokenType.EndOfFile)
            {
                tokens.Add(lx.NextToken());
            }
            Parser parser = new(tokens);
            return EvaluateExpression(parser.ParseExpression());
        }
        private void ParseSetStatement()
        {
            if (!MatchPunctuation("(")) throw new Exception("Expected '('");
            Expr expr = GetVar();
            if (!MatchPunctuation(",")) throw new Exception("Expected ','");
            string name = EvaluateExpression(ParseExpression()).ToString();
            Expr expr2 = new VarExpr(name);
            if (!MatchPunctuation(")")) throw new Exception("Expected ')'");
            if (!MatchPunctuation(";")) throw new Exception("Expected ';'");
            _variables[((VarExpr)expr).Name] = ((VarExpr)expr2).Name;
        }
        private void ParseInitStatement()
        {
            if (!MatchPunctuation("(")) throw new Exception("Expected '('");
            Expr expr = GetVar();
            if (!MatchPunctuation(",")) throw new Exception("Expected ','");
            Expr expr2 = GetType();
            if (!MatchPunctuation(")")) throw new Exception("Expected ')'");
            if (!MatchPunctuation(";")) throw new Exception("Expected ';'");
            _variables.Add(((VarExpr)expr).Name, InitValue(((VarExpr)expr2).Name));
        }
        private object InitValue(string type)
        {
            Type t = Type.GetType("System." + type);
            return Activator.CreateInstance(t);
        }
        private Expr GetVar()
        {
            if (MatchToken(TokenType.Identifier))
            {
                return new VarExpr(Previous().Value);
            }
            return null;
        }
        private Expr GetType()
        {
            if (MatchToken(TokenType.Type))
            {
                return new VarExpr(Previous().Value);
            }
            return null;
        }
        private void ParseVariableDeclaration()
        {
            // Match the variable name
            if (!MatchToken(TokenType.Identifier, out string varName))
            {
                throw new Exception("Expected variable name");
            }

            // Match the '=' token
            if (!MatchToken(TokenType.Operator, out string op) || op != "=")
            {
                throw new Exception("Expected '=' after variable name");
            }

            // Parse the expression on the right-hand side
            Expr expr = ParseExpression();

            // Ensure the statement ends with a semicolon
            if (!MatchPunctuation(";"))
            {
                throw new Exception("Expected ';' after variable declaration");
            }

            // Evaluate the expression and store the result
            object value = EvaluateExpression(expr);
            _variables[varName] = value;
        }

        // Parse a print statement
        private PrintStmt ParsePrintStatement()
        {
            if (!MatchPunctuation("(")) throw new Exception("Expected '('");
            Expr expr = ParseExpression();
            if (!MatchPunctuation(")")) throw new Exception("Expected ')'");
            if (!MatchPunctuation(";")) throw new Exception("Expected ';'");
            return new PrintStmt(expr);
        }

        private Expr ParseExpression()
        {
            Expr expr = ParsePrimary();
            while (MatchOperator("+", "-", "*", "/", "|", "^", "<", ">", "=", "!"))
            {
                string op = Previous().Value;
                Expr right = ParsePrimary();
                expr = new BinaryExpr(expr, op, right);
            }
            return expr;
        }

        private Expr ParsePrimary()
        {
            if (MatchToken(TokenType.Number))
            {
                return new ValueExpr(double.Parse(Previous().Value));
            }
            else if (MatchToken(TokenType.String))
            {
                return new StringExpr(Previous().Value);
            }
            else if (MatchToken(TokenType.Identifier))
            {
                string varName = Previous().Value;
                if (_variables.TryGetValue(varName, out object value))
                {
                    return new ValueExpr(value);
                }
                else
                {
                    RunFunction(varName);
                    return new ValueExpr(_variables[$"{varName}:return"]);
                    // return new ValueExpr(Run(_functions[varName].FunctionBody, _variables, varName));
                }
                throw new Exception($"Undefined variable: {varName}");
            }
            else if (MatchPunctuation("("))
            {
                Expr expr = ParseExpression();
                if (!MatchPunctuation(")"))
                {
                    throw new Exception("Expected ')' after expression");
                }
                return expr;
            }
            else if (MatchKeyword("true"))
            {
                string varName = Previous().Value;
                if (_variables.TryGetValue(varName, out object value))
                {
                    return new ValueExpr(value);
                }

                throw new Exception($"Undefined variable: {varName}");
            }
            else if (MatchKeyword("false"))
            {
                string varName = Previous().Value;
                if (_variables.TryGetValue(varName, out object value))
                {
                    return new ValueExpr(value);
                }

                throw new Exception($"Undefined variable: {varName}");
            }
            throw new Exception("Unvalid token: " + Peek().Value);
        }

        private bool MatchToken(params TokenType[] types)
        {
            foreach (var type in types)
            {
                if (Check(type))
                {
                    Advance();
                    return true;
                }
            }
            return false;
        }

        private bool MatchToken(TokenType type, out string value)
        {
            if (Check(type))
            {
                value = Peek().Value;
                Advance();
                return true;
            }
            value = null;
            return false;
        }


        private bool MatchKeyword(string keyword)
        {
            if (Check(TokenType.Keyword) && Peek().Value == keyword)
            {
                Advance();
                return true;
            }
            return false;
        }

        private bool MatchPunctuation(string punctuation)
        {
            if (Check(TokenType.Punctuation) && Peek().Value == punctuation)
            {
                Advance();
                return true;
            }
            return false;
        }

        private bool MatchOperator(params string[] operators)
        {
            if (Check(TokenType.Operator) && operators.Contains(Peek().Value))
            {
                Advance();
                return true;
            }
            return false;
        }

        private bool Check(TokenType type)
        {
            return !IsAtEnd() && Peek().Type == type;
        }
        private bool PreviousCheck(TokenType type)
        {
            return !IsAtEnd() && Previous().Type == type;
        }
        private Token Advance()
        {
            if (!IsAtEnd()) _current++;
            return Previous();
        }

        private bool IsAtEnd()
        {
            return _current >= _tokens.Count;
        }

        private Token Peek()
        {
            if (IsAtEnd()) throw new InvalidOperationException("No more tokens available.");
            return _tokens[_current];
        }

        private Token Previous()
        {
            if (_current == 0) throw new InvalidOperationException("No previous token available.");
            return _tokens[_current - 1];
        }

        private void EvaluatePrintStmt(PrintStmt stmt)
        {
            string text = EvaluateExpression(stmt.Expression).ToString();
            OnOutputEvent(new OutputEventArgs(text));
        }
        private object EvaluateExpression(Expr expr)
        {
            switch (expr)
            {
                case ValueExpr numExpr:
                    if (double.TryParse(numExpr.Value.ToString(), out double a))
                    {
                        return double.Parse(numExpr.Value.ToString());
                    }
                    else
                    {
                        return numExpr.Value;
                    }

                case BinaryExpr binExpr:
                    object left = EvaluateExpression(binExpr.Left);
                    object right = EvaluateExpression(binExpr.Right);
                    if (left is string && right is string)
                    {
                        return binExpr.Operator switch
                        {
                            "+" => (string)left + (string)right,
                            "-" => Regex.Replace((string)left, Regex.Escape((string)right), ""),
                            _ => throw new Exception("Unexpected operator: " + binExpr.Operator)
                        };
                    }
                    left = Convert.ToDouble(left.ToString());
                    right = Convert.ToDouble(right.ToString());
                    return binExpr.Operator switch
                    {
                        "+" => (double)left + (double)right,
                        "-" => (double)left - (double)right,
                        "*" => (double)left * (double)right,
                        "/" => (double)left / (double)right,
                        "^" => Math.Pow((double)left, (double)right),
                        "|" => Math.Pow((double)left, 1 / (double)right),
                        ">" => (double)left > (double)right,
                        "<" => (double)left < (double)right,
                        "=" => (double)left == (double)right,
                        "!" => (double)left != (double)right,
                        _ => throw new Exception("Unexpected operator: " + binExpr.Operator)
                    };
                case StringExpr stringExpr:
                    return stringExpr.Value;
                default:
                    throw new Exception("Unexpected expression type");
            }
            string RepeatZeros(int a)
            {
                string result = "";
                for (int i = 0; i < a; i++)
                {
                    result += "0";
                }
                return result;
            }
        }
    }


    // Example TokenType enum
    public enum TokenType
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
        FuncName
    }
}
