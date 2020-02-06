using Bank.BL.Model;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Bank.BL
{ 
    /// <summary>
    /// Realised info saving in file
    /// </summary>
    public class AccountController
    {
        /// <summary>
        /// Save info in file
        /// </summary>
        /// <param name="accounts"></param>
        public void Save(Account[] accounts)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("Accounts.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, accounts);
            }
        }

        /// <summary>
        /// Load info from file
        /// </summary>
        /// <returns></returns>
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
