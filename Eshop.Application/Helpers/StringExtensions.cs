namespace Eshop.Application.Helpers
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string @this)
            => string.IsNullOrEmpty(@this);
    }
}