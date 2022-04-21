using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using HRIS.Database;
using HRIS.Entities;

namespace HRIS.Controller
{
    class StaffController
    {
        public List<Staff> Staff { get; set; }
        public ObservableCollection<Staff> ViewableStaff { get; set; }

        public StaffController()
        {
            Staff = DBAdapter.GetStaffDetails();
            ViewableStaff = new ObservableCollection<Staff>(Staff);
        }

        public ObservableCollection<Staff> GetViewableList()
        {
            return ViewableStaff;
        }


    }
}
