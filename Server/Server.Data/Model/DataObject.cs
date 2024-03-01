using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Model
{
    public class DataObject : BaseMadel
    {
        public int Code { get; set; }
        public string Value { get; set; }
    }
}
