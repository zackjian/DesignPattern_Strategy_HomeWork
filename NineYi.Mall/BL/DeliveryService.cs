using System;
using System.Collections.Generic;
using System.Linq;
using NineYi.Mall.BE;

namespace NineYi.Mall.BL
{
    /// <summary>
    /// 宅配Service
    /// </summary>
    public class DeliveryService
    {
        /// <summary>
        /// CalculateFeeDictionary
        /// </summary>
        private IReadOnlyDictionary<Func<DeliveryTypeEnum, bool>, ICalculateFeeService> _calculateFeeDictionary =
            new Dictionary<Func<DeliveryTypeEnum, bool>, ICalculateFeeService>
        {
            { (type) => type == DeliveryTypeEnum.TCat, new TCatCalculateFeeService() },
            { (type) => type == DeliveryTypeEnum.KTJ, new KTJCalculateFeeService() },
            { (type) => type == DeliveryTypeEnum.PostOffice, new PostOfficeCalculateFeeService() }
        };

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

            ICalculateFeeService calculateFeeService = 
                this._calculateFeeDictionary.FirstOrDefault(x => x.Key(deliveryItem.DeliveryType)).Value;

            return calculateFeeService.CalculateFee(deliveryItem);
        }
    }
}
