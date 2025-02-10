using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace TRPG
{
    internal interface IStatus
    {
        int hp { get; set; }
        int mp { get; set; }
        int atk { get; set; }
        int def { get; set; }
    }
}
