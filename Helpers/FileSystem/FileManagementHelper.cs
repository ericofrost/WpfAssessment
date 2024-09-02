using System.Text;

namespace Helpers.FileSystem
{
    /// <summary>
    /// Static class with helpers to deal with files
    /// </summary>
    public static class FileManagementHelper
    {
        private static string _databasePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\WPF Assessment\Data";
        private static string _samplePath = @$"{_databasePath}\SampleFile.json";

        /// <summary>
        /// Creates the database folder if it doesn't exist
        /// </summary>
        /// <returns></returns>
        public static bool EnsureCreateDatabasePath()
        {
            if (!Directory.Exists(_databasePath))
            {
                try
                {
                    Directory.CreateDirectory(_databasePath);
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Gets the database file path
        /// </summary>
        /// <returns></returns>
        public static string DatabaseFilePath() => @$"Data Source={_databasePath}\Database.db";

        /// <summary>
        /// Tests if a file exists
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool FilePathIsValid(string path) => string.IsNullOrWhiteSpace(path) ? false : File.Exists(path);

        /// <summary>
        /// Reads a text file to the end and returns a list of line texts
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task<string> ReadTextFileAsync()
        {
            var result = new StringBuilder();

            if (FilePathIsValid(_samplePath))
            {
                using (var stream = File.Open(_samplePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var reader = new StreamReader(stream);

                    var line = string.Empty;

                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                            result.AppendLine(line);
                    }
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Deletes a file 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool DeleteSampleFile()
        {
            try
            {
                if (FilePathIsValid(_samplePath))
                {
                    File.Delete(_samplePath);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

    }
}
