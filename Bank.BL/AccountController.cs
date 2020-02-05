using Bank.BL.Model;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Bank.BL
{
    public class AccountController
    {
        public void Save(Account[] accounts)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("Accounts.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, accounts);
            }
        }

        public Account[] Load()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("Accounts.bin", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is Account[] accounts)
                {
                    return accounts;
                }
                else
                {
                    return new Account[] { };
                }
            }
        }

    }
}
