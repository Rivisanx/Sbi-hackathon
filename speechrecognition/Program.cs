using Microsoft.CognitiveServices.Speech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace speechrecognition
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            VoiceRecognizeSpeech().Wait();
            Console.ReadKey();
        }
        private static async Task VoiceRecognizeSpeech()
        {
            var configuration = SpeechConfig.FromSubscription("9990d2d709bf4bb2963c1256e2c6cc13", "southeastasia");
            using (var recog = new SpeechRecognizer(configuration))
            {
                recog.Recognizing += (sender, EventArgs) => { Console.WriteLine($"Recognizing: {EventArgs.Result.Text}"); };
                recog.Recognized += async (sender, EventArgs) =>
                {
                    var result = EventArgs.Result;
                    if (result.Reason == ResultReason.RecognizedSpeech)
                    {
                        Console.WriteLine($"Final Statement: {result.Text}.");
                    }
                    recog.SessionStarted += (sender, EventArgs) => { Console.WriteLine("\n Start Speaking!:"); };
                    recog.SessionStoped += (sender, EventArgs) => { Console.WriteLine("\n Stop Speaking!:"); };
                    await recog.StartContinousRecognitionAsync().ConfigureAwait(false);
                    do { Console.WriteLine("Enter to stop!"); }
                    while (Console.ReadKey().Key != ConsoleKey.Enter);
                    await recog.StopContinousRecognitionAsync().ConfigureAwait(false);
                }
            }
        }
    }
}
