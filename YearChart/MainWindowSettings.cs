/**
 * Copyright 2009-2026 Simon J. Williams.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * 
 * Kajabity is a trade mark of Simon J. Williams.
 * 
 * http://www.kajabity.com
 */

using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace YearChart
{
    internal sealed class MainWindowSettings
    {
        private const string SettingsFileName = "MainWindow.json";

        public Rectangle Bounds { get; set; }

        public FormWindowState WindowState { get; set; }

        public bool HasBounds => Bounds.Width > 0 && Bounds.Height > 0;

        public static MainWindowSettings Load()
        {
            var filename = GetSettingsFilename();

            if (!File.Exists(filename))
            {
                return new MainWindowSettings();
            }

            try
            {
                var json = File.ReadAllText(filename);
                return JsonSerializer.Deserialize<MainWindowSettings>(json) ?? new MainWindowSettings();
            }
            catch (Exception)
            {
                return new MainWindowSettings();
            }
        }

        public void Save()
        {
            var filename = GetSettingsFilename();
            var directory = Path.GetDirectoryName(filename);

            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            File.WriteAllText(filename, JsonSerializer.Serialize(this, options));
        }

        private static string GetSettingsFilename()
        {
            return Path.Combine(Application.UserAppDataPath, SettingsFileName);
        }
    }
}
