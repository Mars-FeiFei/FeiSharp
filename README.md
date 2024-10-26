FeiSharpCodeEditor_WinForm.net8.0 README:

I. Project Overview

This project is a Windows Forms application based on .NET 8.0 for editing FeiSharp code. It has functions such as code editing, saving, running, and checking, and includes certain interactive logic and syntax parsing capabilities. \
II. Main Code Structure and Functions
(I) Form1 Class (Main Window Related Code)
Member Variables and Constructor
Defined Log type logForm for logging, and a keywords list containing keywords. \
In the constructor, the component's styles are initialized, and event bindings are set, including the KeyDown event for handling shortcut keys. \
Event Handling Methods:
Keyboard Event Handling:
The Form1_KeyDown method handles keyboard keydown events and performs corresponding operations based on different hotkeys, such as running the code by pressing F5, saving the code by pressing Ctrl + S, and opening a file by pressing Ctrl + F. \
Mouse event handling:
The MainForm_MouseDown method handles the right-click mouse event on the main form and displays a context menu containing operations such as closing, minimizing, maximizing, opening files, and saving. \
The TxtCode_MouseDown method handles the mouse right-click event in a text box and displays a context menu that contains operations such as Clear, Paste, Copy, Cut, Select All, and Delete. \
The OutputBox_MouseDown method handles the mouse right-click event on the output box and displays a context menu containing operations such as clear, copy, and select all. \
Window Size Adjustment Event Handling: The FeiSharpForm_Resize method limits the minimum size of the window and adjusts the width of the text box and output box. \
The handling of function button click events:
The BtnRunClick, BtnSaveAsClick, BtnOpenFileClick, and BtnCheckClick methods correspond to the click events of the Run, Save As, Open File, and Check buttons, respectively, and call the corresponding functional methods. \
The BtnShortcutClick method creates a desktop shortcut for the application. \
The log_Click method is used to show or hide the log window. \
Code Editor-related event handling:
The CodeEditor_KeyPress method handles specific character inputs in the text box, such as auto-completing parentheses or quotes, and displays intelligent suggestions based on the input. \
The TxtCode_TextChanged method updates the smart suggestion based on the change in the text box content. \
The lstbIntelligence_KeyPress method handles key events for the lstbIntelligence listbox, enabling selection and insertion of smart suggestions. \
The `txtCode_MouseClick` method is used to hide the Smart Suggestion listbox. \
Other Methods:
The AddText method is used to add event information to the log. \
The Build method is used to build the token list for lexical analysis. \
The Check method is used to check the validity of the code, including the validity of variable and function names, as well as runtime exceptions. \
The "Run" method performs lexical and syntactic analysis, and displays the results or error messages in the output box. \
The RunAsException method is used to run code in debug mode and capture exception information. \
The SaveAs method saves the current code to a specified file using the SaveFileDialog. \
The Start method opens the FeiSharp source file using an OpenFileDialog and loads it into the text box. \
The ShowIntelligenceIfNecessary method displays relevant intelligence suggestions based on the input character fragment. \
(ii) Parser class (related code for syntax analyzer):
Member variables and constructor
It includes a Stopwatch for timing, _tokens for storing the list of parsed tokens, _current for indicating the current parsing index, _variables for storing a dictionary of variable and their values, _functions for storing a dictionary of function information, and _results for storing the results of function return values in a dictionary. \
The constructor accepts a token list as a parameter, initializes the parser state, and adds the built-in variables true and false to the _variables dictionary. \
The parsing method:
The ParseStatements method is the core of the syntax analysis, which handles various types of statements such as variable declarations, print statements, function definitions, conditional statements, and looping statements. It parses the code by matching keywords and corresponding syntactic structures, and calls other related parsing methods during the parsing process. \
Other specific parsing methods for specific language constructs, such as ParseVariableDeclaration for parsing variable declaration statements, ParsePrintStatement for parsing print statements, and ParseFunctionStatement for parsing function definition statements, etc. \
The EvaluateExpression method is used to calculate the value of an expression, which supports numbers, strings, variables, binary operations, and more. It performs the appropriate calculations and type conversions based on the expression type and operator. \
The EvaluatePrintStmt method is used to evaluate the expression of a print statement and output the result. \
Token matching and movement methods:
A series of methods for matching different types of tokens, such as MatchToken, MatchKeyword, MatchPunctuation, and MatchOperator, used to assist in the syntactic parsing process. \
The "Advance", "Peek", and "Previous" methods are used to move and retrieve tokens in a token stream, as well as to check whether the end has been reached. \
The "Run" method is used to execute code. It performs lexical analysis, syntactic analysis, and variable execution based on different parameter scenarios. \
The RunFunction method is used to execute a function, including parameter processing and the execution of the function body. \
The GetVar and GetType methods are used to retrieve expressions for variables and types. \
The InitValue method is used to initialize the value of a variable. \
The ParseExStr method is used to parse external string expressions. \
The GetCenter method is used to retrieve the middle part of a string. \
(III) TokenType Enumeration
Defines the basic types of syntactic units in the code, including keywords, identifiers, numbers, strings, punctuation marks, operators, file terminators, types, boolean values, function names, etc. \
III. Usage Methods:
Run the Application: Start the executable file and open the main window of FeiSharpCodeEditor. \
Edit code: Enter FeiSharp code in the text box. \
Save the code: Click the "Save as" button, select the save path and file name. \
Run the code: click the Run button to view the output results or error messages. \
Check the code: Click the check button to check the code's validity and potential issues. \
Use keyboard shortcuts and menus: Use keyboard shortcuts or click menu buttons to perform various actions, such as creating a shortcut, opening a file, etc. \
Note 4:
The exception handling code in the code is used to catch syntax errors and runtime errors, but further refinement and optimization of error prompt information may be needed to better help users locate the problem. \
When dealing with smart suggestions and code editing-related features, it is important to optimize performance, especially when working with large code files, to avoid lagging issues. \
For the syntax of the FeiSharp language, it is important to ensure that the parser implementation is fully consistent with the language specification, to avoid parsing errors or incorrect execution results. \