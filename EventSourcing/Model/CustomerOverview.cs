
using System.Collections.Generic;

public class CustomerOverview : BaseOverview
{
    public override string id => customerId;
    public string customerId { get; set; }
    public int count { get; set; }

    public List<OrdersDetails> orders { get; set; }
}

