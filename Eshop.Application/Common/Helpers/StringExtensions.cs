namespace Eshop.Application.Common.Helpers
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string @this)
            => string.IsNullOrEmpty(@this);
    }
}