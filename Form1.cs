using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Codebutton;
namespace Codebutton
{
    public partial class Form1 : Form
    {
        bool developer;
        bool loadSkip;
        bool runningScriptStatus;
        string runningScriptName;
        string argms;
        string lastExecutedCmd;
        string findArgValue = null;
        public string findArguement(string name)
        {
            string[] argv = this.richTextBox1.Text.Split('\n');

            foreach (string arg in argv)
            {
                if (arg.Contains(name))
                {
                    this.findArgValue = arg.Replace(name + "=", "");
                }
            }
            return this.findArgValue.ToString();
        }
        public Form1(bool devConsole = false, bool skip = false, string args = "")
        {
            this.argms = args;
            this.developer = devConsole;
            this.loadSkip = skip;


            InitializeComponent();
            if (devConsole) AllocConsole();

         }
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("User32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            const int WM_NCPAINT = 0x85;
            if (m.Msg == WM_NCPAINT)
            {
                IntPtr hdc = GetWindowDC(m.HWnd);
                if ((int)hdc != 0)
                {
                    Graphics g = Graphics.FromHdc(hdc);
                    g.FillRectangle(Brushes.Green, new Rectangle(0, 0, 4800, 23));
                    g.Flush();
                    ReleaseDC(m.HWnd, hdc);
                }
            }
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        string[] configLmf()
        {
            string[] linesa = this.richTextBox1.Text.Split(',');
            return linesa;
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Console.Clear();
            }
            catch 
            {

            }
            try
            {
                Console.WriteLine("* Starting MbConsole at @" + Environment.CurrentDirectory);
                Console.WriteLine("* Args *\n" + argms);
            }
            catch
            {

            }
            this.richTextBox1.Visible = false;
            if (System.IO.File.Exists(Environment.CurrentDirectory + @"\config.lmf"))
            {
                this.richTextBox1.LoadFile(Environment.CurrentDirectory + @"\config.lmf", RichTextBoxStreamType.PlainText);
                if (this.richTextBox1.Text.Length < 1) return;
                this.richTextBox1.Text = richTextBox1.Text.Replace("%devCmd%", this.developer.ToString().ToLower()).Replace("%skipload%", this.loadSkip.ToString().ToLower());
                string[] lines = this.richTextBox1.Text.Replace('\n', ',').Replace(" ", "").Split(',');
                foreach (string line in lines)
                {
                    if (line.Length > 1)
                    {
                        if (this.appInfo.Text.Length > 1)
                        {
                            this.appInfo.Text = this.appInfo.Text + ", {" + line + "}";

                        }
                        else
                        {
                            this.appInfo.Text = "{" + line + "}";

                        }
                    }


                }
                string config = this.appInfo.Text;
                Console.WriteLine("* Found `config.lmf`");
                Console.WriteLine("* Loading configuration...");
                Console.WriteLine(config.Replace(", ", "\n"));
                Console.WriteLine("************************************************************");
                
            }
            if (this.loadSkip)
            {
                this.progressBar1.Visible = true;
                progressBar1.Style = ProgressBarStyle.Blocks;
                try
                {

                }
                catch
                {

                }
                this.progressBar1.Visible = false;
                this.current_directory.Text = "MbConsole@dev (2.2)";
                this.label2.Visible = false;
                this.TextBox1.Visible = true;
                Console.WriteLine("Skipping GUI load, this will cause lag but the system will be loaded faster.");
                Console.WriteLine("GUI Loaded, execution of commands are now allowed.\n");
                ExecuteCommand("applicationStart");
                await System.Threading.Tasks.Task.Delay(1000);
                commandRequester.KeyDown += TextBoxKeyUp;
                
            }
            else
            {
                this.progressBar1.Visible = true;
                progressBar1.Style = ProgressBarStyle.Blocks;
                try
                {
                    Console.Title = "MbConsole Debugging Terminal (admin-only)";

                }
                catch
                {

                }
                Console.WriteLine("Welcome to MbConsole v0.5 (dev@0_5) beta.");
                Console.WriteLine("Logging will be casted to this console window throughout the use of the console.");
                this.TextBox1.Text = ">> Loading Application...";
                this.current_directory.Text = "Loading MbConsole@dev...";
                this.label2.Visible = true;
                this.TextBox1.Visible = false;
                this.progressBar1.PerformStep();
                await System.Threading.Tasks.Task.Delay(100);
                this.progressBar1.PerformStep();
                await System.Threading.Tasks.Task.Delay(100);
                this.progressBar1.PerformStep();
                await System.Threading.Tasks.Task.Delay(100);
                this.progressBar1.PerformStep();
                await System.Threading.Tasks.Task.Delay(100);
                this.progressBar1.PerformStep();
                await System.Threading.Tasks.Task.Delay(100);
                this.progressBar1.PerformStep();
                await System.Threading.Tasks.Task.Delay(100);
                this.progressBar1.PerformStep();
                await System.Threading.Tasks.Task.Delay(100);
                this.progressBar1.PerformStep();
                await System.Threading.Tasks.Task.Delay(100);
                this.progressBar1.PerformStep();
                await System.Threading.Tasks.Task.Delay(100);
                this.progressBar1.PerformStep();
                await System.Threading.Tasks.Task.Delay(1000);
                this.progressBar1.Visible = false;
                this.current_directory.Text = "MbConsole@dev (2.1)";
                this.label2.Visible = false;
                this.TextBox1.Visible = true;
                Console.WriteLine("GUI Loaded, execution of commands are now allowed.\n");
                ExecuteCommand("applicationStart");
                await System.Threading.Tasks.Task.Delay(1000);
                commandRequester.KeyDown += TextBoxKeyUp;
            }
            
        }

        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (this.TextBox1.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.TextBox1.SelectionStart;

                while ((index = this.TextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.TextBox1.Select((index + startIndex), word.Length);
                    this.TextBox1.SelectionColor = color;
                    this.TextBox1.Select(selectStart, 0);
                    this.TextBox1.SelectionColor = Color.White;
                }
            }
        }
        public void ShowErrorBox(string text, Color BackgroundColor)
        {
            Form2 form2 = new Codebutton.Form2(text, BackgroundColor);
            Console.Beep();
            form2.ShowDialog();
            
        }
        ///<summary>
        /// application.arguements -> Configuration.all
        /// </summary>
        public string[] GetConfiguration()
        {
            return this.richTextBox1.Text.Split('\n');

                
        }
        public async void executeScript(string scriptPath)
        {
            if (System.IO.File.Exists(scriptPath + ".mbs"))
            {
                this.runningScriptName = System.IO.Path.GetFileNameWithoutExtension(scriptPath + ".mbs");
                this.runningScriptStatus = true;
                currentScript.LoadFile(scriptPath + ".mbs", RichTextBoxStreamType.PlainText);
                string[] script_text = currentScript.Text.Split('\n');
                int lines = 0;
                foreach (string line in script_text)
                {
                    lines++;
                    
                    if (!line.StartsWith("//"))
                    {
                        if (line.Length > 1)
                        {
                            ExecuteCommand(line);
                            // execute the command that's in the line.
                        }
                    } 
                    else
                    {
                        Console.WriteLine(this.runningScriptName + " >> skipping comment line (" + this.runningScriptName + ": " + lines + ")");
                    }

                }
                await Task.Delay(1000);
                this.runningScriptName = null;
                this.runningScriptStatus = false;
            } 
            else if (System.IO.File.Exists(scriptPath))
            {
                if (!scriptPath.EndsWith(".mbs"))
                {
                    cast(">> the file is not a valid MbConsole Script File. (extension .mbs is required)");
                    return;
                }
                this.runningScriptName = System.IO.Path.GetFileNameWithoutExtension(scriptPath);
                this.runningScriptStatus = true;
                currentScript.LoadFile(scriptPath, RichTextBoxStreamType.PlainText);
                string[] script_text = currentScript.Text.Split('\n');
                int lines = 0;
                foreach (string line in script_text)
                {
                    lines++;
                    if (line.Length > 1)
                    {
                        ExecuteCommand(line, lines);
                        // execute the command that's in the line.
                    }
                }
                await Task.Delay(1000);
                this.runningScriptName = null;
                this.runningScriptStatus = false;
            }
            else
            {
                cast(">> script does not exist");

            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            cast("MbConsole can not be closed while a local server is running.");
            cast("execute quit to stop the server.");
            this.CheckKeyword("can not be closed while a local server is running.", Color.Red, 0);
            this.CheckKeyword("execute quit to stop the server.", Color.Red, 0);
            this.CheckKeyword("quit", Color.DarkSlateBlue, 0);
            e.Cancel = true;
        }

        public void executeAlias(string alias)
        {
            // find an alias from ./alias.lmf and get the name
            if (!System.IO.File.Exists(Environment.CurrentDirectory + "/alias.lmf"))
            {
                this.ShowErrorBox("System: Alias.lmf does not exist or is corrupted", Color.Red);
                return;
            } 
            else
            {
                if (alias.Length < 1) return;
                activeAliasesText.LoadFile(Environment.CurrentDirectory + "/alias.lmf", RichTextBoxStreamType.PlainText);
                string[] aliases = activeAliasesText.Text.Split('\n');
                foreach (string cmd in aliases)
                {
                    if (cmd.ToLower().Contains(alias.ToLower()))
                    {
                        string alias_command = cmd.Replace("\"" + alias + "\": ", "").Replace("\"", "");
                        ExecuteCommand(alias_command);
                    }
                }
            }

        }

        private void encryptScript(string fileName)
        {
            Byte[] bytes = File.ReadAllBytes(fileName);
            String file = Convert.ToBase64String(bytes);
            Console.WriteLine(file);
            System.IO.File.AppendAllText(Path.GetFileNameWithoutExtension(fileName) + ".mpf", file);
            /*
            if (System.IO.File.Exists(fileName + ".mbs"))
            {
                string[] file_lines = System.IO.File.ReadAllLines(fileName + ".mbs");
                foreach (string line in file_lines)
                {
                    string encodedLine = Base64Encode(line);
                    System.IO.File.AppendAllText(System.IO.Path.GetFileNameWithoutExtension(fileName) + ".mpf", encodedLine + "\n");

                }

            }
            else if (System.IO.File.Exists(fileName))
            {
                string[] file_lines = System.IO.File.ReadAllLines(fileName);
                foreach (string line in file_lines)
                {
                    string encodedLine = Base64Encode(line);
                    System.IO.File.AppendAllText(System.IO.Path.GetFileNameWithoutExtension(fileName) + ".mpf", encodedLine + "\n");

                }

            }
            */
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public void execute_internal_command(string command)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            
            //set the directory of the file to the directory variable
            var directory = Environment.CurrentDirectory;
            Console.WriteLine(directory);
            //located the file, now see commands.
            if (System.IO.File.Exists(directory + @"\cmds\" + command + ".mpf"))
            {
                string[] lines = System.IO.File.ReadAllLines(directory + @"\cmds\" + command + ".mpf");
                string script_type = "EXECUTE";
                File.WriteAllText("tmp." + command + ".mpf", string.Empty);
                foreach (string encLine in lines)
                {
                    string line = Encoding.UTF8.GetString(Convert.FromBase64String(encLine));
                    File.AppendAllText("tmp." + command + ".mpf", line);
                }
                string[] decrypted_file = File.ReadAllLines("tmp." + command + ".mpf");
                foreach (string line in decrypted_file)
                {

                    if (line.StartsWith("#script_type=")) {
                        //Given the script in the internal `\cmds\ path, determine the script_type for the script.
                        if (line != "#script_type=")
                        {
                            string type = line.Replace("#script_type=", "");
                            script_type = type;

                        }
                        
                    }
                    if (script_type == "configuration")
                    {
                        if (!line.StartsWith("#'''") && !line.EndsWith("'''"))
                        {
                            // the script wants to modify the configuration
                            if (!line.StartsWith("#script_type="))
                            {
    
                                string[] value = line.Split('=');
                                File.AppendAllText(Environment.CurrentDirectory + "\\" + "config.lmf", "\n" + value[0] + "=" + value[1]);
                                //append to config.lmf for the current directory
                            }
                        }
                    }
                    if (script_type == "WRITE")
                    {
                        //the script is a WRITE script. The content of the script will be written to the console.
                        if (!line.StartsWith("#script_type="))
                        {
                            if (!line.StartsWith("'''") && !line.EndsWith("'''"))
                            {
                                cast(line);
                            }
                            else
                            {
                                Console.WriteLine("skipped comment on internal_script");
                            }
                        }
                    }
                    if (script_type == "EXECUTE")
                    {
                        //the script is an EXECUTE script. It will execute the command in each line one after another
                        if (!line.StartsWith("#script_type="))
                        {
                            if (!line.StartsWith("'''") && !line.EndsWith("'''"))
                            {
                                if (!line.StartsWith("#region "))
                                {
                                    //execute the line
                                    ExecuteCommand(line);
                                }
                                else if (!line.StartsWith("#endregion"))
                                {
                                    
                                    //cast to the console to start execution of a region
                                    Console.WriteLine("Started execution of region " + line.Replace("#region ", ""));
                                }
                                else
                                {
                                    Console.WriteLine("Ended executing region " + line.Replace("#endregion ", ""));
                                }
                            }
                        }
                    }
                    //2.3 version engine now supports other script_types
                }
                cast(" ");
                File.Delete("tmp." + command + ".mpf");

            }
            else
            {
                throwScriptError("internal command " + command + " does not exist in ~\\cmds\\", command, 1, 1);

            }
        }
        public void throwScriptError(string message, string fileName, int lineNm, int collumn = 0)
        {
            string fileNm = System.IO.Path.GetFullPath(fileName);
            Console.WriteLine("ScriptError: " + message + "\nOn " + fileNm + ": " + lineNm.ToString() + ", " + collumn.ToString());
            cast("ScriptError: " + message + "\nOn " + fileNm + ": " + lineNm.ToString() + ", " + collumn.ToString());
        }
        public async void ExecuteCommand(string command, int lineNum = 0)
        {
            if (command.Length < 1) return;
            if (command.StartsWith("::")) return;
            if (command.StartsWith("//") || command.StartsWith(";") || (command.StartsWith("'''") && command.EndsWith("'''")))
            {
                Console.WriteLine("Skipping comment line (" + this.runningScriptName + ".mbs: " + lineNum + ", 1)");
                return;
            }
            if (command.StartsWith("'''") && !command.EndsWith("'''"))
            {
                throwScriptError("expected \"'''\" (expression_end_comment)", this.runningScriptName, lineNum, 1);
                return;
            }
            
            string[] args = configLmf();
            string[] config = richTextBox1.Text.Split('\n');
            if (command.Contains("$."))
            {
                string[] cmd = command.Split(' ');
                foreach(string arg in cmd)
                {
                    if (arg.Contains("$."))
                    {
                        //yandere dev code lmao
                        string argv = arg.Replace("$.", "").Replace(",", "").Replace(".", "").Replace(";", "").Replace(":", "").Replace("!", "").Replace("+", "").Replace("-", "").Replace("'", "").Replace("/", "").Replace("*", "").Replace("^", "").Replace("(", "").Replace(")", "").Replace(")", "").Replace("?", "").Replace("{", "").Replace("}", "").Replace("=", "").Replace("%", "").Replace(">", "").Replace("<", "");
                        //string variableNm = cfg.Replace(argv + "=", ""); 
                        /// <summary>
                        /// Replace variables with its contents.
                        /// </summary>
                        string variableNm = findArguement(argv); 
                        Console.WriteLine("found variable (matching vconfig.lmf or config.lmf) in command request.\nReplaced: $." + argv + " with " + variableNm);
                        command = command.Replace("$." + argv, variableNm);    
                                
                            
                    }
                }
            }
            string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;

            //set the directory of the file to the directory variable
            var directory = Environment.CurrentDirectory;
            if (System.IO.File.Exists(directory + @"\cmds\" + command + ".mpf"))
            {
                execute_internal_command(command);
                return;
            }
            if (command.StartsWith("."))
            {
                if (command.Length > 1)
                {
                    string alias = command.Split(' ')[0].Replace(".", "");
                    Console.WriteLine("Found alias: " + alias + "\nAttempting sys_aliasExecute...");
                    this.executeAlias(alias);
                    return;
                }
            }
            if (command == ".")
            {
                ExecuteCommand(this.lastExecutedCmd);
                return;
            }
            this.lastExecutedCmd = command;

            if (command == "clear") {
                this.TextBox1.Text = ">> Cleared console";
                return;
            }
            if (command.Contains("exec "))
            {
                string filePath = command.Replace("exec ", "");
                if (filePath.EndsWith(".mbs")) cast(">> Attempting to execute script: " + filePath);
                if (!filePath.EndsWith(".mbs")) cast(">> Attempting to execute script: " + filePath + ".mbs");
                this.executeScript(filePath);
                return;
            }
            if (command.StartsWith("encrypt "))
            {
                string file = command.Replace("encrypt ", "");
                if (file.Length > 1)
                {
                    if (System.IO.File.Exists(file))
                    {
                        string filenm = System.IO.Path.GetFileNameWithoutExtension(file);
                        encryptScript(file);
                        cast(">> Encryption finished (" + filenm + ".mpf)");
                    }
                }
            }
            if (command == "account")
            {
                if (args.Length == 0)
                {
                    
                    cast("host -> config.lmf can not be found.");
                    return;
                }
                cast("* All arguements *");
                cast(this.appInfo.Text.Replace(" ", "").Replace(',', '\n'));
                cast("* Account variables * ");
                string[] all = args;
                foreach (string arg in args)
                {
                    if (all.Contains(arg))
                    {
                        if (arg.Contains("name="))
                        {
                            string username = arg.Replace("{", "").Replace("}", "").Replace("name=", "");
                            cast("username = " + username);
                        }
                    }
                }
                return;
            }
            if (command.Contains("var "))
            {
                string cmd = command.Replace("var ", "");

                if (!cmd.Contains("=") || cmd.Length < 1)
                {
                    cast("Error >> the value was not specified correctly.\nUsage: var test=Test Content");

                }
                else
                {
                    this.richTextBox1.Text = richTextBox1.Text + "\n" + cmd;
                }
                cast(cmd);
                return;
            }
            if (command.Contains("err_message"))
            {
                string msg = command.Replace("err_message ", "");
                ShowErrorBox(msg, Color.Red);
                cast(" ** ERROR OCCURED **");
                cast(msg);
                cast("Error >> $*client_error_request (The user has casted an error)");
                return;
            }
            if (command == "restart")
            {
                cast(">> restarting...");
                Form1_Load(null, null);
                this.Refresh();
                return;
            }
            if (command.Contains("echo")) command = command.Replace(">", "^>");
            if (command.Contains("log"))
            {
                string terminalName = "Log";
                if (this.runningScriptStatus == true) terminalName = this.runningScriptName;
                string ch = ">";
                string msg = command.Replace("log ", "").Replace(ch, "^>");
                cast(terminalName + " >> " + msg);
                return;
            }
            Console.WriteLine("executing >> " + command);
            if (command == "quit")
            {
                cast(">> executing Application_stop()");
                await System.Threading.Tasks.Task.Delay(1000);
                CheckKeyword("_", Color.AliceBlue, 0);
                CheckKeyword("stop", Color.Red, 0);
                cast(">> quitting...");
                CheckKeyword("_", Color.AliceBlue, 0);
                CheckKeyword("stop", Color.Red, 0);
                await System.Threading.Tasks.Task.Delay(1000);
                Environment.Exit(0);
            }
            // Start the child process.
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c " + command;
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            if (command.StartsWith("title") || command.StartsWith("::") || command.StartsWith(": ")) return;
            string output = p.StandardOutput.ReadToEnd();
            //p.WaitForExit();
            if (output != null)
            {
                if (output.Length < 1)
                {
                    if (command.StartsWith("cd"))
                    {
                        if (command.Length > 3)
                        {
                            if (Directory.Exists(command.Replace("cd ", "")))
                            {
                                cast(">> Current directory changed to " + command.Replace("cd ", ""));
                                this.current_directory.Text = Environment.CurrentDirectory.ToString();

                            }
                            else
                            {
                                cast(">> The directory does not exist.");
                                
                            }
                            return;
                        } 
                    }
                    if (false) { }
                    else
                    {
                        cast(">> Console returned null (err_unknown_cmd)");
                        // the command is not a native internal cd command
                    }

                    return;
                }
                cast(output);
            }
            else
            {
                cast(">> Console returned null");
            }
        }
        private void TextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                progressBar2.Value = 0;
                progressBar2.Maximum = 100;
                progressBar2.PerformStep();
                progressBar2.PerformStep();
                progressBar2.PerformStep();
                progressBar2.PerformStep();
                progressBar2.PerformStep();
                progressBar2.PerformStep();
                progressBar2.PerformStep();
                progressBar2.PerformStep();
                progressBar2.PerformStep();
                progressBar2.PerformStep();
                progressBar2.PerformStep();
                progressBar2.PerformStep();

                if (!commandRequester.Text.Contains("echo")) cast("client >> " + commandRequester.Text);
                ExecuteCommand(commandRequester.Text);
                commandRequester.Text = "";
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void cast(string message)
        {
            this.TextBox1.Text = this.TextBox1.Text + "\n" + message;
            if (message.Contains(">>") || message.Contains('\n'))
            {
                Console.WriteLine(message); 
            }
            else
            {
                Console.WriteLine("console >> " + message);

            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextBox1.Text.Length > 17386)
            {
                TextBox1.ScrollToCaret();
                TextBox1.Text = ">> Cleared Console due to lag caused by length. ((byte-16)consoleTxt > (byte-8)17386)";
                
            }
            CheckKeyword(">>", Color.BlueViolet, 0);
            CheckKeyword("(err_unknown_cmd)", Color.DarkRed, 0);
            CheckKeyword("*", Color.YellowGreen, 0);
            CheckKeyword("Application", Color.DarkSlateBlue, 0);
            CheckKeyword("client", Color.Violet, 0);
            CheckKeyword("->", Color.BlueViolet, 0);
            CheckKeyword(";", Color.BlueViolet, 0);
            CheckKeyword("--", Color.BlueViolet, 0);
            CheckKeyword("-", Color.BlueViolet, 0);
            CheckKeyword("@", Color.OrangeRed, 0);
            CheckKeyword("if ", Color.Purple, 0);
            CheckKeyword("else ", Color.Purple, 0);
            CheckKeyword("()", Color.Crimson, 0);
            CheckKeyword("1", Color.LightGreen, 0);
            CheckKeyword("2", Color.LightGreen, 0);
            CheckKeyword("3", Color.LightGreen, 0);
            CheckKeyword("4", Color.LightGreen, 0);
            CheckKeyword("5", Color.LightGreen, 0);
            CheckKeyword("6", Color.LightGreen, 0);
            CheckKeyword("7", Color.LightGreen, 0);
            CheckKeyword("8", Color.LightGreen, 0);
            CheckKeyword("9", Color.LightGreen, 0);
            CheckKeyword("0", Color.LightGreen, 0);

            CheckKeyword("MbConsole", Color.DarkSlateBlue, 0);
            CheckKeyword("Console", Color.DarkSlateBlue, 0);
            CheckKeyword("sided", Color.Violet, 0);
            CheckKeyword("developer", Color.Orange, 0);
            CheckKeyword("execute", Color.DarkSlateBlue, 0);
            CheckKeyword("Execute", Color.DarkSlateBlue, 0);
            CheckKeyword("Executing", Color.DarkSlateBlue, 0);
            CheckKeyword("executing", Color.DarkSlateBlue, 0);
            CheckKeyword("quit", Color.DarkRed, 0);

            CheckKeyword("quitting...", Color.Red, 0);

            CheckKeyword("returned", Color.Purple, 0);
            CheckKeyword("null", Color.DarkRed, 0);

            CheckKeyword("~", Color.BlueViolet, 0);
            CheckKeyword("#", Color.DarkRed, 0);
            CheckKeyword("X", Color.Orange, 0);
            CheckKeyword("Y", Color.Green, 0);
            CheckKeyword("=", Color.DarkOrange, 0);
            CheckKeyword("\"", Color.Blue, 0);
            CheckKeyword(":", Color.Aqua, 0);
            TextBox1.SelectionStart = TextBox1.Text.Length;
            TextBox1.ScrollToCaret();
        }

        private void commandRequester_TextChanged(object sender, EventArgs e)
        {
            //null
            return;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text = "owo";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.richTextBox1.Text = richTextBox1.Text.Replace("%devCmd%", this.developer.ToString().ToLower()).Replace("%skipload%", this.loadSkip.ToString().ToLower());
            string[] lines = this.richTextBox1.Text.Replace('\n', ',').Replace(" ", "").Split(',');
            this.appInfo.Text = "";
            foreach (string line in lines)
            {
                if (line.Length > 1)
                {
                    if (this.appInfo.Text.Length > 1)
                    {
                        this.appInfo.Text = this.appInfo.Text + ", {" + line + "}";

                    }
                    else
                    {
                        this.appInfo.Text = "{" + line + "}";

                    }
                }


            }
        }
    }
}
