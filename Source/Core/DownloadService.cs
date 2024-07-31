using Infra;

namespace Core
{
    public class DownloadService
    {
        public string Download(string url)
        {
            Terminal terminal = new Terminal();
            
            return terminal.DownloadWithErrorMessage();
        }
    }
}
