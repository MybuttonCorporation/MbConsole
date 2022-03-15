''' BEGIN APPLICATION '''
''' applicationStart.mpf (mybutton package file) = starts MbConsole directly through an internal script instead of the Form to start itself. '''

#script_type=EXECUTE
::Console-AvailableSystemInformation 		= resetInformation() &!info => info;
::Console-LoadApplication			= this.Show() &! data => dbParseAsMbLmf("./config.lmf");
::Gui-EnableVisualStyles			= false
::Gui-Show					= Form1.MbConsole
::DevCmd-allowed				= if(consoleArgs &! length(0) &= contains(.args/devCmd) ; true) ? 'NO' : 'YES'
::Application.StartOnLoad			= ExecuteCommandNow(1);
title MbConsole Debugging Terminal (admin-only)
echo >> MbConsole (version 2.3, developer)
echo ** Application Available for client-sided use **