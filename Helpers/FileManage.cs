namespace _5yanvardnm5.Helpers
{
    public static class FileManage
    {
        public static string SaveFile(string rootpath,string foldername, IFormFile file)
        {
            string name = file.FileName;
            name = name.Length > 64 ? name.Substring(name.Length-100,100) : name;
            name = Guid.NewGuid().ToString() + name;
            string SavePath = Path.Combine(rootpath,foldername,name);
            using (FileStream fs = new FileStream(SavePath, FileMode.Create))
            {
                file.CopyTo(fs);
            }
            return name;
        }

        public static void Delete(string rootpath, string foldername, string filename)
        {
            string dlt = Path.Combine(rootpath,foldername,filename);
            if (System.IO.File.Exists(filename))
            {
                System.IO.File.Delete(filename);
            }
        }
    }
}
