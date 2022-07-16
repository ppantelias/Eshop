using System.Text.Json;

namespace Eshop.Application.Common.Helpers.Tools
{
    public static class JsonUtilities
    {
        public static string Serialize<T>(this T @this)
            => JsonSerializer.Serialize(@this);
    }
}