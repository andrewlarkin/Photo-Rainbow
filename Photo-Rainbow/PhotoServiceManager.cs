using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo_Rainbow
{
    class PhotoServiceManager
    {
        public static IAPIManager manager;

        public void LoadManager(IAPIManager m)
        {
            manager = m;
        }

        public void Authenticate()
        {
            manager.Authenticate();
        }
    }
}
