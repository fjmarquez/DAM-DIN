using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDXamarinUI.Views
{

    public class MainMDMasterMenuItem
    {
        public MainMDMasterMenuItem()
        {
            TargetType = typeof(MainMDMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}