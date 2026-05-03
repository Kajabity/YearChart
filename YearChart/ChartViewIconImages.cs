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
using System.Reflection;

namespace YearChart
{
    internal static class ChartViewIconImages
    {
        private const string ResourcePrefix = "YearChart.Assets.ViewIcons.";

        public static Image Load(ChartViewButtonIcon icon)
        {
            var resourceName = icon == ChartViewButtonIcon.PageLayout
                ? "page-layout-24.png"
                : "stretch-view-24.png";

            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(ResourcePrefix + resourceName)
                ?? throw new InvalidOperationException("Could not find chart view icon resource: " + resourceName);

            using var image = Image.FromStream(stream);
            return new Bitmap(image);
        }
    }
}
