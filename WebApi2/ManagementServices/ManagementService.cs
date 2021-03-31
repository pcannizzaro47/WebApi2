using System;
using DAL.Models;
using DAL.Interfaces;
using WebApi2.DTO;
using WebApi2.ExtensionMethods;
using System.Collections.Generic;
using System.Linq;

namespace WebApi2.ManagementServices
{
    public class ManagementService : IManagementService
    {
        private readonly IFileRepository _fileRepository;
        private readonly ICollectorRepository _collectorRepository;

        public ManagementService(IFileRepository fileRepository, ICollectorRepository collectorRepository)
        {
            _fileRepository = fileRepository;
            _collectorRepository = collectorRepository;
        }

        public FileDTO AddFile(FileDTO file)
        {
            if (file is null)
                throw new ArgumentNullException(nameof(file));

            var newFile = new File
            {
                CustomerCode = file.CustomerCode,
                Phone = file.Phone
            };

            var addedFile = _fileRepository.AddFile(newFile);
            _fileRepository.Save();

            return addedFile.ToDTO();
        }

        public FileDTO GetFileById(int id, bool includeFilesCollectors = true)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            return _fileRepository.GetFileById(id, includeFilesCollectors)?.ToDTO();
        }

        public FileDTO UpdateFile(FileDTO file)
        {
            if (file is null)
                throw new ArgumentNullException(nameof(file));

            File fileEntity = _fileRepository.GetFileById(file.ID);

            if (fileEntity is null)
                throw new KeyNotFoundException($"{file.ID} non trovato");

            fileEntity.CustomerCode = file.CustomerCode;
            fileEntity.Phone = file.Phone;

            file = _fileRepository.UpdateFile(fileEntity)?.ToDTO();
            _fileRepository.Save();

            return file;
        }

        public void DeleteFileById(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            File fileEntity = _fileRepository.GetFileById(id, true);

            if (fileEntity is null)
                return;

            if (fileEntity.FilesCollectors.Count > 0)
                throw new InvalidOperationException($"Pratica assegnata. Impossibile cancellare");

            _fileRepository.DeleteFile(fileEntity);

            _fileRepository.Save();
        }

        public FileCollectorDTO AssignFile(int idFile, int idCollector)
        {
            if (idFile <= 0)
                throw new ArgumentOutOfRangeException(nameof(idFile));

            if (idCollector <= 0)
                throw new ArgumentOutOfRangeException(nameof(idCollector));

            var fileEntity = _fileRepository.GetFileById(idFile, true);

            if (fileEntity is null)
                throw new KeyNotFoundException($"{idFile} non trovato");

            if (_collectorRepository.GetCollectorById(idCollector, false) is null)
                throw new KeyNotFoundException($"{idCollector} non trovato");

            if (fileEntity.FilesCollectors.Any(x => x.CollectorId == idCollector))
                throw new InvalidOperationException($"Pratica già assegnata");

            fileEntity.FilesCollectors.Add(new FileCollector { FileId = idFile, CollectorId = idCollector });

            _fileRepository.Save();

            return fileEntity.FilesCollectors.SingleOrDefault(x => x.FileId == idFile && x.CollectorId == idCollector).ToDTO();
        }

        public void UnassignFile(int idFile, int idCollector)
        {
            if (idFile <= 0)
                throw new ArgumentOutOfRangeException(nameof(idFile));

            if (idCollector <= 0)
                throw new ArgumentOutOfRangeException(nameof(idCollector));

            var fileEntity = _fileRepository.GetFileById(idFile, true);

            if (fileEntity is null)
                throw new KeyNotFoundException($"{idFile}/{idCollector} non trovato");

            var fileCollectorToDelete = fileEntity.FilesCollectors.SingleOrDefault(x => x.FileId == idFile && x.CollectorId == idCollector);

            if (fileCollectorToDelete is null)
                throw new KeyNotFoundException($"{idFile}/{idCollector} non trovato");

            fileEntity.FilesCollectors.Remove(fileCollectorToDelete);

            _fileRepository.Save();
        }
    }
}
