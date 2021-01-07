using AppManagePharmacy.BO;
using AppManagePharmacy.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagePharmacy.BLL
{
    public class BillBLO
    {
        BillDAO BillRepo;
        public BillBLO(string dbFolder)
        {
            BillRepo = new BillDAO(dbFolder);
        }



        public void CreateBill(Bill Bill)
        {
            BillRepo.Add(Bill);
        }

        public void DeleteBill(Bill Bill)
        {
            BillRepo.Remove(Bill);
        }


        public IEnumerable<Bill> GetAllBills()
        {
            return BillRepo.Find();
        }


        public IEnumerable<Bill> GetByIdBill(string MatBill)
        {
            return BillRepo.Find(x => x.MatBill == MatBill);
        }

        public IEnumerable<Bill> GetBy(Func<Bill, bool> predicate)
        {
            return BillRepo.Find(predicate);
        }

        public void EditBill(Bill oldBill, Bill newBill)
        {
            BillRepo.Set(oldBill, newBill);
        }
    }
}
