namespace File
{
    public class JsonFile
    {
        
        public void Save(string path){

            System.IO.File.WriteAllText(path, "");
        } 

        public string[] LoadAllLines(string path)
        {
            //check if file exists
            if (!System.IO.File.Exists(path))
            {
                throw new System.IO.FileNotFoundException();
            }

            var fileContent = System.IO.File.ReadAllLines(path);

            return fileContent;
        }

    }
}
