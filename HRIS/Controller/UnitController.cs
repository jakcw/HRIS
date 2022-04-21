using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using HRIS.Entities;
using HRIS.Database;

namespace HRIS.Controller
{
    class UnitController
    {
        public List<Unit> UnitList { get; set; }
        public ObservableCollection<Unit> ViewableUnits { get; set; }                                           

        public UnitController()
        {
            UnitList = DBAdapter.GetUnitDetails(123456);
            ViewableUnits = new ObservableCollection<Unit>(UnitList);
        }

        public ObservableCollection<Unit> GetViewableUnits()
        {
            return ViewableUnits;
        }
       
    }
}
