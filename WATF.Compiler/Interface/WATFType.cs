using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Compiler.Interface
{

    public class WATFDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private List<KeyValuePair<TKey, TValue>> elems = new List<KeyValuePair<TKey, TValue>>();
        public void Add(TKey key, TValue value)
        {
            elems.Add(new KeyValuePair<TKey, TValue>(key, value));
        }
        public void AddRange(WATFDictionary<TKey, TValue> elem)
        {
            elems.AddRange(elem);
        }
        public void Delete(TKey key)
        {
            KeyValuePair<TKey, TValue> delelem = new KeyValuePair<TKey,TValue>();
            foreach (KeyValuePair<TKey, TValue> elem in this.elems)
            {
                if (elem.Key.Equals(key))
                {
                    delelem = elem;
                    break;
                }
            }
            this.elems.Remove(delelem);
        }
        public TValue this[TKey key]
        {
            get 
            {
                foreach (KeyValuePair<TKey, TValue> elem in this.elems)
                {
                    if (elem.Key.Equals(key))
                        return elem.Value;
                }
                return default(TValue);
            }
        }
        public bool ContainsKey(TKey key)
        {
            foreach (KeyValuePair<TKey, TValue> elem in elems)
            { 
                if(elem.Key.Equals(key))
                    return true;
            }
            return false;
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return elems.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return elems.GetEnumerator();
        }
    }
    public class WATFContext
    {
        private static WATFContext context = null;
        public static WATFContext GetInstance()
        {
            if (context == null)
            {
                context = new WATFContext();
            }
            return context;
        }
        private WATFDictionary<String, System.Reflection.Assembly> assemblys = null;
        private WATFDictionary<String, Object> vars = null;
        private Stack<object> results = new Stack<object>();
        private WATFContext()
        {
            assemblys = new WATFDictionary<string, System.Reflection.Assembly>();
            vars = new WATFDictionary<string, Object>();
        }


        public WATFDictionary<String, System.Reflection.Assembly> Assemblys
        {
            get { return assemblys; }
            set { assemblys = value; }
        }
        public WATFDictionary<String, Object> Vars
        {
            get { return vars; }
            set { vars = value; }
        }
        public Stack<object> Results
        {
            get { return results; }
            set { results = value; }
        }

        public void SetVar(string key, object value)
        {
            this.Vars.Delete(key);
            this.Vars.Add(key,value);
        }

        public object GetVar(string key)
        {
            if (this.Vars.ContainsKey(key))
            {
                return this.Vars[key];
            }
            return key;
        }
    }
}
