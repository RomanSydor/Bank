using Bank.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Bank.BL
{
    public class CustomerControler
    {
        Customer customer { get; }

        public void Save(Account[] accounts)
        {
            var formatter = new BinaryFormatter();
            var fileName = typeof(Account).Name;

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate)) 
            {
                formatter.Serialize(fs, accounts);
            }
        }

        public Account Load(Account[] account, int id) 
        {
            var formatter = new BinaryFormatter();
            var fileName = typeof(Account).Name;

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is Account[] accounts)
                {
                    return account[id - 1];
                }
                else 
                {
                    return null;
                }
            }
        }
    }
}
