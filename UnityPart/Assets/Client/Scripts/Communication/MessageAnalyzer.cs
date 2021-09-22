using System;
using System.Collections.Generic;

namespace Client.Scripts.Communication
{
    public class MessageAnalyzer: IMessageAnalyzer
    {
        private const string prefix = "TypeName:";

        private Dictionary<string, Action<string>> commandList;

        public MessageAnalyzer(Dictionary<string, Action<string>> commandList)
        {
            this.commandList = commandList;
        }

        public void Analyze(string message)
        {
            var units = message.Split(new []{prefix}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var unit in units)
            {
                var typeIndexEnd = unit.IndexOf(')');
                var key = unit.Substring(1, typeIndexEnd - 1);
                var value = unit.Substring(typeIndexEnd + 1);
                if (!commandList.ContainsKey(key))
                    throw new ArgumentException("Command list doesn't contain command for key: " + key);
                commandList[key]?.Invoke(value);
            }
        }
    }
}