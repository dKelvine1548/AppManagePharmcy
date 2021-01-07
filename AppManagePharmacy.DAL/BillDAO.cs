using AppManagePharmacy.BO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagePharmacy.DAL
{
    public class BillDAO
    {
        private List<Bill> bills;
        private const string FILE_NAME = @"Bill.json";
        private readonly string dbFolder;
        private FileInfo file;

        public BillDAO(string dbFolder)
        {
            this.dbFolder = dbFolder;

            file = new FileInfo(Path.Combine(this.dbFolder, FILE_NAME));
            if (!file.Directory.Exists)
            {
                file.Directory.Create();
            }
            if (!file.Exists)
            {
                file.Create().Close();
                file.Refresh();
            }

            if (file.Length > 0)
            {
                using (StreamReader sr = new StreamReader(file.FullName))
                {
                    string json = sr.ReadToEnd();
                    bills = JsonConvert.DeserializeObject<List<Bill>>(json);
                }
            }
            if (bills == null)
            {
                bills = new List<Bill>();
            }
        }
        public void Set(Bill oldBill, Bill newBill)
        {
            var oldIndex = bills.IndexOf(oldBill);
            var newIndex = bills.IndexOf(newBill);
            if (oldIndex < 0)
                throw new KeyNotFoundException("the bill doesn't exists !");
            if (newIndex >= 0 && oldIndex != newIndex)
                throw new DuplicateNameException("This idBill already exists !");
            bills[oldIndex] = newBill;

            Save();
        }

        public void Add(Bill bill)
        {
            var index = bills.IndexOf(bill);
            if (index >= 0)
                throw new DuplicateNameException("this Bill reference already exist !");
            bills.Add(bill);
            Save();
        }

        private void Save()
        {
            using (StreamWriter sw = new StreamWriter(file.FullName))
            {
                string json = JsonConvert.SerializeObject(bills);
                sw.WriteLine(json);
            }
        }
        public void Remove(Bill bill)
        {
            bills.Remove(bill);
            Save();
        }
        public IEnumerable<Bill> Find()
        {
            return new List<Bill>(bills);
        }

        public IEnumerable<Bill> Find(Func<Bill, bool> predicate)
        {
            return new List<Bill>(bills.Where(predicate).ToArray());
        }

    }
}

