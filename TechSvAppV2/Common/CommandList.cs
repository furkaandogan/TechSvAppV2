using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Common
{
    public class CommandList : IDisposable
    {
        #region Fields

        private  Dictionary<string, ICommand> commandList;
        private  CommandList _instance;
        public CommandList Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CommandList();

                return _instance;
            }
        }

        #endregion

        public CommandList()
        {
            commandList = new Dictionary<string, ICommand>();
        }

        public ICommand this[string name]
        {
            get
            {
                if (commandList.ContainsKey(name))
                    return commandList[name];
                else
                    return null;
            }
        }

        public Dictionary<string, ICommand> List
        {
            get { return commandList; }
        }

        public void AddCommand(string name, ICommand cmd)
        {
            if (commandList.ContainsKey(name))
                commandList[name] = cmd;
            else
                commandList.Add(name, cmd);
        }

        public void Dispose()
        {
            commandList.Clear();
        }
    }
}

