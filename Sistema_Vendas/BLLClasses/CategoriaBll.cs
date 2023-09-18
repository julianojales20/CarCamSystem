using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Vendas.BLLClasses
{
    class CategoriaBll
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set;}
        public DateTime added_data { get; set; }
        public int added_by { get; set; }
    }
}
