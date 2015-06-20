using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserList.VoucherDemo
{
    public interface IQRCodeService
    {
        Task<string> Scan();
    }
}
