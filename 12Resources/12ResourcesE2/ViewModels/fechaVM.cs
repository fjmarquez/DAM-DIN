using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12ResourcesE2.ViewModels
{
    public class fechaVM
    {

        private DateTime now;

        public DateTime Now
        {
            get
            {
                return this.now;
            }
            set
            {
                this.now = value;
            }
        }

        public fechaVM()
        {
            now = DateTime.Now;
        }

    }
}
