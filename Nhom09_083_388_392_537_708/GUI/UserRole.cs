using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class RoleEventArgs : EventArgs
    {
        public string Role { get; }
        public string username { get; }

        public string id { get; }
        public RoleEventArgs(string role, string username, string id)
        {
            this.Role = role;
            this.username = username;
            this.id = id;
        }
    }
}
