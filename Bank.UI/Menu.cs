using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.UI
{
    public class Menu
    {
        public string Services { get; } = "1)Create account;\n2)Top up your account;\n3)Withdraw money;\n4)Close accuont;";
        public string Greeting { get; } = "We are welcome you in RS Bank!\n\nPlease choose one of services:\n";
        public string ReturnToMenu { get; } = "\nDo you want to return to the menu?\n1)yes\n2)no";
        public double TopUp { get; set; }
        public string Choose { get; set; }
    }
}
