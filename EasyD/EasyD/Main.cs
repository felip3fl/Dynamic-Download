namespace EasyD
{
    class TestClass
    {
        [STAThread]
        static void Main(string[] args)
        {
            Ytdlp ytdlp = new Ytdlp();

            var link = getClipboardText();

            ytdlp.Download(args.FirstOrDefault());
        }

        public static string getClipboardText()
        {
            string returnAudioStream = null;
            if (Clipboard.ContainsText())
            {
                returnAudioStream = Clipboard.GetText();
            }
            return returnAudioStream;
        }
    }


}
