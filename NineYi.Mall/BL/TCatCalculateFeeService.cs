using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NineYi.Mall.BE;

namespace NineYi.Mall.BL
{
    /// <summary>
    /// TCatCalculateFeeService
    /// </summary>
    internal class TCatCalculateFeeService : ICalculateFeeService
    {
        /// <summary>
        /// 計算費用
        /// </summary>
        /// <param name="entity">DeliveryEntity</param>
        /// <returns>費用</returns>
        public double CalculateFee(DeliveryEntity entity)
        {
            var fee = 0d;
            var weight = entity.ProductWeight;

            if (weight > 20)
            {
                fee = 400d;
            }
            else
            {
                fee = 100 + (weight * 10);
            }            

            return fee;
        }
    }
}
