using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Dynamic
{
    public class SpecialDynamic : DynamicObject
    {
        private readonly Dictionary<string,object> _members = new Dictionary<string, object>(); 
        [JsonProperty]
        public string Value { get; set; }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _members.Add(binder.Name, value);
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = _members[binder.Name];
            return true;
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            result = _members[indexes.First().ToString()];
            return true;
        }

        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            _members[indexes.First().ToString()] = value;
            return true;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _members.Keys;
        }
    }
}
