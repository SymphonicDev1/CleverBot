using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleverbotCOM.NET;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Globalization;
namespace CleverBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Cleverbot cleverbot = new Cleverbot("CC26sC9wMH4_Mf5PfcH3JzfrQdw");
            Console.WriteLine("Speak Now");
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen); // to change VoiceGender and VoiceAge check out those links below
            synthesizer.Volume = 100;  // (0 - 100)
            synthesizer.Rate = 0;     // (-10 - 10)
            while (true)
            {
                SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
                Grammar dictationGrammar = new DictationGrammar();
                recognizer.LoadGrammar(dictationGrammar);
                recognizer.SetInputToDefaultAudioDevice();
                RecognitionResult result = recognizer.Recognize();
                string res = "";
                if (result == null)
                    res = "did you get that?";
                else
                    res = result.Text;
                Console.WriteLine(res);
                string question = cleverbot.Ask(res);
                Console.WriteLine("Cleverbot: " + question);
                synthesizer.SpeakAsync(question);
            }

        }
    }
}
