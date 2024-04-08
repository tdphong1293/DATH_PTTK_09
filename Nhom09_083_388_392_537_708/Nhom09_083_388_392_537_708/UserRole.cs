using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom09_083_388_392_537_708
{
    public class RoleEventArgs : EventArgs
    {
        public string Role { get; }

        public RoleEventArgs(string role)
        {
            Role = role;
        }
    }
}
