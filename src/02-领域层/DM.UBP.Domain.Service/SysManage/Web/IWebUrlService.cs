namespace DM.UBP.Domain.Service.SysManage.Web
{
    public interface IWebUrlService
    {
        string GetSiteRootAddress(string tenancyName = null);
    }
}
