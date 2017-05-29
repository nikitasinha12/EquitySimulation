using Internal_System.Framework;
using Internal_System.DataModel;
using Internal_System.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internal_System.PM_Views;

namespace Internal_System.PM_ViewModels
{
    class CreatePortfolioViewModel :ANotifyPropertyChanged
    {
        EquityEntities db;
        public Portfolio Portfolio { get; set; }
        public DelegateCommand SavePortfolio { get; set; }
        public CreatePortfolioViewModel()
        {
            db = new EquityEntities();
            SavePortfolio = new DelegateCommand(SavePortfolioPredicate, SavePortfolioAction);
            Portfolio = new Portfolio();
        }

        private void SavePortfolioAction(object obj)
        {
           if(obj!=null)
           {
               var x = obj as Portfolio;
               x.CreationDate = DateTime.Now;
               x.UpdationDate = DateTime.Now;
               x.ISActive = true;
               x.UserID = Session.CurrentUser.UserID;
               db.Portfolios.Add(x);
               db.SaveChanges();
           }
        }

        private bool SavePortfolioPredicate(object obj)
        {
            return true;
        }
    }
}
