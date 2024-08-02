using Core;

namespace DynamicDownload
{
    public class TestClass
    {
        [STAThread]
        static void Main(string[] args)
        {
            var downloadService = new DownloadService();

            var linkToDownload = getLinkFromParameters(args);

            if (linkToDownload == null)
                linkToDownload = getClipboardText();

            var resultMessage = downloadService.Download(linkToDownload);
            Console.WriteLine(resultMessage);
        }

        private static string getClipboardText()
        {
            string returnAudioStream = null;
            if (Clipboard.ContainsText())
            {
                returnAudioStream = Clipboard.GetText();
            }
            return returnAudioStream;
        }

        private static string getLinkFromParameters(string[] args)
        {
            return args.FirstOrDefault();
        }

        private static bool validLinkFromParameters(string[] args)
        {
            if (args.FirstOrDefault() == null)
            {
                return false;
            }

            return true;
        }
    }


}
