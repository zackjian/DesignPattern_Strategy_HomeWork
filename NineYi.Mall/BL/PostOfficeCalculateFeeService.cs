using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NineYi.Mall.BE;

namespace NineYi.Mall.BL
{
    /// <summary>
    /// PostOfficeCalculateFeeService
    /// </summary>
    internal class PostOfficeCalculateFeeService : ICalculateFeeService
    {
        /// <summary>
        /// 計算費用
        /// </summary>
        /// <param name="entity">DeliveryEntity</param>
        /// <returns>費用</returns>
        public double CalculateFee(DeliveryEntity entity)
        {
            var length = entity.ProductLength;
            var width = entity.ProductWidth;
            var height = entity.ProductHeight;
            var weight = entity.ProductWeight;

            var weightFee = (weight * 10) + 80;

            var volumeFee = length * width * height * 0.00001 * 110;

            if (weightFee > volumeFee)
            {
                return weightFee;
            }
            else
            {
                return volumeFee;
            }
        }
    }
}
