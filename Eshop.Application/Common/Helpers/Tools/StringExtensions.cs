namespace Eshop.Application.Common.Helpers.Tools
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string @this)
            => string.IsNullOrEmpty(@this);
    }
}