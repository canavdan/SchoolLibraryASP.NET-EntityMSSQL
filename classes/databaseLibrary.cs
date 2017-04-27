using LibraryProject.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
namespace LibraryProject
{
    public class databaseLibrary
    {
        librarydbEntities db = new librarydbEntities();
        MembershipUser user = Membership.GetUser();

        public Boolean hasPenalty(String username)
        {

            return false;
        }
        public void setAvaibleZero(int matID)
        {
            material mat = db.materials.FirstOrDefault(x => x.matID == matID);
            mat.avaible = false;

            db.SaveChanges();

        }
        public Boolean hasBookAvaible(int matID)
        {
            Boolean avaible = (Boolean)db.materials.FirstOrDefault(x => x.matID == matID).avaible;

            return avaible;
        }
        public void setAvaibleOne(int matID)
        {
            material mat = db.materials.FirstOrDefault(x => x.matID == matID);
            mat.avaible = true;

            db.SaveChanges();
        }
        public Boolean increaseExtend(String loanID)
        {
            String[] role = Roles.GetRolesForUser(user.UserName);
            loan_DB2 loanDB2 = db.loan_DB2.SingleOrDefault(x => x.loanID == loanID);
            if (role.Contains("student"))
            {
                if (loanDB2.extends > 1)
                    return false;
                else
                {
                    DateTime datetime = (DateTime)loanDB2.duedate;

                    loanDB2.extends = loanDB2.extends + 1;
                    loanDB2.duedate = datetime.AddMonths(1);
                    db.SaveChanges();
                    return true;
                }

            }
            else if (role.Contains("teacher"))
            {
                if (loanDB2.extends > 3)
                    return false;
                else
                {
                    DateTime datetime = (DateTime)loanDB2.duedate;

                    loanDB2.extends = loanDB2.extends + 1;
                    loanDB2.duedate = datetime.AddMonths(1);
                    db.SaveChanges();
                    return true;
                }
            }
            else//undergrade
            {
                if (loanDB2.extends > 2)
                    return false;
                else
                {
                    DateTime datetime = (DateTime)loanDB2.duedate;

                    loanDB2.extends = loanDB2.extends + 1;
                    loanDB2.duedate = datetime.AddMonths(1);
                    db.SaveChanges();
                    return true;
                }
            }
            //return false;
        }
        public Boolean hasAvaibletoTake()
        {
            String[] role = Roles.GetRolesForUser(user.UserName);
            if (role.Contains("admin") || role.Contains("moderator"))
                return false;

            return true;
        }
        public Boolean changePass(String memID, String newpass)
        {

            MembershipUser u = Membership.GetUser(memID);

            return u.ChangePassword(u.GetPassword(), newpass);
            // return true;
        }
        public int calculatePenalty(String userID)
        {
            int mID = Convert.ToInt32(userID);

            penaltyDB3 penalty = db.penaltyDB3.FirstOrDefault(x => x.memID == mID);
            DateTime oldDate = (DateTime)penalty.date;
            DateTime now = DateTime.Now;
            TimeSpan ts = now - oldDate;
            return (ts.Days) * 3;

        }
        public void controlPenalty()
        {
            var query = db.loan_DB2.ToList();

            foreach(loan_DB2 x in query)
            {
                if (DateTime.Now > x.duedate)
                {
                    penaltyDB3 penalty = new penaltyDB3();
                    penalty.matID = x.matID;
                    penalty.memID = x.memID;
                    penalty.date = x.duedate;
                }
            }

        }
    }
}