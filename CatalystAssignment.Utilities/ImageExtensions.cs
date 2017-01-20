using System.Drawing;
using System.IO;


namespace CatalystAssignment.Utilities
{
    public static class ImageExtensions
    {
        /// <summary>
        /// Convert an image to a byte array
        /// </summary>
        /// <param name="img">Image to convert to byte array</param>
        /// <returns>Converted byte array</returns>
        public static byte[] ImageToByte(this Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        /// <summary>
        /// Convert a byte array to an image
        /// </summary>
        /// <param name="byteArrayIn">Bytes to convert to image</param>
        /// <returns>Converted Image</returns>
        public static Image ByteToImage(this byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
