using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Compiler.Executive.Test.Step.Action.Master
{
    public class Select : Keyword
    {
        public Select(object context) : base(context) { }
        public override int Init(string value = "")
        {
            throw new NotImplementedException();
        }

        public override void UnInit(string value = "")
        {
            throw new NotImplementedException();
        }

        protected override Object InExecutive(Interface.WATFDictionary<String, String> attributes)
        {
            object rtn = default(object);
            if (this.context.Assemblys.ContainsKey(attributes[GlobalDefine.Keyword.Executive.From]))
            {
                //执行反射外部函数
                WATF.Plugin.IPlugin reflection = (WATF.Plugin.IPlugin)this.context.Assemblys[attributes[GlobalDefine.Keyword.Executive.From]].CreateInstance(attributes[GlobalDefine.Keyword.Executive.Select]);
                Dictionary<string, object> paramList = GetParamsFromWhere(attributes[GlobalDefine.Keyword.Executive.Where],this.context);
                if (this.context.Results.Count > 0)
                {
                    rtn = reflection.StartMethod(this.context.Results.Peek(), paramList);
                }
                else
                {
                    rtn = reflection.StartMethod(null, paramList);
                }
                if (attributes.ContainsKey(GlobalDefine.Keyword.Executive.Into)
                && !attributes[GlobalDefine.Keyword.Executive.Into].Equals(string.Empty))
                {
                    this.context.SetVar(attributes[GlobalDefine.Keyword.Executive.Into], rtn);
                }
            }
            else//如果没有from关键字，则执行内部函数逻辑
            { 
            
            }
            return rtn;
        }
        protected override void OutExecutive(Interface.WATFDictionary<String, String> attributes)
        {
            if (this.context.Assemblys.ContainsKey(attributes[GlobalDefine.Keyword.Executive.From]))
            {
                //执行反射外部函数
                WATF.Plugin.IPlugin reflection = (WATF.Plugin.IPlugin)this.context.Assemblys[attributes[GlobalDefine.Keyword.Executive.From]].CreateInstance(attributes[GlobalDefine.Keyword.Executive.Select]);
                reflection.EndMethod();
            }
            else//如果没有from关键字，则执行内部函数逻辑
            { 
            
            }
        }

        private Dictionary<string, object> GetParamsFromWhere(string whereKey,Interface.WATFContext context)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(whereKey))
            {
                string[] paramList = whereKey.Split(';');
                foreach (string param in paramList)
                {
                    string[] keyValue = param.Split('=');
                    if (keyValue.Length == 2)
                    {
                        rtn.Add(keyValue[0], context.GetVar(keyValue[1]));
                    }
                }
            }
            return rtn;
        }
    }
}
