using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic value = new SpecialDynamic();
            var propName = "DynamicStuff";
            value.Value = "value";
            value.Stuff = "extra";
            value[propName] = "Another Value";
            var serialize = JsonConvert.SerializeObject(value);
            var properties = value.GetDynamicMemberNames();
            Console.WriteLine();
            Console.WriteLine(serialize);
        }
    }
}
