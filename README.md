# FeiSharp
**FeiSharp** is a programming language, it uses C# to build and run it.

- 1.Underlying programming language.

FeiSharp **->** C# **->** IL **->** Binary
- 2.Define var.

> var **varname** = **value**;

This is a manner that define var.
But **FeiSharp** has another manner to define var.

> init(**varname**,**vartype**);

> set(**varname**,**varValueExpr**);

Sometimes you can only use init keyword.Because init keyword can init all type from System namespace, but set keyword only set var to string or number(double).

- 3.import and export keyword.

**FeiSharp**'s import and export keyword not likes **Java** or **JavaScript**.It likes **Process.Start(path);** and **File.AppendAllText(path,content);**

>import(path); export(path,content);

- 4.Another keyword.

- Keyword----args----Do
_________________
       print_____text__print the text.
       stop______void__stop the app and write vars.
       start_____path__start the file.
       input____varname_let user enter words and pay this string to the var.

