using Microsoft.CognitiveServices.Speech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myapp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await RecognizeSpeech();
        }
        private static async Task RecognizeSpeech()
        {
            var txtstore1 = "";
            var txtstore2 = "";
            var temptxt = "";
            var configuration = SpeechConfig.FromSubscription("9990d2d709bf4bb2963c1256e2c6cc13", "southeastasia");
            using (var recog = new SpeechRecognizer(configuration))
            {
                Console.WriteLine("Speak Something.......!");
                var result1 = await recog.RecognizeOnceAsync();
                var result2 = await recog.RecognizeOnceAsync();
                if (result1.Reason == ResultReason.RecognizedSpeech)
                {
                    txtstore1 = result1.Text;
                    if (result2.Reason == ResultReason.RecognizedSpeech)
                    {
                        txtstore2 = result1.Text;
                        temptxt = txtstore1 + txtstore2;
                    }
                }
            }
        }
    }
}
