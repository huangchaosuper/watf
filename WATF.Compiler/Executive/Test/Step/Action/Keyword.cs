using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Compiler.Executive.Test.Step.Action
{
    public abstract class Keyword:Interface.IWATFApp
    {
        protected Interface.WATFContext context = null;
        public Keyword(object context)
        {
            this.context = (Interface.WATFContext)context;
        }

        public abstract int Init(string value = "");

        public object Run(object value = null)
        {
            //throw new NotImplementedException();
            Action CurAction = (Action)value;
            this.context.Results.Push(InExecutive(CurAction.m_Attributes));
            //select do something
            foreach (KeyValuePair<String, Interface.WATFPathNavigator> ActionChild in CurAction.m_ActionChilds)
            {
                if (ActionChild.Key.Equals(GlobalDefine.Keyword.Executive.Action))
                {
                    ActionChild.Value.Run(this.context);
                }
            }
            OutExecutive(CurAction.m_Attributes);
            this.context.Results.Pop();
            return default(object);
        }

        public abstract void UnInit(string value = "");

        protected abstract void OutExecutive(Interface.WATFDictionary<string, string> wATFDictionary);

        protected abstract Object InExecutive(Interface.WATFDictionary<string, string> wATFDictionary);

    }
}
