using System;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;

namespace ProjekUAS
{
    class Program
    {
        static void Main(string[] args)
        {

            var ourWindow = new NativeWindowSettings()
            {
                Size = new Vector2i(800, 800),
                Title = "ProjekUAS"
            };

            using (var win = new Windows(GameWindowSettings.Default, ourWindow))
            {
                win.Run();
            }

        }
    }
}
