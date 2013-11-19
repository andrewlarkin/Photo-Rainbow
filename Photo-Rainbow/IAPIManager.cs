using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo_Rainbow
{
    public interface IAPIManager
    {
        void Authenticate();

        List<Image> GetPhotos();

        Boolean IsAuthenticated();
    }
}
