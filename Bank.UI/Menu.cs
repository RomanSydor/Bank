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
        public string Greeting { get; } = "We are welcome you in RS Bank!\nPlease choose one of services:\n";
        public string ReturnToMenu { get; } = "Do you want to return to the menu?\n1)yes\n2)no";
        public string TopUpString { get; } = "Input amount of top up: ";
        public double TopUp { get; set; }
        public string Choose { get; set; }
    }
}
