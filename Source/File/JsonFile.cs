namespace File
{
    public class JsonFile
    {
        
        public void Save(string path){

            System.IO.File.WriteAllText(path, "");
        } 
    }
}
