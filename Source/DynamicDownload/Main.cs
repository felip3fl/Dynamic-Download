namespace DynamicDownload
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

            var urlWithoutParameters = RemoveAdditionalParameters(linkToDownload);
            ytdlp.Download(urlWithoutParameters);
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

        private static string RemoveAdditionalParameters(string url)
        {
            string urlWithNoParameters = "";
            int index = url.IndexOf("&");
            if (index >= 0)
                urlWithNoParameters = url.Substring(0, index);
            else
                return url;

            return urlWithNoParameters;
        }
    }


}
