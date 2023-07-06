using Attendance_List_Generator.Models;
using LiteDB;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media.Media3D.Converters;

namespace Attendance_List_Generator.Helpers
{
    internal class Startup
    {
        private static readonly string _appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static readonly string _applicationPath = Path.Combine(_appDataFolder, "ALG_Data");

        public static Task StartupManager()
        {
            if (IsDirectoryExisting())
            {
                InitDb();
            }

            return Task.CompletedTask;
        }

        private static bool IsDirectoryExisting()
        {
            if (Directory.Exists(_applicationPath))
            {
                return true;
            }
            else
            {
                Directory.CreateDirectory(_applicationPath);
                return true;
            }
        }

        public static Task InitDb()
        {
            // Create or initialize database
            using var db = new LiteDatabase(Path.Combine(_applicationPath, "alg.db"));

            var workplaceCol = db.GetCollection<Workplace>("workplace");
            var agreementCol = db.GetCollection<Agreement>("agreement");
            var workersCol = db.GetCollection<Worker>("workers");

            db.Commit();

            return Task.CompletedTask;
        }
    }
}