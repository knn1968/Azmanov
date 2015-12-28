//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;

//namespace Core
//{
//    public class SourceRepository : ISourceRepository
//    {
//        string _directoryPath;
//        public SourceRepository(string directoryPath)
//        {
//            _directoryPath = directoryPath;
//        }
//        public List<GalleryPageItem> LoadSource(string languageShortDisplay)
//        {
//            var pageItemList = new List<GalleryPageItem>();

//            DirectoryInfo DirInfo = new DirectoryInfo(_directoryPath);

//            foreach (var f in DirInfo.EnumerateFiles())
//            {
//                pageItemList.Add(new GalleryPageItem() { Id = Convert.ToInt16(f.Name.Substring(0, f.Name.IndexOf("."))), Name = f.Name, Location = f.FullName, CreatedDate = f.CreationTime });
//            }

//            return pageItemList;

//        }
//    }
//}