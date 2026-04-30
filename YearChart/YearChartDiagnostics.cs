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

using System.Diagnostics;

namespace YearChart
{
    internal static class YearChartDiagnostics
    {
        public static long StartTimer()
        {
            return Stopwatch.GetTimestamp();
        }

        [Conditional("DEBUG")]
        public static void WriteElapsed(string operation, long startTimestamp)
        {
            var elapsed = Stopwatch.GetElapsedTime(startTimestamp);
            Debug.WriteLine($"YearChart: {operation} took {elapsed.TotalMilliseconds:0.###} ms");
        }

        public static double GetElapsedMilliseconds(long startTimestamp)
        {
            return Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
        }

        [Conditional("DEBUG")]
        public static void WriteLine(string message)
        {
            Debug.WriteLine($"YearChart: {message}");
        }
    }
}
