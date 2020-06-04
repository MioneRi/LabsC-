using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Lab4MusicPlay
{
    class Mp3Player : IDisposable
    {
        public bool Repeat { get; set; }

        // Accept the name of song file.
        public Mp3Player(string fileName)
        {
            // The format of the open command that we are going to send ino the "mciSendString"
            const string format = @"open ""{0}"" type mpegvideo alias MediaFile";
            string command = String.Format(format, fileName);
            
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        public void Play()
        {
            string command = "play MediaFile";

            if (Repeat)
            {
                command += " REPEAT";
            }

            mciSendString(command, null, 0, IntPtr.Zero);
        }

        public void Stop()
        {
            string command = "stop MediaFile";

            mciSendString(command, null, 0, IntPtr.Zero);
        }

        public void Close()
        {
            string command = "close MediaFile";

            mciSendString(command, null, 0, IntPtr.Zero);
        }

        // Include our method from "winmm.dll.
        // This will allows us to send commands to the API.
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand,
            StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        public void Dispose()
        {
            string command = "close MediaFile";

            mciSendString(command, null, 0, IntPtr.Zero);
        }
    }
}
