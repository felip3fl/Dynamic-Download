namespace EasyD
{
    class TestClass
    {
        [STAThread]
        static void Main(string[] args)
        {
            Ytdlp ytdlp = new Ytdlp();
            var linkToDownload = "";

            if (validLinkFromParameters(args))
            {
                linkToDownload = getLinkFromParameters(args);
            }
            else
            {
                linkToDownload = getClipboardText();
            };

            ytdlp.Download(linkToDownload);
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

        public static string getLinkFromParameters(string[] args)
        {
            return args.FirstOrDefault();
        }

        public static bool validLinkFromParameters(string[] args)
        {
            if (args.FirstOrDefault() == null)
            {
                return false;
            }

            return true;
        }
    }


}
