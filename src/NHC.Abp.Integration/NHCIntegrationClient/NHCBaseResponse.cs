namespace NHC.Abp.Integration.NHCIntegrationClient;
internal record NHCBaseResponse<TBody>
{
    public Header Header { get; set; }
    public TBody Body { get; set; }

    public bool IsValidResponse =>
        Header is not null && Body is not null && Header.Status.Code == 200;
}

internal record Header
{
    public DateTime ResTime { get; set; }
    public string ChId { get; set; }
    public string RefId { get; set; }
    public string ReqID { get; set; }
    public Status Status { get; set; }
}

internal record Status
{
    public int Code { get; set; }
    public string Description { get; set; }
}
