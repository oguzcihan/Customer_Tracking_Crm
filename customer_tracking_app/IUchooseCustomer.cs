using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customer_tracking_app
{
    public delegate void musteriSecildiHandle();
    interface IUchooseCustomer
    {
        event musteriSecildiHandle MusteriSecildi;
    }
}
