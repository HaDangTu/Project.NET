using MotelManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MotelManagement.ViewModels
{
    public class DebtViewModels
    {
       public IEnumerable<AllPowerDebtViewModel> allPowerDebts { get; set; }
       public IEnumerable<AllRoomDebtViewModel> allRoomDebts { get; set; }
    }
}