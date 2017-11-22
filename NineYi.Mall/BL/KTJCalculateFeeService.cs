using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NineYi.Mall.BE;

namespace NineYi.Mall.BL
{
    /// <summary>
    /// KTJCalculateFeeService
    /// </summary>
    internal class KTJCalculateFeeService : ICalculateFeeService
    {
        /// <summary>
        /// 計算費用
        /// </summary>
        /// <param name="entity">DeliveryEntity</param>
        /// <returns>費用</returns>
        public double CalculateFee(DeliveryEntity entity)
        {
            var fee = 0d;
            var length = entity.ProductLength;
            var width = entity.ProductWidth;
            var height = entity.ProductHeight;

            var size = length * width * height;

            if (length > 50 || width > 50 || height > 50)
            {
                fee = (size * 0.00001 * 110) + 50;
            }
            else
            {
                fee = size * 0.00001 * 120;
            }

            return fee;
        }
    }
}
