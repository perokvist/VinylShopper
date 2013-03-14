using System.IO;
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
    }
}