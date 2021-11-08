using System;
using Gifed;

namespace GifDancer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the BPM of the song:");
            double bpm = Convert.ToDouble(Console.ReadLine());
            var bpms = (bpm/60)*1000;
            //giflength == bps
            //giflength = delay * frames
            //delay * frames = bps
            //delay = bps / frames
            Console.WriteLine("Enter the address of your gif:");
            var gifAddress = Console.ReadLine();
            using (AnimatedGif gif = AnimatedGif.LoadFrom(gifAddress))
            {
                foreach (var gifFrame in gif)
                {
                    gifFrame.Delay = TimeSpan.FromMilliseconds((bpms/gif.FrameCount)/4);
                }
                gif.Save("result.gif");
            }
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}