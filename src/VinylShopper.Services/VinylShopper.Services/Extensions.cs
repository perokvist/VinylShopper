using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace VinylShopper.Services
{
    public static class Extensions
    {
        public static async Task<byte[]> ReadAllBytesAsync(this Stream stream)
        {
            try
            {
                using (stream)
                using (var ms = new MemoryStream())
                {

                    int count;
                    do
                    {
                        var buf = new byte[1024];
                        count = await stream.ReadAsync(buf, 0, 1024);
                        ms.Write(buf, 0, count);
                    } while (stream.CanRead && count > 0);
                    return ms.ToArray();
                }
            }
            catch
            {
                return null;
            }

        }

        public static void ForEach<T>(this IEnumerable<T> self, Action<T> action)
        {
            foreach (var item in self)
            {
                action(item);
            }
        }

        public static Uri ToUri(this string url)
        {
            return !string.IsNullOrWhiteSpace(url) ? new Uri(url) : null;
        }

        public static T Tap<T>(this T self, Action<T> action)
        {
            action(self);
            return self;
        }

        public static string Empty(this string self, params string[] values)
        {
            values.ForEach(c => self.Replace(c, String.Empty));
            return self;
        }

        public static string Decode(this string text)
        {
            return WebUtility.HtmlDecode(text);
        }
    }
}