using System;
using NineYi.Mall.BE;

namespace NineYi.Mall.BL
{
    /// <summary>
    /// 宅配Service
    /// </summary>
    public class DeliveryService
    {
        /// <summary>
        /// 計算運費
        /// </summary>
        /// <param name="deliveryItem">宅配資料</param>
        /// <returns>運費</returns>
        public double Calculate(DeliveryEntity deliveryItem)
        {
            if (deliveryItem == null)
            {
                throw new ArgumentException("請檢查 deliveryItem 參數");
            }

            ICalculateFeeService calculateFeeService = this.CalculateFeeServiceFactory(deliveryItem.DeliveryType);

            return calculateFeeService.CalculateFee(deliveryItem);
        }

        /// <summary>
        /// CalculateFeeService 工廠
        /// </summary>
        /// <param name="deliveryType">DeliveryTypeEnum</param>
        /// <returns>ICalculateFeeService</returns>
        public ICalculateFeeService CalculateFeeServiceFactory(DeliveryTypeEnum deliveryType)
        {
            if (deliveryType == DeliveryTypeEnum.TCat)
            {
                return new TCatCalculateFeeService();
            }
            else if (deliveryType == DeliveryTypeEnum.KTJ)
            {
                return new KTJCalculateFeeService();
            }
            else if (deliveryType == DeliveryTypeEnum.PostOffice)
            {
                return new PostOfficeCalculateFeeService();
            }
            else
            {
                throw new ArgumentException("請檢查 deliveryItem.DeliveryType 參數");
            }
        }
    }
}
