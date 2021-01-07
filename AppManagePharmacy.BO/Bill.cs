using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagePharmacy.BO
{
    [Serializable]
    public class Bill
    {
        // public static int count = 0;
        public string MatBill { get; set; }

        public string NameDrug { get; set; }
        public string CategoryDrug { get; set; }
        // public string DrugPicture { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public long Contacts { get; set; }
        //public string Email { get; set; }
        public DateTime Date { get; set; }
        //public string PharmacyLogo { get; set; }
        public double AmountPaid { get; set; }

        public Bill()
        {
            //count++;
        }

        public Bill(string matBill, string nameDrug, string categoryDrug,
           int quantity, double unitPrice, long contact, DateTime date, double amountPaid)
        {
            MatBill = matBill;

            NameDrug = nameDrug;
            CategoryDrug = categoryDrug;
            //DrugPicture = drugPicture;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Contacts = contact;
            //Email = email;
            Date = date;
            AmountPaid = amountPaid;

            // PharmacyLogo = pharmacyLogo;
        }

        public override bool Equals(object obj)
        {
            return obj is Bill bill &&
                   MatBill == bill.MatBill;
        }
        public double Mount()
        {
            return UnitPrice * Quantity;
        }
        public override int GetHashCode()
        {
            return 351837860 + EqualityComparer<string>.Default.GetHashCode(MatBill);
        }
    }

}

