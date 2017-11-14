using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NineYi.Mall.BE
{
    public class DeliveryEntity
    {
        public DeliveryTypeEnum DeliveryType { get; set; }

        public double ProductLength { get; set; }

        public double ProductWidth { get; set; }

        public double ProductHeight { get; set; }

        public double ProductWeight { get; set; }
    }
}
