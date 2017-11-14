using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NineYi.Mall.BE;

namespace NineYi.Mall.BL
{
    public class DeliveryService
    {
        public decimal Calculate(DeliveryEntity deliveryItem)
        {
            if (deliveryItem.DeliveryType == DeliveryTypeEnum.TCat)
            {
                this.lblCompany.Text = "黑貓";
                var weight = deliveryItem.ProductWeight;
                if (weight > 20)
                {
                    this.lblCharge.Text = "500";
                }
                else
                {
                    var fee = 100 + weight * 10;
                    this.lblCharge.Text = fee.ToString();
                }
            }
            else if (deliveryItem.DeliveryType == DeliveryTypeEnum.KTJ)
            {
                this.lblCompany.Text = "新竹貨運";
                var length = deliveryItem.ProductLength;
                var width = deliveryItem.ProductWidth;
                var height = deliveryItem.ProductHeight;

                var size = length * width * height;

                //長 x 寬 x 高（公分）x 0.0000353
                if (length > 100 || width > 100 || height > 100)
                {
                    this.lblCharge.Text = (size * 0.0000353 * 1100 + 500).ToString();
                }
                else
                {
                    this.lblCharge.Text = (size * 0.0000353 * 1200).ToString();
                }
            }
            else if (deliveryItem.DeliveryType == "3")
            {
                this.lblCompany.Text = "郵局";

                var weight = deliveryItem.ProductWeight;
                var feeByWeight = 80 + weight * 10;

                var length = deliveryItem.ProductLength;
                var width = deliveryItem.ProductWidth;
                var height = deliveryItem.ProductHeight;
                var size = length * width * height;
                var feeBySize = size * 0.0000353 * 1100;

                if (feeByWeight < feeBySize)
                {
                    this.lblCharge.Text = feeByWeight.ToString();
                }
                else
                {
                    this.lblCharge.Text = feeBySize.ToString();
                }
            }
            else
            {
                var js = "alert('發生不預期錯誤，請洽系統管理者');location.href='http://tw.yahoo.com/';";
                this.ClientScript.RegisterStartupScript(this.GetType(), "back", js, true);
            }
        }
    }
}
