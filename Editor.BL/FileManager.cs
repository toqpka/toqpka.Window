using System.IO;
using System.Text;

namespace Editor.BL
{

    public interface IFileManager
    {
        string GetContent(string filePath);
        string GetContent(string filePath, Encoding encoding);
        bool IsExist(string filePath);
    }

    public class FileManager : IFileManager
    {
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);

        public bool IsExist(string filePath)
        {
            bool isExist = File.Exists(filePath);
            return isExist;
        }

        public string GetContent(string filePath)
        {
            return GetContent(filePath, _defaultEncoding);
        }
        public string GetContent(string filePath, Encoding encoding)
        {
            string content = File.ReadAllText(filePath, encoding);
            return content;
        }
    }
}
