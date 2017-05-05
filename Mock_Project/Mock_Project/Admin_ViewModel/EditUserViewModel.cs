using Mock_Project.Commands;
using Mock_Project.DataModel;
using Mock_Project.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_Project.Admin_ViewModel
{
    class EditUserViewModel : ANotifyPropertyChanged
    {
        EquityEntities db;
        public User newUser { get; set; }
        public DelegateCommand EditUser { get; set; }
        public EditUserViewModel ()
	    {
            newUser=new User();
            db=new EquityEntities();
            EditUser=new DelegateCommand(EditUserPredicate,EditUserAction);
	    }
        private bool EditUserPredicate(object obj)
        {
            return true;
        }
        private void EditUserAction(object obj)
        {
            
            if (obj == null)
                return;
            else
            {
                var selectedUser = obj as User;


                var underEditUser = db.Users.Find(selectedUser.UserID);

                underEditUser.UpdationDate = DateTime.Now.Date;
                underEditUser.LName = selectedUser.LName;
                underEditUser.FName = selectedUser.FName;
                var userRoleList = selectedUser.User_Role.Select(s=> s.RoleID).ToList();

                #region Set User Roles
                if (Admin_Views.EditUser.PM)
                {
                    if (!userRoleList.Contains(2))
                        db.User_Role.Add(new User_Role() { UserID = selectedUser.UserID, RoleID = 2, ISActive = true, CreationDate = DateTime.Now, UpdationDate = DateTime.Now });
                    else
                    {
                        var userRoleTemp = selectedUser.User_Role.Where(t => t.RoleID == 2).FirstOrDefault();
                        if (!userRoleTemp.ISActive)
                        {
                            userRoleTemp = db.User_Role.Find(userRoleTemp.UserRoleID);
                            userRoleTemp.ISActive = true;
                            db.Entry(userRoleTemp).State = EntityState.Modified;
                        }
                    }
                }
                else
                {
                    if (userRoleList.Contains(2))
                    {
                        var userRoleTemp = selectedUser.User_Role.Where(t => t.RoleID == 2).FirstOrDefault();
                        if (userRoleTemp.ISActive)
                        {
                            userRoleTemp = db.User_Role.Find(userRoleTemp.UserRoleID);
                            userRoleTemp.ISActive = false;
                            db.Entry(userRoleTemp).State = EntityState.Modified;
                        }
                    }
                }

                if (Admin_Views.EditUser.Trader)
                {
                    if (!userRoleList.Contains(1))
                        db.User_Role.Add(new User_Role() { UserID = selectedUser.UserID, RoleID = 1, ISActive = true, CreationDate = DateTime.Now, UpdationDate = DateTime.Now });
                    else
                    {
                        var userRoleTemp = selectedUser.User_Role.Where(t => t.RoleID == 1).FirstOrDefault();
                        if (!userRoleTemp.ISActive)
                        {
                            userRoleTemp = db.User_Role.Find(userRoleTemp.UserRoleID);
                            userRoleTemp.ISActive = true;
                            db.Entry(userRoleTemp).State = EntityState.Modified;
                        }
                    }
                }
                else
                {
                    if (userRoleList.Contains(1))
                    {
                        var userRoleTemp = selectedUser.User_Role.Where(t => t.RoleID == 1).FirstOrDefault();
                        if (userRoleTemp.ISActive)
                        {
                            userRoleTemp = db.User_Role.Find(userRoleTemp.UserRoleID);
                            userRoleTemp.ISActive = false;
                            db.Entry(userRoleTemp).State = EntityState.Modified;
                        }
                    }
                }

                if (Admin_Views.EditUser.Admin)
                {
                    if (!userRoleList.Contains(3))
                        db.User_Role.Add(new User_Role() { UserID = selectedUser.UserID, RoleID = 3, ISActive = true, CreationDate = DateTime.Now, UpdationDate = DateTime.Now });
                    else
                    {
                        var userRoleTemp = selectedUser.User_Role.Where(t => t.RoleID == 3).FirstOrDefault();
                        if (!userRoleTemp.ISActive)
                        {
                            userRoleTemp = db.User_Role.Find(userRoleTemp.UserRoleID);
                            userRoleTemp.ISActive = true;
                            db.Entry(userRoleTemp).State = EntityState.Modified;
                        }
                    }
                }
                else
                {
                    if (userRoleList.Contains(3))
                    {
                        var userRoleTemp = selectedUser.User_Role.Where(t => t.RoleID == 3).FirstOrDefault();
                        if (userRoleTemp.ISActive)
                        {
                            userRoleTemp = db.User_Role.Find(userRoleTemp.UserRoleID);
                            userRoleTemp.ISActive = false;
                            db.Entry(userRoleTemp).State = EntityState.Modified;
                        }
                    }
                } 
                #endregion


                db.Entry(underEditUser).State = EntityState.Modified;
                db.SaveChanges(); 
            }
        }
    }
}
