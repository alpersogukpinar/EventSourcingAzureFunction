
using System.Collections.Generic;

public class HubOverview : BaseOverview
{
    public override string id => partitionKey;
    public string partitionKey { get; set; }
    public int hubId { get; set; }
    public int count { get; set; }
    public List<string> orderNumbers { get; set; }
}

