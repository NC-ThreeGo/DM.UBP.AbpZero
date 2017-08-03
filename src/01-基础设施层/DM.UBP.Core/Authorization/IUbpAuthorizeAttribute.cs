namespace DM.UBP.Core.Authorization
{
    /// <summary>
    /// Defines standard interface for authorization attributes.
    /// </summary>
    public interface IUbpAuthorizeAttribute
    {
        /// <summary>
        /// 当前验证属性的验证类别
        /// </summary>
        UbpAuthorizeType AuthorizeType { get; set; }

        /// <summary>
        /// 操作码
        ///     当标识方法时——如果为空，则取ActionName；如果不为空，则取用户指定的值。再根据值转换成对应模块的对应操作码ID；
        ///     当标识控制器时——为空，系统自动转换成对应的模块ID；
        /// </summary>
        string[] OperateCodes { get; }

        /// <summary>
        /// If this property is set to true, all of the <see cref="Permissions"/> must be granted.
        /// If it's false, at least one of the <see cref="Permissions"/> must be granted.
        /// Default: false.
        /// </summary>
        bool RequireAllPermissions { get; set; }


    }
}