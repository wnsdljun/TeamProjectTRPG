using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    internal interface IStatus
    {
        int hp { get; }
        int mp { get; }
        int atk { get; }
        int def { get; }
    }
}
