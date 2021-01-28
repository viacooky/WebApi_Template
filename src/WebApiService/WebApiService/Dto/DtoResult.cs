namespace WebApiService.Dto
{
    /// <summary>
    ///     标准返回结构
    /// </summary>
    public class DtoResult
    {
        /// <summary>
        ///     状态码
        /// </summary>
        public StateCode StateCode { get; set; } = StateCode.Success;

        /// <summary>
        ///     信息
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        ///     结果
        /// </summary>
        public string Result { get; set; } = string.Empty;
    }

    /// <summary>
    ///     返回结果状态码
    /// </summary>
    public enum StateCode
    {
        /// <summary>
        ///     成功
        /// </summary>
        Success = 0,

        /// <summary>
        ///     校验错误
        /// </summary>
        ValidError = -1,

        /// <summary>
        ///     未知错误
        /// </summary>
        UnKnowError = -99,
    }
}