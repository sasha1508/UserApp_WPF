using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp_WPF
{
    class User
    {
        int id { get;set;}
        string login, pass, email;

        public User() { }

        public User(int id, string login, string pass, string email)
        {
            this.id = id;
            this.login = login;
            this.pass = pass;
            this.email = email;
        }
    }
}
