﻿using API.IServices;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;

namespace API.Services
{
    public class FileService : IFileService
    {
        private readonly ServiceContext _serviceContext;
        public FileService(ServiceContext serviceContext) 
        {
            _serviceContext = serviceContext;
        }
        public async Task<int> InsertFile(FileItem fileItem)
        {
            try
            {
                await _serviceContext.Files.AddAsync(fileItem);
                _serviceContext.SaveChanges();
                return fileItem.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<FileIdentifierModel> InsertFiles(List<FileItem> fileItemList)
        {
            throw new NotImplementedException();
        }
        public void DeleteFile(int id)
        {
            throw new NotImplementedException();
        }

        public FileItem GetFileById(int id)
        {
            var file = _serviceContext.Set<FileItem>().Where(f => f.Id == id).FirstOrDefault();
            if(file != null)
            {
                return file;
            }
            else
            {
                throw new Exception("No se encontró el archivo.");
            }
        }

        public List<FileItem> GetFilesByCriteria(FileSearchCriteria fileSearchCriteria)
        {
            throw new NotImplementedException();
        }        
    }
}