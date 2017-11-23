using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NineYi.Mall.BE;

namespace NineYi.Mall.BL
{
    /// <summary>
    /// ICalculateFeeService
    /// </summary>
    public interface ICalculateFeeService
    {
        /// <summary>
        /// 計算費用
        /// </summary>
        /// <param name="entity">DeliveryEntity</param>
        /// <returns>費用</returns>
        double CalculateFee(DeliveryEntity entity);
    }
}
