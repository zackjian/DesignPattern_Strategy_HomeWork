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
            var weightFee = this.GetWeightFee(entity.ProductWeight);

            var volumeFee = this.GetVolumeFee(entity.ProductLength, entity.ProductWidth, entity.ProductHeight);

            if (weightFee > volumeFee)
            {
                return weightFee;
            }
            else
            {
                return volumeFee;
            }
        }

        /// <summary>
        /// GetWeightFee
        /// </summary>
        /// <param name="weight">weight</param>
        /// <returns>WeightFee</returns>
        private double GetWeightFee(double weight)
        {
            return (weight * 10) + 80;
        }

        /// <summary>
        /// GetVolumeFee
        /// </summary>
        /// <param name="length">length</param>
        /// <param name="width">width</param>
        /// <param name="height">height</param>
        /// <returns>VolumeFee</returns>
        private double GetVolumeFee(double length, double width, double height)
        {
            return length * width * height * 0.00001 * 110;
        }
    }
}
