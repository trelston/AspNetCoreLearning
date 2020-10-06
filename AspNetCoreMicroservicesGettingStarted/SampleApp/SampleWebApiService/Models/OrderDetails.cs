using System;

namespace SampleWebApiService.Models
{
    public class OrderDetailsDto
    {
        
            public Guid OrderId { get; set; }
            public string OrderNo { get; set; }
            public decimal OrderAmount { get; set; }
            public int? Discount { get; set; }
            public DateTime OrderDate { get; set; }
            public DateTime? DeliveryDate { get; set; }
            public int Quantity { get; set; }
            public string Name { get; set; }
        
    }
}