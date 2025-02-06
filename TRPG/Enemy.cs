using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    internal class Enemy : IStatus
    {
        int IStatus.hp { get ; set ; }
        int IStatus.mp { get ; set ; }
        int IStatus.atk { get; set; }
        int IStatus.def { get ; set; }
    }
}
